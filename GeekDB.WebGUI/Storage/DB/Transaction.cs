using System.Text;
using GeekDB.WebGUI.Storage.DB;
using RocksDbSharp;

namespace Geek.Server.Core.Storage.DB
{
    public class Transaction
    {
        EmbeddedDB db;
        WriteBatch batch;
        public Transaction(EmbeddedDB db)
        {
            this.db = db;
            batch = new WriteBatch();
        }

        public void Set(string table, string key, byte[] value, ColumnFamilyHandle cfHandle)
        {
            batch.Put(Encoding.UTF8.GetBytes(key), value, cfHandle);
        }

        public void Delete(string table, string key, ColumnFamilyHandle cfHandle)
        {
            batch.Delete(Encoding.UTF8.GetBytes(key), cfHandle);
        }

        public void Commit()
        {
            db.InnerDB.Write(batch);
            batch.Dispose();
        }
    }
}