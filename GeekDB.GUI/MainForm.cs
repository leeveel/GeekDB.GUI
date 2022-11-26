using Geek.Server;
using GeekDB.GUI.Pages;
using MessagePack;
using MongoDB.Bson;
using MongoDB.Driver;
using RocksDbSharp;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.TabControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GeekDB.GUI
{
    public partial class MainForm : UIForm
    {
        public enum DBType
        {
            MongoDb,
            RocksDb
        }

        public static MainForm Instance { get; private set; }
        MainPage mainPage;
        Dictionary<string, Guid> tableName2Guid = new();
        List<Guid> openPageGuids = new List<Guid>();
        EmbeddedDB curRockDb;
        Dictionary<string, MongoClient> allMongodbClient = new();
        string curMongoDBUrl = "";
        MongoClient curMongoDbClient;

        [MessagePackObject(true)]
        public class HistoryItem
        {
            public string pathOrUrl;
            public DateTime time;
        }

        EmbeddedDB editorDb;
        public MainForm()
        {
            Instance = this;
            InitializeComponent();
            MainTabControl = TabControl;

            EnterMainPage();
        }

        void ClearAll()
        {
            leftMenu.MenuItemClick -= OnHistoryMenuItemClick;
            leftMenu.MenuItemClick -= OnRocksDBMenuItemClick;
            leftMenu.MenuItemClick -= OnMongoDBMenuItemClick;
            leftMenu.NodeMouseDoubleClick -= OnHistoryMenuItemDoubleClick;
            leftMenu.NodeRightSymbolClick -= OnHistoryNodeRightSymbolClick;

            MainTabControl.AutoClosePage = true;
            foreach (var v in openPageGuids)
            {
                RemovePage(v);
            }
            MainTabControl.TabPages.Clear();
            MainTabControl.Refresh();

            leftMenu.ClearAll();
            tableName2Guid.Clear();
            openPageGuids.Clear();

            if (curRockDb != null)
            {
                curRockDb.Close();
                curRockDb = null;
            }
        }

        Table<HistoryItem> GetHistoryTable(DBType type)
        {
            //每次重新打开，可能会存在多个编辑器实例情况
            var editorDbPath = System.IO.Path.GetTempPath() + "rocksdb_editor/db";
            if (editorDb == null)
            {
                editorDb = new EmbeddedDB(editorDbPath, false);
            }
            return type == DBType.MongoDb ? editorDb.GetTable<HistoryItem>("mongodb_history") : editorDb.GetTable<HistoryItem>("rocksdb_history");
        }

        void ReleaseEditorDB()
        {
            if (editorDb != null)
            {
                editorDb.Close();
                editorDb = null;
            }
        }

        void AddHistoryLeftMenu(TreeNode treeNode, DBType type)
        {
            var table = GetHistoryTable(type);
            var list = table.ToList();
            list.Sort((a, b) => a.time > b.time ? -1 : 1);
            foreach (var i in list)
            {
                var node = leftMenu.CreateChildNode(treeNode, i.pathOrUrl, int.MaxValue);
            }
            treeNode.ExpandAll();
            ReleaseEditorDB();
        }

        public void AddHistory(DBType type, string urlOrPath)
        {
            var table = GetHistoryTable(type);
            table.Set(urlOrPath, new HistoryItem { pathOrUrl = urlOrPath, time = DateTime.Now });
            ReleaseEditorDB();
        }

        public void RemoveHistory(DBType type, string urlOrPath)
        {
            var table = GetHistoryTable(type);
            table.Delete(urlOrPath);
            ReleaseEditorDB();
        }

        public void UpdateHistory(DBType type, string urlOrPath)
        {
            var table = GetHistoryTable(type);
            table.Delete(urlOrPath);
            table.Set(urlOrPath, new HistoryItem { pathOrUrl = urlOrPath, time = DateTime.Now });
            ReleaseEditorDB();
        }

        void AddPageWithGuid(UIPage page, string tabText, Guid guid)
        {
            if (openPageGuids.IndexOf(guid) < 0)
            {
                openPageGuids.Add(guid);
            }
            if (!ExistPage(guid))
            {
                page.Text = tabText.Length > 14 ? tabText.Substring(0, 13) + "..." : tabText;
                AddPage(page, guid);
            }
        }

        public void EnterMainPage()
        {
            ClearAll();
            TabControl.TabVisible = false;
            TreeNode mongodbHistory = leftMenu.CreateNode("mongodb打开历史", 61451, 24, int.MaxValue);
            TreeNode rocksdbHistory = leftMenu.CreateNode("rocksdb打开历史", 61451, 24, int.MaxValue);
            AddHistoryLeftMenu(mongodbHistory, DBType.MongoDb);
            AddHistoryLeftMenu(rocksdbHistory, DBType.RocksDb);
            mainPage = new MainPage();
            AddPageWithGuid(mainPage, "index", Guid.NewGuid());
            leftMenu.MenuItemClick += OnHistoryMenuItemClick;
            leftMenu.NodeMouseDoubleClick += OnHistoryMenuItemDoubleClick;
            leftMenu.NodeRightSymbolClick += OnHistoryNodeRightSymbolClick;
        }

        public void EnterRocksDBPage(string dbPath)
        {
            UpdateHistory(DBType.RocksDb, dbPath);
            ClearAll();

            //得到临时路径
            var tempPath = Path.GetTempPath() + "rocksdb_editor/" + Path.GetFileName(dbPath) + "_temp";
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
            curRockDb = new EmbeddedDB(dbPath, true, tempPath);

            TabControl.TabVisible = true;
            var parent = leftMenu.CreateNode(Path.GetFileName(dbPath), int.MaxValue);
            var tables = Helper.GetAllTableNames(dbPath);
            foreach (var name in tables)
            {
                var guid = Guid.NewGuid();
                tableName2Guid[name] = guid;
                var tabelNode = leftMenu.CreateChildNode(parent, name, guid);
            }
            parent.Expand();
            leftMenu.MenuItemClick += OnRocksDBMenuItemClick;
        }

        public void EnterMongodbPage(string url)
        {
            var dbNames = new List<string>();
            if (allMongodbClient.ContainsKey(url))
            {
                curMongoDbClient = allMongodbClient[url];
                dbNames = curMongoDbClient.ListDatabaseNames().ToList();
            }
            else
            {
                try
                {
                    var settings = MongoClientSettings.FromConnectionString(url);
                    curMongoDbClient = new MongoClient(settings);
                    dbNames = curMongoDbClient.ListDatabaseNames().ToList();
                    allMongodbClient[url] = curMongoDbClient;
                    curMongoDBUrl = url;
                }
                catch (Exception e)
                {
                    UIMessageTip.ShowError(e.Message);
                    return;
                }
            }
            ClearAll();
            UpdateHistory(DBType.MongoDb, url);
            TabControl.TabVisible = true;

            foreach (var n in dbNames)
            {
                var parent = leftMenu.CreateNode(n, int.MaxValue);
                var db = curMongoDbClient.GetDatabase(n);
                var tables = db.ListCollectionNames().ToList();
                foreach (var t in tables)
                {
                    var guid = Guid.NewGuid();
                    tableName2Guid[n + "_" + t] = guid;
                    var tabelNode = leftMenu.CreateChildNode(parent, t, guid);
                }
            }
            leftMenu.MenuItemClick += OnMongoDBMenuItemClick;
        }

        private void OnHistoryNodeRightSymbolClick(object sender, TreeNode node, int index, int symbol)
        {
            RemoveHistory(node.Parent.Text.ToLower().Contains("mongodb") ? DBType.MongoDb : DBType.RocksDb, node.Text);
            node.Remove();
        }

        private void OnHistoryMenuItemDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node.Parent == null)
                return;

            RemoveAllNodeRightSymbol();

            if (node.Parent.Text.ToLower().Contains("mongodb"))
            {
                mainPage.SetMongoDbPath(node.Text);
                EnterMongodbPage(node.Text);
            }
            else
            {
                if (!mainPage.TryEntryRocksDb(node.Text))
                {
                    RemoveHistory(DBType.RocksDb, node.Text);
                    node.Remove();
                }
            }
        }

        private void RemoveAllNodeRightSymbol()
        {
            foreach (var parent in leftMenu.Nodes)
            {
                foreach (var n in (parent as TreeNode).Nodes)
                {
                    leftMenu.ClearNodeRightSymbol(n as TreeNode);
                }
            }
        }

        private void OnHistoryMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node.Parent == null)
                return;

            RemoveAllNodeRightSymbol();

            if (node.Parent.Text.ToLower().Contains("mongodb"))
            {
                mainPage.SetMongoDbPath(node.Text);
            }
            else
            {
                mainPage.SetRocksDbPath(node.Text);
            }

            leftMenu.AddNodeRightSymbol(node, 61453);
        }

        private void OnRocksDBMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (item.PageIndex == int.MaxValue)
                return;
            var tableName = node.Text;
            var pageGuid = tableName2Guid[tableName];
            if (ExistPage(pageGuid))
            {
                SelectPage(pageGuid);
            }
            else
            {
                var strs = tableName.Split(new char[] { '.' });
                AddPageWithGuid(new RocksDBDatasPage(curRockDb, node.Text), strs[strs.Length - 1], pageGuid);
                SelectPage(pageGuid);
            }
        }

        private void OnMongoDBMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (item.PageIndex == int.MaxValue)
                return;
            var dbName = node.Parent.Text;
            var tableName = node.Text;
            var pageGuid = tableName2Guid[dbName + "_" + tableName];
            if (ExistPage(pageGuid))
            {
                SelectPage(pageGuid);
            }
            else
            {
                var strs = tableName.Split(new char[] { '.' });
                var db = curMongoDbClient.GetDatabase(dbName);
                AddPageWithGuid(new MongoDBDatasPage(db.GetCollection<BsonDocument>(tableName), curMongoDBUrl + "   " + dbName, tableName), strs[strs.Length - 1], pageGuid);
                SelectPage(pageGuid);
            }
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterMainPage();
        }
    }
}
