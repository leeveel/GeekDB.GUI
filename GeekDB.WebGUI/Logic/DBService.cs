using GeekDB.Core;

namespace GeekDB.WebGUI.Logic
{
    public class DBService
    {
        public EmbeddedDB db { get; private set; }
        public DBService()
        {
            db = new EmbeddedDB(Settings.LocalDBPath + Settings.LocalDBPrefix + Settings.ServerId);
        }

        public T GetData<T>(string key) where T : class
        {
            return db.GetTable<T>().Get(key);
        }

        public T[] GetAllData<T>() where T : class
        {
            return db.GetTable<T>().ToArray();
        }

        public void UpdateData<T>(string key, T data) where T : class
        {
            db.GetTable<T>().Set(key, data);
        }

        public void DeleteData<T>(string key) where T : class
        {
            db.GetTable<T>().Delete(key);
        }
    }
}
