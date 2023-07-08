
using System.Collections.Concurrent;
using System.Drawing;
using System.Runtime.InteropServices;
using Geek.Server.Core.Storage.DB;
using NLog.Fluent;
using RocksDbSharp;

namespace GeekDB.WebGUI.Storage.DB
{
    /// <summary>
    /// 内嵌数据库-基于RocksDB
    /// </summary>
    public class EmbeddedDB
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public RocksDb InnerDB { get; private set; }
        DbOptions option;
        ColumnFamilyOptions columnFamilyOpt;
        public string DbPath { get; private set; } = "";
        public string SecondPath { get; private set; } = "";
        public bool ReadOnly { get; private set; } = false;
        protected FlushOptions flushOption;
        protected ConcurrentDictionary<string, ColumnFamilyHandle> columnFamilie = new ConcurrentDictionary<string, ColumnFamilyHandle>();

        public EmbeddedDB(string path, bool readOnly = false, string readonlyPath = null)
        {
            ReadOnly = readOnly;
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            DbPath = path;
            option = new DbOptions();
            var bbtOpt = new BlockBasedTableOptions();

            bbtOpt.SetNoBlockCache(true); //没有block缓存
            bbtOpt.SetCacheIndexAndFilterBlocks(false);//不缓存索引

            option.SetBlockBasedTableFactory(bbtOpt);
            // option.EnableStatistics();
            RocksDb.TryListColumnFamilies(option, DbPath, out var cfList);
            var cfs = new ColumnFamilies();
            columnFamilyOpt = new ColumnFamilyOptions();
            columnFamilyOpt.SetDbWriteBufferSize(readOnly ? 1024ul : 1024ul * 512); //memtable大小  满了后会启用新的 
            // columnFamilyOpt.SetMaxWriteBufferNumber(readOnly ? 1 : 10);
            foreach (var cf in cfList)
            {
                cfs.Add(cf, columnFamilyOpt);
                columnFamilie[cf] = null;
            }

            if (readOnly)
            {
                option.SetMaxOpenFiles(-1);
                if (string.IsNullOrEmpty(readonlyPath))
                    SecondPath = DbPath + "_$$$";
                else
                    SecondPath = readonlyPath;
                InnerDB = RocksDb.OpenAsSecondary(option, DbPath, SecondPath, cfs);
            }
            else
            {
                option.SetMaxOpenFiles(120);
                flushOption = new FlushOptions();
                option.SetCreateIfMissing(true).SetCreateMissingColumnFamilies(true);
                InnerDB = RocksDb.Open(option, DbPath, cfs);
            }
        }

        public static string GetSizeStr(string sizeStr)
        {
            var numBytes = ulong.Parse(sizeStr);
            if (numBytes < 1024)
                return $"{numBytes} B";

            if (numBytes < 1048576)
                return $"{numBytes / 1024d:0.##} KB";

            if (numBytes < 1073741824)
                return $"{numBytes / 1048576d:0.##} MB";

            if (numBytes < 1099511627776)
                return $"{numBytes / 1073741824d:0.##} GB";

            if (numBytes < 1125899906842624)
                return $"{numBytes / 1099511627776d:0.##} TB";

            if (numBytes < 1152921504606846976)
                return $"{numBytes / 1125899906842624d:0.##} PB";

            return $"{numBytes / 1152921504606846976d:0.##} EB";
        }

        public string GetStatisticsString()
        {
            return $"rocksdb.block-cache-usage:{GetSizeStr(InnerDB.GetProperty("rocksdb.block-cache-usage"))}" +
                 $"   rocksdb.size-all-mem-tables:{GetSizeStr(InnerDB.GetProperty("rocksdb.size-all-mem-tables"))}" +
                 $"   rocksdb.estimate-table-readers-mem:{GetSizeStr(InnerDB.GetProperty("rocksdb.estimate-table-readers-mem"))}" +
                 $"   rocksdb.block-cache-usage:{GetSizeStr(InnerDB.GetProperty("rocksdb.block-cache-usage"))}" +
                 $"   rocksdb.block-cache-pinned-usage:{GetSizeStr(InnerDB.GetProperty("rocksdb.block-cache-pinned-usage"))}";
        }

        ColumnFamilyHandle GetOrCreateColumnFamilyHandle(string name)
        {
            lock (columnFamilie)
            {
                if (columnFamilie.TryGetValue(name, out var handle))
                {
                    if (handle != null)
                        return handle;
                    InnerDB.TryGetColumnFamily(name, out handle);
                    columnFamilie[name] = handle;
                    return handle;
                }
                else if (!ReadOnly)
                {
                    handle = InnerDB.CreateColumnFamily(columnFamilyOpt, name);
                    columnFamilie[name] = handle;
                    return handle;
                }
            }
            return null;
        }

        public void TryCatchUpWithPrimary()
        {
            if (ReadOnly)
            {
                InnerDB.TryCatchUpWithPrimary();
            }
        }

        public Table<T> GetTable<T>() where T : class
        {
            var name = typeof(T).FullName;
            var handle = GetOrCreateColumnFamilyHandle(name);
            if (handle == null)
                return null;
            return new Table<T>(this, name, handle);
        }

        public Table<byte[]> GetRawTable(string fullName)
        {
            var handle = GetOrCreateColumnFamilyHandle(fullName);
            if (handle == null)
                return null;
            return new Table<byte[]>(this, fullName, handle, true);
        }

        public Transaction NewTransaction()
        {
            return new Transaction(this);
        }

        public void WriteBatch(WriteBatch batch)
        {
            InnerDB.Write(batch);
        }

        public void Flush(bool wait)
        {
            if (!ReadOnly)
            {
                flushOption.SetWaitForFlush(wait);
                foreach (var c in columnFamilie)
                {
                    if (c.Value != null)
                    {
                        Native.Instance.rocksdb_flush_cf(InnerDB.Handle, flushOption.Handle, c.Value.Handle, out var err);
                        if (err != IntPtr.Zero)
                        {
                            var errStr = Marshal.PtrToStringAnsi(err);
                            Native.Instance.rocksdb_free(err);
                            LOGGER.Fatal($"rocksdb flush 错误:{errStr}");
                        }
                    }
                }
            }
        }

        public void Close()
        {
            Flush(true);
            Native.Instance.rocksdb_cancel_all_background_work(InnerDB.Handle, true);
            //Native.Instance.rocksdb_free(flushOption.Handle);
            InnerDB.Dispose();
        }
    }
}