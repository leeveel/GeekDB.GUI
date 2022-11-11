using GeekDB.GUI.Logic;
using GeekDB.GUI.Pages;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekDB.GUI
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            MainTabControl = TabControl;
            leftMenu.MenuItemClick += OnMenuItemClick;
            EnterMainPage();
        }

        void EnterMainPage()
        {
            TabControl.TabVisible = false;
            leftMenu.ClearAll();
            int pageIndex = 1;
            TreeNode parent = leftMenu.CreateNode("最近打开", 61451, 24, pageIndex);

            AddPage(new MainPage());
        }

        void EnterRocksDBPage(string dbPath)
        {

        }

        void EnterMongodbPage(string url)
        {

        }

        private void OnMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
