using Geek.Server;
using Geek.Server.RemoteBackup.Logic;
using MessagePack;
using MessagePack.Resolvers;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GeekDB.GUI.Pages
{
    public partial class Mongodb2Rocksdb : UIForm
    {
        IMongoDatabase mongoDBbase;
        string path;
        //string externDllPath;
        bool isExport;
        public Mongodb2Rocksdb(IMongoDatabase database)
        {
            this.mongoDBbase = database;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        List<string> logs = new List<string>();
        List<Color> logColors = new List<Color>();
        void addLog(string txt)
        {
            addColorLog(txt, Color.Black);
        }

        void addErr(string txt)
        {
            addColorLog(txt, Color.Red);
        }

        void clearLog()
        {
            logs.Clear();
            logColors.Clear();
            logTxtbox.Lines = logs.ToArray();
        }

        void addColorLog(string txt, Color color)
        {
            if (logs.Count > 400)
            {
                logs.RemoveAt(0);
                logColors.RemoveAt(0);
            }
            logs.Add(txt);
            logColors.Add(color);
            logTxtbox.Lines = logs.ToArray();
            var charIndex = 0;
            for (int i = 0; i < logs.Count; i++)
            {
                logTxtbox.SelectionStart = charIndex;
                logTxtbox.SelectionLength = logs[i].Length;
                logTxtbox.SelectionColor = logColors[i];
                charIndex += logs[i].Length + 1;
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    this.pathLable.Text = path;
                }
            }
        }


        private async void exportBtn_ClickAsync(object sender, EventArgs e)
        {
            if (isExport)
                return;
            clearLog();
            if (string.IsNullOrEmpty(path))
            {
                addErr($"路径不存在:{path}");
                return;
            }

            if (Directory.GetDirectories(path).Length > 0 || Directory.GetFiles(path).Length > 0)
            {
                addErr($"导出失败,目录不为空:{path}");
                return;
            }



            isExport = true;
            await export();
            isExport = false;
        }

        void UpdateProcess(float max, float curr)
        {
            processBar.Maximum = (int)(max * 100);
            processBar.Value = (int)(curr * 100);
        }

        [MessagePackObject(true)]
        class KVDic
        {
            public string k;
            public object v;
        }

        Dictionary<object, object> ConvertKVDicToNormalDic(IDictionary dic)
        {
            var newDic = new Dictionary<object, object>();
            //如果是kv数组，转成dic
            foreach (var key in dic.Keys)
            {
                newDic[key] = dic[key];
                var value = dic[key];
                if (value is IDictionary dicValue)
                {
                    newDic[key] = ConvertKVDicToNormalDic(dicValue);
                }
                if (value is IList listValue)
                {
                    if (listValue.Count > 0)
                    {
                        if (listValue[0] is IDictionary dicValue2)
                        {
                            var newListDic = new Dictionary<object, object>();
                            newDic[key] = newListDic;
                            if (dicValue2.Contains("k") && dicValue2.Contains("v"))
                            {
                                foreach (var value2 in listValue)
                                {
                                    var dicv2 = value2 as IDictionary;
                                    var dicv2v = dicv2["v"];
                                    if (dicv2v is IDictionary)
                                    {
                                        newListDic[dicv2["k"]] = ConvertKVDicToNormalDic(dicv2v as IDictionary);
                                    }
                                    else
                                        newListDic[dicv2["k"]] = dicv2v;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < listValue.Count; i++)
                                {
                                    var value2 = listValue[i];
                                    if (value2 is IDictionary dicValue3)
                                    {
                                        listValue[i] = ConvertKVDicToNormalDic(dicValue3);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        newDic.Remove(key);
                    }
                }
            }
            return newDic;
        }

        void ConvertPolymorphic(IDictionary dic)
        {
            foreach (var k in dic.Keys)
            {
                var value = dic[k];
                if (value is IDictionary vdic1)
                {
                    if (vdic1.Contains("_t"))
                    {
                        var value2 = vdic1["_t"] as string;
                        if (value2 != null)
                        {
                            vdic1.Remove("_t");
                            dic[k] = new List<object> { value2, vdic1 };
                        }
                    }
                    ConvertPolymorphic(vdic1);
                }

                if (value is IList vlist)
                {
                    for (int i = 0; i < vlist.Count; i++)
                    {
                        var lv = vlist[i];
                        if (lv is IDictionary vdic2)
                        {
                            if (vdic2.Contains("_t"))
                            {
                                var value3 = vdic2["_t"] as string;
                                if (value3 != null)
                                {
                                    vdic2.Remove("_t");
                                    dic[k] = new List<object> { value3, vdic2 };
                                }
                            }
                            ConvertPolymorphic(vdic2);
                        }
                    }
                }
            }
        }


        EmbeddedDB rocksDb;
        async Task export()
        {
            await Task.Run(() =>
            {
                try
                {
                    List<IFormatterResolver> innerResolver = new()
                    {
                           BuiltinResolver.Instance,
                           StandardResolver.Instance,
                           ContractlessStandardResolver.Instance,
                            PrimitiveObjectResolver.Instance
                    };
                    StaticCompositeResolver.Instance.Register(innerResolver.ToArray());
                    MessagePackSerializer.DefaultOptions = new MessagePackSerializerOptions(StaticCompositeResolver.Instance);

                    //if (File.Exists(externDllPath))
                    //{
                    //    var app = AppDomain.CreateDomain("ed");
                    //    Assembly dllAssembly = app.Load(AssemblyName.GetAssemblyName(externDllPath));
                    //    AppDomain.Unload(app);
                    //}

                    rocksDb = new EmbeddedDB(path);
                    var tableNames = mongoDBbase.ListCollectionNames().ToList();

                    JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };

                    var processMax = tableNames.Count;
                    UpdateProcess(processMax, 0);
                    int curTableIndex = 0;
                    foreach (var name in tableNames)
                    {
                        addLog("开始导出" + name);
                        var rocksdbTable = rocksDb.GetRawTable(name);
                        var mongoTable = mongoDBbase.GetCollection<BsonDocument>(name);
                        var mongoQueryStr = "{}";
                        var totalCount = mongoTable.CountDocuments(mongoQueryStr);
                        int startIndex = 0;
                        var mongodbTableId = (int)MurmurHash3.Hash(name);
                        while (startIndex < totalCount)
                        {
                            if (rocksDb == null)
                            {
                                return;
                            }
                            var everyTimeQueryCount = 200;
                            var result = mongoTable.Find(mongoQueryStr).Limit(everyTimeQueryCount).Skip(startIndex).ToList();
                            startIndex += everyTimeQueryCount;
                            foreach (var data in result)
                            {
                                string id;
                                byte[] rdata;
                                try
                                {
                                    var value = BsonSerializer.Deserialize<MongoState>(data);
                                    id = value.Id;
                                    rdata = value.Data;
                                }
                                catch (Exception e)
                                {
                                    //说明数据不是rocksdb备份到mongodb的数据，尝试直接写 
                                    id = data["_id"].ToString();

                                    var dic = data.ToDictionary();
                                    dic["Id"] = dic["_id"];
                                    dic.Remove("_id");

                                    var newDic = ConvertKVDicToNormalDic(dic);
                                    ConvertPolymorphic(newDic);
                                    rdata = MessagePackSerializer.Serialize(new List<object> { mongodbTableId, newDic });
                                }
                                rocksdbTable.SetRaw(id, rdata);
                            }

                            UpdateProcess(processMax, curTableIndex + startIndex * 1f / MathF.Max(totalCount, 1));
                        }
                        curTableIndex++;
                        UpdateProcess(processMax, curTableIndex);
                        addLog($"导出{name}完成,共导出{totalCount}条数据");
                    }
                    addLog($"全部导出完成,共导出{tableNames.Count}张表");
                }
                catch (Exception e)
                {
                    addErr($"导出异常:{e.Message}");
                }
                finally
                {
                    if (rocksDb != null)
                    {
                        rocksDb.Close();
                        rocksDb = null;
                    }
                }
            });
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (rocksDb != null)
            {
                rocksDb.Close();
                rocksDb = null;
            }
            base.OnFormClosed(e);
        }

    }
}
