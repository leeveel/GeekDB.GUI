using Geek.Server;
using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekDB.GUI.Logic
{
    internal static class Helper
    {

        private static Dictionary<string, EmbeddedDB> openedDBs = new Dictionary<string, EmbeddedDB>();

        /// <summary>
        /// 获取最近打开路径
        /// </summary>
        /// <returns></returns>
        private static List<string> GetRecentOpenPath()
        {
            return default;
        }

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
