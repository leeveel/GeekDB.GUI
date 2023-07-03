using Geek.Server;
using Geek.Server.RemoteBackup.Logic;
using MessagePack;
using MessagePack.Resolvers;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using RocksDbSharp;
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
using System.Net.Sockets;
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
            this.DoubleBuffered = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        void addLog(string txt)
        {
            addColorLog(txt, Color.Black);
        }

        void addImportantLog(string txt)
        {
            addColorLog(txt, Color.Blue);
        }

        void addErr(string txt)
        {
            addColorLog(txt, Color.Red);
        }

        void clearLog()
        {
            logTxtbox.Text = "";
        }

        void addColorLog(string txt, Color color)
        {
            var charIndex = logTxtbox.Text.Length;
            logTxtbox.AppendText(txt + "\n");
            logTxtbox.SelectionStart = charIndex;
            logTxtbox.SelectionLength = txt.Length;
            logTxtbox.SelectionColor = color;

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
                    if (rocksDb == null)
                    {
                        addErr("导出失败...");
                        return;
                    }

                    var tableNames = mongoDBbase.ListCollectionNames().ToList();

                    JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };

                    var processMax = tableNames.Count;
                    UpdateProcess(processMax, 0);
                    int curTableIndex = 0;
                    foreach (var name in tableNames)
                    {
                        long totalCount = 0;

                        if (name == "fs.chunks")
                        {
                            curTableIndex++;
                            continue;
                        }
                        if (name == "fs.files")
                        {
                            totalCount = exportFiles(processMax, curTableIndex);
                        }
                        else
                        {
                            totalCount = exportNormalTable(name, processMax, curTableIndex);
                        }
                        curTableIndex++;
                        UpdateProcess(processMax, curTableIndex);
                        addLog($"导出{name}完成,共导出{totalCount}条数据");
                    }
                    addImportantLog($"全部导出完成...");//共导出{tableNames.Count}张表
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

        long exportFiles(int processMax, int curTableIndex)
        {
            addImportantLog("开始导出fs.files");
            var bucket = new GridFSBucket(mongoDBbase);
            var mongoTable = mongoDBbase.GetCollection<BsonDocument>("fs.files");
            var mongoQueryStr = "{}";
            var totalCount = mongoTable.CountDocuments(mongoQueryStr);
            int startIndex = 0;

            Dictionary<string, List<MongoFile>> files = new Dictionary<string, List<MongoFile>>();
            while (startIndex < totalCount)
            {
                var everyTimeQueryCount = 200;
                var result = mongoTable.Find(mongoQueryStr).Limit(everyTimeQueryCount).Skip(startIndex).ToList();
                startIndex += everyTimeQueryCount;
                foreach (var data in result)
                {
                    var fileData = BsonSerializer.Deserialize<MongoFile>(data);
                    var strs = fileData.filename.Split('_');
                    var stateName = strs[0];
                    fileData.RocksdbId = strs[1];
                    List<MongoFile> list;
                    if (!files.TryGetValue(stateName, out list))
                    {
                        list = new List<MongoFile>();
                        files[stateName] = list;
                    }
                    list.Add(fileData);
                    fileData.Datas = bucket.DownloadAsBytes(fileData.Id);
                }
            }
            foreach (var file in files)
            {
                var rocksdbTable = rocksDb.GetRawTable(file.Key);
                var mongodbTableId = (int)MurmurHash3.Hash(file.Key);
                foreach (var dataInfo in file.Value)
                {
                    var doc = BsonSerializer.Deserialize<BsonDocument>(dataInfo.Datas);
                    var dic = doc.ToDictionary();
                    dic["Id"] = dataInfo.RocksdbId;
                    dic.Remove("_id");

                    string newMongodbTableStr = null;

                    if (dic.ContainsKey("_t"))
                    {
                        var value2 = dic["_t"] as string;
                        if (value2 != null)
                        {
                            dic.Remove("_t");
                            newMongodbTableStr = value2;
                        }
                    }

                    var newDic = ConvertKVDicToNormalDic(dic);
                    ConvertPolymorphic(newDic);
                    var rdata = MessagePackSerializer.Serialize(new List<object> { newMongodbTableStr != null ? newMongodbTableStr : mongodbTableId, newDic });
                    rocksdbTable.SetRaw(dataInfo.RocksdbId, rdata);
                }
                addImportantLog($"导出file to state:{file.Key},count:{file.Value.Count}");
            }
            return totalCount;
        }

        long exportNormalTable(string name, int processMax, int curTableIndex)
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
                var everyTimeQueryCount = 200;
                var result = mongoTable.Find(mongoQueryStr).Limit(everyTimeQueryCount).Skip(startIndex).ToList();
                startIndex += everyTimeQueryCount;
                foreach (var data in result)
                {
                    string id;
                    byte[] rdata;
                    try
                    {
                        var value = BsonSerializer.Deserialize<MongoTimestampState>(data);
                        id = value.Id;
                        rdata = value.Data;
                    }
                    catch (Exception e)
                    {
                        id = data["_id"].ToString();
                        var dic = data.ToDictionary();
                        dic["Id"] = dic["_id"];
                        dic.Remove("_id");

                        string newMongodbTableStr = null;

                        if (dic.ContainsKey("_t"))
                        {
                            var value2 = dic["_t"] as string;
                            if (value2 != null)
                            {
                                dic.Remove("_t");
                                newMongodbTableStr = value2;
                            }
                        }

                        var newDic = ConvertKVDicToNormalDic(dic);
                        ConvertPolymorphic(newDic);
                        rdata = MessagePackSerializer.Serialize(new List<object> { newMongodbTableStr != null ? newMongodbTableStr : mongodbTableId, newDic });
                    }
                    rocksdbTable.SetRaw(id, rdata);
                }

                UpdateProcess(processMax, curTableIndex + startIndex * 1f / MathF.Max(totalCount, 1));
            }
            return totalCount;
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
