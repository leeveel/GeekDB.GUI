using RocksDbSharp;

namespace Geek.DB
{
    public static class Helper
    {
        public static List<string> GetAllTableNames(string dbPath)
        {
            RocksDb.TryListColumnFamilies(new DbOptions(), dbPath, out var cfList);
            return cfList.ToList();
        }
        public static bool IsRocksDB(string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
                return false;
            return GetAllTableNames(dbPath).Count > 0;
        }

    }
}
