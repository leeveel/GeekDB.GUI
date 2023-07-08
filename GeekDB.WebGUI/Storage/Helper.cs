using Geek.Server;
using GeekDB.WebGUI.Storage.DB;
using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekDB.WebGUI.Storage
{
    internal static class Helper
    {
        public static List<string> GetAllTableNames(string dbPath)
        {
            RocksDb.TryListColumnFamilies(new DbOptions(), dbPath, out var cfList);
            return cfList.ToList();
        }
        public static bool IsRocksDB(string dbPath)
        {
            return GetAllTableNames(dbPath).Count > 0;
        }

    }
}
