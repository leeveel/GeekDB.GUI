using Geek.Server;
using Geek.Server.RemoteBackup.Logic;
using MessagePack;
using MessagePack.Resolvers;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Renci.SshNet.Security;
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

        object ConvertKVDicToNormalDic(object obj)
        {
            if (obj is IDictionary dic)
            {
                var newDic = new Dictionary<object, object>();
                foreach (var key in dic.Keys)
                {
                    if (key.ToString() == "_id")
                    {
                        newDic["Id"] = dic["_id"];
                        newDic["id"] = dic["_id"];
                    }
                    newDic[key] = ConvertKVDicToNormalDic(dic[key]);
                    //if (newValue is IList vlist && vlist.Count == 0)
                    //{
                    //    newDic.Remove(key);
                    //}
                }
                return newDic;
            }

            if (obj is IList list)
            {
                //如果确定是kv结构的数组
                if (list.Count > 0 && list[0] is IDictionary dic2 && dic2.Contains("k") && dic2.Contains("v"))
                {
                    var newListDic = new Dictionary<object, object>();
                    foreach (var item in list)
                    {
                        var dic3 = item as IDictionary;
                        newListDic[dic3["k"]] = ConvertKVDicToNormalDic(dic3["v"]);
                    }
                    return newListDic;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = ConvertKVDicToNormalDic(list[i]);
                }
                return list;
            }
            return obj;
        }

        void ConvertPolymorphic(object obj)
        {
            var dic = obj as IDictionary;
            if (dic != null)
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
                    }
                    ConvertPolymorphic(value);
                }
            }
            var vlist = obj as IList;
            if (vlist != null)
            {
                for (int i = 0; i < vlist.Count; i++)
                {
                    ConvertPolymorphic(vlist[i]);
                }
            }
        }

        void RemoveEmptyDic(object obj)
        {
            var dic = obj as IDictionary;
            if (dic != null)
            {
                foreach (var k in dic.Keys)
                {
                    var v = dic[k];
                    if (v is IList list && list.Count == 0)
                    {
                        dic.Remove(k);
                    }
                    else
                    {
                        RemoveEmptyDic(v);
                    }
                }
            }
            var list2 = obj as IList;
            if (list2 != null)
            {
                foreach (var v in list2)
                {
                    RemoveEmptyDic(v);
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
                    MessagePackSerializer.DefaultOptions = new MessagePackSerializerOptions(StaticCompositeResolver.Instance).WithCompression(MessagePackCompression.Lz4Block);

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
                    //JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };

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
                    UpdateProcess(processMax, processMax);
                    addImportantLog($"全部导出完成...");//共导出{tableNames.Count}张表
                }
                catch (Exception e)
                {
                    addErr($"导出异常:{e.Message}");
                }
                finally
                {
                    MessagePackSerializer.DefaultOptions = null;
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
                //if (!file.Key.EndsWith("WorldArenaChampionState"))
                //    continue;

                var rocksdbTable = rocksDb.GetRawTable(file.Key);
                var mongodbTableId = (int)MurmurHash3.Hash(file.Key);
                foreach (var dataInfo in file.Value)
                {
                    var doc = BsonSerializer.Deserialize<BsonDocument>(dataInfo.Datas);
                    var dic = doc.ToDictionary();
                    //dic["Id"] = dataInfo.RocksdbId; 

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
                    ConvertPolymorphic(newDic as IDictionary);
                    RemoveEmptyDic(newDic);
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
                    object id;
                    byte[] rdata;
                    try
                    {
                        var value = BsonSerializer.Deserialize<MongoTimestampState>(data);
                        id = value.Id;
                        rdata = value.Data;
                    }
                    catch (Exception e)
                    {
                        var dic = data.ToDictionary();

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
                        ConvertPolymorphic(newDic as IDictionary);
                        RemoveEmptyDic(newDic);
                        id = data["_id"];
                        rdata = MessagePackSerializer.Serialize(new List<object> { newMongodbTableStr != null ? newMongodbTableStr : mongodbTableId, newDic });
                    }
                    rocksdbTable.SetRaw(id.ToString(), rdata);
                }

                UpdateProcess(processMax, curTableIndex + startIndex * 1f / MathF.Max(totalCount, 1));
            }
            return totalCount;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = true;
            base.OnFormClosed(e);
        }

        private void Mongodb2Rocksdb_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isExport;
            if (isExport)
            {
                MessageBox.Show("导出中...不能关闭...");
            }
        }
    }
}
