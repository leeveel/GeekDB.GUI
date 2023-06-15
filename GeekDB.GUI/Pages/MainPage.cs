using Geek.Server;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            MainForm.Instance.EnterMongodbPage(this.mongodbURLTextBox.Text);
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

        public void TryEntryMongoDb()
        {

        }
        public void SetMongoDbPath(string path)
        {
            mongodbURLTextBox.Text = path;
        }

        public void SetRocksDbPath(string path)
        {
            rocksdbPathTextBox.Text = path;
        }

        private void selectRocksdbBuckupBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Filter = "备份压缩文件(*.zip)|*.zip";
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                rocksdbBackupTextBox.Text = fdlg.FileName;
            }
        }

        private void openRocksdbBackupBtn_Click(object sender, EventArgs e)
        {
            TryEntryRocksBackupDb(rocksdbBackupTextBox.Text);
        }

        public void TryEntryRocksBackupDb(string filePath)
        {
            try
            {
                //解压文件到临时目录
                var tempPath = Path.GetTempPath() + "rocksdb_editor/" + Path.GetFileName(filePath) + "_temp";
                var tempRestorePath = Path.GetDirectoryName(filePath) + "/" + Path.GetFileNameWithoutExtension(filePath) + "_export";

                CreateNewDir(tempPath);
                CreateNewDir(tempRestorePath);

                ZipFile.ExtractToDirectory(filePath, tempPath, false);
                DBBackup.Restore(tempPath, tempRestorePath);

                TryEntryRocksDb(tempRestorePath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void CreateNewDir(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }
    }
}
