using GeekDB.GUI.Logic;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GeekDB.GUI.Pages
{
    public partial class MainPage : UIPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Text = "MainPage";
        }

        private void mongodbConnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void rocksdbSelectDirBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.rocksdbPathTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void rocksdbStartBtn_Click(object sender, EventArgs e)
        {
            TryEntryRocksDb(rocksdbPathTextBox.Text);
        }

        public bool TryEntryRocksDb(string path)
        {
            rocksdbPathTextBox.Text = path;
            if (Helper.IsRocksDB(path))
            {
                MainForm.Instance.EnterRocksDBPage(path);
                return true;
            }
            else
            {
                rocksdbPathTextBox.Text = "";
                UIMessageTip.ShowError("选择路径不是有效的rocksdb路径");
                return false;
            }
        }

        public void SetRocksDbPath(string path)
        {
            rocksdbPathTextBox.Text = path;
        }
    }
}
