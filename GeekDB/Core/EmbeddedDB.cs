
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices;
using MessagePack;
using RocksDbSharp;

namespace GeekDB.Core
{
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
            //bbtOpt.SetCacheIndexAndFilterBlocks(false);//不缓存索引

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

            option.SetMaxOpenFiles(110);
            if (readOnly)
            {
                if (string.IsNullOrEmpty(readonlyPath))
                    SecondPath = DbPath + "_$$$";
                else
                    SecondPath = readonlyPath;
                if (Directory.Exists(SecondPath))
                {
                    Directory.Delete(SecondPath, true);
                }
                Directory.CreateDirectory(SecondPath);
                InnerDB = RocksDb.OpenAsSecondary(option, DbPath, SecondPath, cfs);
            }
            else
            {
                flushOption = new FlushOptions();
                option.SetCreateIfMissing(true).SetCreateMissingColumnFamilies(true);
                InnerDB = RocksDb.Open(option, DbPath, cfs);
            }
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

        public Table<T> GetTable<T>(string name = null) where T : class
        {
            name = name == null ? typeof(T).FullName : name;
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