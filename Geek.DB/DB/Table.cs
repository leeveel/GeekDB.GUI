using System.Text;
using RocksDbSharp;
using NLog;
using System.Collections;
using System.Reflection.Metadata;

namespace Geek.Server
{
    public class Table<T> : IEnumerable<T>
    {
        protected static readonly Logger Log = LogManager.GetCurrentClassLogger();
        protected EmbeddedDB db;
        ColumnFamilyHandle cfHandle;
        string tableName;
        bool isRawTable;

        internal Table(EmbeddedDB db, string name, ColumnFamilyHandle cfHandle, bool isRawTable = false)
        {
            this.db = db;
            this.cfHandle = cfHandle;
            this.isRawTable = isRawTable;
            tableName = name;
            if (!db.InnerDB.TryGetColumnFamily(tableName, out cfHandle))
            {
                var option = new ColumnFamilyOptions();
                cfHandle = db.InnerDB.CreateColumnFamily(option, tableName);
            }
        }

        public void Set<IDType>(IDType id, T value, Transaction trans = null)
        {
            var data = Serializer.Serialize<T>(value);
            SetRaw(id, data);
        }

        public void SetRaw<IDType>(IDType id, byte[] data, Transaction trans = null)
        {
            var mainId = GetDBKey(id);
            if (trans != null)
            {
                trans.Set(tableName, mainId, data, cfHandle);
            }
            else
            {
                db.InnerDB.Put(Encoding.UTF8.GetBytes(mainId), data, cfHandle);
                db.remoteBackup.Set(tableName, mainId, data);
            }
        }

        public void SetBatch<IDType>(List<IDType> ids, List<T> values, Transaction trans = null)
        {
            var valueList = new List<byte[]>(values.Count);
            foreach (var value in values)
            {
                var mainId = GetDBKey(value);
                if (string.IsNullOrEmpty(mainId))
                {
                    throw new NotFindKeyException($"no KeyAttribute find in {tableName}");
                }
                valueList.Add(Serializer.Serialize<T>(value));
            }
            SetRawBatch(ids, valueList, trans);
        }

        public void SetRawBatch<IDType>(List<IDType> ids, List<byte[]> values, Transaction trans = null)
        {
            var batch = trans == null ? new WriteBatch() : null;
            var count = values.Count;
            var keyList = new List<string>(count);
            foreach (var value in ids)
            {
                var mainId = GetDBKey(value);
                keyList.Add(mainId);
            }

            for (int i = 0; i < count; i++)
            {
                var mainId = keyList[i];
                var data = values[i];
                if (batch != null)
                {
                    var id = Encoding.UTF8.GetBytes(mainId);
                    batch.Put(id, data, cfHandle);
                }
                else
                {
                    trans.Set(tableName, mainId, data, cfHandle);
                }
            }

            if (trans == null)
            {
                db.InnerDB.Write(batch);
                db.remoteBackup.SetBatch(tableName, keyList, values);
            }
        }

        public void Delete<IDType>(IDType id, Transaction trans = null)
        {
            var mainId = GetDBKey(id);

            if (trans != null)
            {
                trans.Delete(tableName, mainId, cfHandle);
            }
            else
            {
                db.InnerDB.Remove(Encoding.UTF8.GetBytes(mainId), cfHandle);
                db.remoteBackup.Delete(tableName, mainId);
            }
        }

        public T Get<IDType>(IDType id)
        {
            var data = db.InnerDB.Get(Encoding.UTF8.GetBytes(GetDBKey(id)), cfHandle);
            if (data == null)
            {
                return default;
            }
            if (isRawTable)
            {
                return (T)(object)data;
            }
            return Serializer.Deserialize<T>(data);
        }

        public List<T> GetAll()
        {
            return this.ToList();
        }

        protected string GetDBKey<IDType>(IDType id)
        {
            return id.ToString();
        }
        public Enumerator GetKVEnumerator()
        {
            return new Enumerator(this, true);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this, false);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Enumerator : IEnumerator<T>
        {
            //private Snapshot snapshot;
            private Iterator dbIterator;
            private T curValue = default(T);
            private string curKey = "";
            private byte[] curKeyBytes;
            private Table<T> table;
            private bool parseKey;

            internal Enumerator(Table<T> table, bool parseKey)
            {
                this.parseKey = parseKey;
                this.table = table;
                dbIterator = table.db.InnerDB.NewIterator(table.cfHandle);
                dbIterator.SeekToFirst();
            }

            private bool isDisposed = false;
            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }

            void Dispose(bool disposing)
            {
                if (!table.db.CanUse())
                    return;
                if (!isDisposed)
                {
                    curValue = default(T);
                    if (dbIterator != null)
                    {
                        dbIterator.Dispose();
                        dbIterator = null;
                    }
                }
                isDisposed = true;
            }

            ~Enumerator()
            {
                Dispose(disposing: false);
            }

            public bool MoveNext()
            {
                if (dbIterator.Valid())
                {
                    if (table.isRawTable)
                        curValue = (T)(object)dbIterator.Value();
                    else
                        curValue = Serializer.Deserialize<T>(dbIterator.Value());
                    curKeyBytes = dbIterator.Key();
                    dbIterator.Next();
                    return true;
                }
                return false;
            }

            public string Key
            {
                get
                {
                    return Encoding.UTF8.GetString(curKeyBytes);
                }
            }
            public byte[] KeyBytes
            {
                get
                {
                    return curKeyBytes;
                }
            }

            public T Current => curValue;

            object IEnumerator.Current
            {
                get
                {
                    return curValue;
                }
            }


            void IEnumerator.Reset()
            {
                dbIterator.SeekToFirst();
            }
        }
    }
}