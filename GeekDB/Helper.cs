using MongoDB.Driver;
using NLog;
using RocksDbSharp;
using System.Runtime.InteropServices;

namespace GeekDB
{
    public static class Helper
    {
        static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public static List<string> GetAllTableNames(string dbPath)
        {
            UIntPtr lencf;
            IntPtr errptr;
            IntPtr intPtr = Native.Instance.rocksdb_list_column_families(new DbOptions().Handle, dbPath, out lencf, out errptr);
            if (errptr != IntPtr.Zero)
            {
                var errStr = Marshal.PtrToStringAnsi(errptr);
                Native.Instance.rocksdb_free(errptr);
                throw new Exception(errStr);
            }
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
