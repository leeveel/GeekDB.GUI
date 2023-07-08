using GeekDB.WebGUI.Storage.DB;
using GeekDB.WebGUI.Web.Pages.DB;
using Syncfusion.Blazor.DropDowns;
using System.ComponentModel;
using System.Text;

namespace GeekDB.WebGUI.Web.Data
{
    public class Data
    {
        public string Key { get; set; }
        public byte[] ValueBytes { get; set; }

        private string jsonStr = null;
        private string jsonPartStr = null;
        public string DataJsonPart
        {
            get
            {
                if (jsonPartStr == null)
                {
                    jsonStr = JsonText;
                    if (jsonStr.Length > 150)
                    {
                        jsonPartStr = jsonStr.Substring(0, 150) + "...";
                    }
                    else
                    {
                        jsonPartStr = jsonStr;
                    }
                }
                return jsonPartStr;
            }
        }

        public string JsonText
        {
            get
            {
                if (jsonStr == null)
                {
                    try
                    {
                        jsonStr = MessagePack.MessagePackSerializer.ConvertToJson(ValueBytes);
                    }
                    catch (Exception e)
                    {
                        jsonStr = UTF8Encoding.UTF8.GetString(ValueBytes);
                    }
                }
                return jsonStr;
            }
        }

        public string Size
        {
            get
            {
                return Utils.Utils.GetSizeStr((ulong)ValueBytes.LongLength);
            }
        }
    }

    public class TableInfos
    {
        public string name;
        public List<Data> SrcDatas = new List<Data>();
        public List<Data> SearchDatas = new List<Data>();
    }

    public class DBManager
    {
        public EmbeddedDB CurRockDb;
        public TableInfos curTable;
        string tempPath;

        public void Open(string path)
        {
            tempPath = Path.GetTempPath() + "rocksdb_editor/" + Path.GetFileName(path) + "_temp" + DateTime.Now.Ticks;
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
            CurRockDb = new EmbeddedDB(path, true, tempPath);
        }

        public void Close()
        {
            try
            {
                curTable = null;
                if (CurRockDb != null)
                {
                    Console.WriteLine("close db:" + CurRockDb.DbPath);
                    CurRockDb.Close();
                    CurRockDb = null;
                }
            }
            catch
            {

            }

            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

        public void LoadTable(string name)
        {
            curTable = new TableInfos { name = name };
            if (CurRockDb != null)
            {
                var datas = curTable.SrcDatas;
                var searchDatas = curTable.SearchDatas;
                var table = CurRockDb.GetRawTable(name);
                if (table != null)
                {
                    var iter = table.GetKVEnumerator();
                    while (iter.MoveNext())
                    {
                        var data = new Data { Key = Encoding.UTF8.GetString(iter.KeyBytes), ValueBytes = iter.Current };
                        datas.Add(data);
                        searchDatas.Add(data);
                    }
                    iter.Dispose();
                }
            }
        }

        public void Search(string query = "")
        {
            if (CurRockDb == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(query))
            {
                curTable.SearchDatas.Clear();
                curTable.SearchDatas.AddRange(curTable.SrcDatas);
                return;
            }

            var datas = curTable.SrcDatas;
            var searchDatas = curTable.SearchDatas;

            searchDatas.Clear();
            var keys = query.Split(new char[] { ',', ';', '，', '；' });
            foreach (var key in keys)
            {
                if (string.IsNullOrWhiteSpace(key))
                    continue;
                var lkey = key.ToLower();
                foreach (var data in datas)
                {
                    if (data.Key.ToLower().Contains(lkey) || data.JsonText.ToLower().Contains(lkey))
                    {
                        if (searchDatas.Find(d => d.Key == data.Key) == null)
                        {
                            searchDatas.Add(data);
                        }
                    }
                }
            }
        }
    }
}
