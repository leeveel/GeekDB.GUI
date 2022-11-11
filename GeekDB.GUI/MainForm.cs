using Geek.Server;
using GeekDB.GUI.Logic;
using GeekDB.GUI.Pages;
using RocksDbSharp;
using Sunny.UI;
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
using static System.Windows.Forms.TabControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GeekDB.GUI
{
    public partial class MainForm : UIForm
    {
        public static MainForm Instance { get; private set; }
        Dictionary<string, Guid> tableName2Guid = new();
        List<Guid> openPageGuids = new List<Guid>();
        EmbeddedDB rockDb;
        public MainForm()
        {
            Instance = this;
            InitializeComponent();
            MainTabControl = TabControl;
            EnterMainPage();
        }

        void ClearAll()
        {
            tableName2Guid.Clear();
            leftMenu.MenuItemClick -= OnHistoryMenuItemClick;
            leftMenu.MenuItemClick -= OnRocksDBMenuItemClick;
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
                page.Text = tabText;
                AddPage(page, guid);
            }
        }

        public void EnterMainPage()
        {
            ClearAll();
            TabControl.TabVisible = false;
            int pageIndex = 1;
            TreeNode parent = leftMenu.CreateNode("最近打开", 61451, 24, pageIndex);
            AddPageWithGuid(new MainPage(), "Index", Guid.NewGuid());
        }

        public void EnterRocksDBPage(string dbPath)
        {
            ClearAll();

            //得到临时路径 
            rockDb = new EmbeddedDB(dbPath, true);

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
            leftMenu.ClearAll();
        }

        private void OnHistoryMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
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
            }
        }
    }
}
