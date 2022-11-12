using Geek.Server;
using GeekDB.GUI.Logic;
using GeekDB.GUI.Pages;
using MessagePack;
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
        public static MainForm Instance { get; private set; }
        MainPage mainPage;
        Dictionary<string, Guid> tableName2Guid = new();
        List<Guid> openPageGuids = new List<Guid>();
        EmbeddedDB rockDb;

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

            var editorDbPath = System.IO.Path.GetTempPath() + "rocksdb_editor/db";
            editorDb = new EmbeddedDB(editorDbPath, false);

            EnterMainPage();
        }

        void ClearAll()
        {
            tableName2Guid.Clear();
            leftMenu.MenuItemClick -= OnHistoryMenuItemClick;
            leftMenu.MenuItemClick -= OnRocksDBMenuItemClick;
            leftMenu.NodeMouseDoubleClick -= OnHistoryMenuItemDoubleClick;
            leftMenu.ClearAll();
            if (rockDb != null)
            {
                rockDb.Close();
                rockDb = null;
            }

            foreach (var v in openPageGuids)
            {
                RemovePage(v);
            }
            openPageGuids.Clear();
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
            AddHistoryLeftMenu(mongodbHistory, "mongodb");
            AddHistoryLeftMenu(rocksdbHistory, "rocksdb");
            mainPage = new MainPage();
            AddPageWithGuid(mainPage, "Index", Guid.NewGuid());
            leftMenu.MenuItemClick += OnHistoryMenuItemClick;
            leftMenu.NodeMouseDoubleClick += OnHistoryMenuItemDoubleClick;
        }

        Table<HistoryItem> GetHistoryTable(string type)
        {
            return type == "mongodb" ? editorDb.GetTable<HistoryItem>("mongodb_history") : editorDb.GetTable<HistoryItem>("rocksdb_history");
        }

        void AddHistoryLeftMenu(TreeNode treeNode, string type)
        {
            var table = GetHistoryTable(type);
            var list = table.ToList();
            list.Sort((a, b) => a.time > b.time ? -1 : 1);
            foreach (var i in list)
            {
                var node = leftMenu.CreateChildNode(treeNode, i.pathOrUrl, int.MaxValue);
            }
            treeNode.ExpandAll();
        }

        public void AddHistory(string type, string urlOrPath)
        {
            var table = GetHistoryTable(type);
            table.Set(urlOrPath, new HistoryItem { pathOrUrl = urlOrPath, time = DateTime.Now });
        }

        public void RemoveHistory(string type, string urlOrPath)
        {
            var table = GetHistoryTable(type);
            table.Delete(urlOrPath);
        }

        public void UpdateHistory(string type, string urlOrPath)
        {
            RemoveHistory(type, urlOrPath);
            AddHistory(type, urlOrPath);
        }

        public void EnterRocksDBPage(string dbPath)
        {
            UpdateHistory("rocksdb", dbPath);
            ClearAll();

            //得到临时路径
            var tempPath = System.IO.Path.GetTempPath() + "rocksdb_editor/" + Path.GetFileName(dbPath) + "_temp";
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
            rockDb = new EmbeddedDB(dbPath, true, tempPath);

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
            ClearAll();
        }

        private void OnHistoryMenuItemDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node.Parent == null)
                return;
            if (node.Parent.Text.ToLower().Contains("mongodb"))
            {

            }
            else
            {
                if (!mainPage.TryEntryRocksDb(node.Text))
                {
                    RemoveHistory("rocksdb", node.Text);
                }
            }
        }
        private void OnHistoryMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node.Parent == null)
                return;
            if (node.Parent.Text.ToLower().Contains("mongodb"))
            {

            }
            else
            {
                mainPage.SetRocksDbPath(node.Text);
            }
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
                AddPageWithGuid(new RocksDBDatasPage(rockDb, node.Text), strs[strs.Length - 1], pageGuid);
                SelectPage(pageGuid);
            }
        }
    }
}
