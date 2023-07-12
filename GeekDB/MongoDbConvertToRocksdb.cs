using GeekDB.Core;
using MessagePack.Resolvers;
using MessagePack;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using RocksDbSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GeekDB
{
    public enum LogType
    {
        Info,
        Err
    }
    public class MongoDbConvertToRocksdb
    {
        EmbeddedDB rocksDb;
        IMongoDatabase mongoDBbase;
        Action<LogType, string> Log;
        Action<float, float> updateProcess;
        static StaticCompositeResolver resolver;

        public async Task Run(IMongoDatabase mongoDBbase, string path, Action<LogType, string> logAct, Action<float, float> process)
        {
            this.mongoDBbase = mongoDBbase;
            this.Log = logAct;
            if (logAct == null)
                Log = (t, s) => { };

            this.updateProcess = process;
            if (updateProcess == null)
                this.updateProcess = (i, i2) => { };

            await Task.Run(() =>
            {
                try
                {
                    if (resolver == null)
                    {
                        List<IFormatterResolver> innerResolver = new()
                        {
                               BuiltinResolver.Instance,
                               StandardResolver.Instance,
                               ContractlessStandardResolver.Instance,
                               PrimitiveObjectResolver.Instance
                        };
                        StaticCompositeResolver.Instance.Register(innerResolver.ToArray());
                        resolver = StaticCompositeResolver.Instance;
                    }
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
                        Log(LogType.Err, "导出失败...");
                        return;
                    }

                    var tableNames = mongoDBbase.ListCollectionNames().ToList();
                    //JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };

                    var processMax = tableNames.Count;
                    updateProcess(processMax, 0);
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
                        updateProcess(processMax, curTableIndex);
                        Log(LogType.Info, $"导出{name}完成,共导出{totalCount}条数据");
                    }
                    updateProcess(processMax, processMax);
                    Log(LogType.Info, $"全部导出完成...");//共导出{tableNames.Count}张表
                }
                catch (Exception e)
                {
                    Log(LogType.Err, $"导出异常:{e.Message}");
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
            Log(LogType.Info, "开始导出fs.files");
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
                    newDic = ConvertPolymorphic(newDic);
                    RemoveEmptyDic(newDic);
                    var rdata = MessagePackSerializer.Serialize(new List<object> { newMongodbTableStr != null ? newMongodbTableStr : mongodbTableId, newDic });

                    rocksdbTable.SetRaw(dataInfo.RocksdbId, rdata);
                }
                Log(LogType.Info, $"导出file to state:{file.Key},count:{file.Value.Count}");
            }
            return totalCount;
        }

        long exportNormalTable(string name, int processMax, int curTableIndex)
        {
            Log(LogType.Info, "开始导出" + name);
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
                        newDic = ConvertPolymorphic(newDic);
                        RemoveEmptyDic(newDic);
                        id = data["_id"];
                        rdata = MessagePackSerializer.Serialize(new List<object> { newMongodbTableStr != null ? newMongodbTableStr : mongodbTableId, newDic });
                    }
                    rocksdbTable.SetRaw(id.ToString(), rdata);
                }

                updateProcess(processMax, curTableIndex + startIndex * 1f / MathF.Max(totalCount, 1));
            }
            return totalCount;
        }

        object ConvertKVDicToNormalDic(object obj)
        {
            if (obj is IDictionary dic)
            {
                //如果只有k v两个字段，那说明是keypair结构，直接转成数组
                if (dic.Count == 2 && dic.Contains("k") && dic.Contains("v"))
                {
                    return new List<object>() { dic["k"], dic["v"] };
                }

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

        object ConvertPolymorphic(object obj)
        {
            if (obj is IDictionary dic)
            {
                foreach (var k in dic.Keys)
                {
                    dic[k] = ConvertPolymorphic(dic[k]);
                }
                if (dic.Contains("_t"))
                {
                    var value2 = dic["_t"] as string;
                    if (value2 != null)
                    {
                        dic.Remove("_t");
                        return new List<object> { value2, dic };
                    }
                }
            }
            if (obj is IList list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = ConvertPolymorphic(list[i]);
                }
            }
            return obj;
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
    }
}
