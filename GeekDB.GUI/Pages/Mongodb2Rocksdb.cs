using GeekDB.Core;
using MessagePack;
using MessagePack.Resolvers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Sunny.UI;
using System.Collections;

namespace GeekDB.GUI.Pages
{
    public partial class Mongodb2Rocksdb : UIForm
    {
        IMongoDatabase mongoDBbase;
        string path;
        //string externDllPath;
        bool isExport;
        public Mongodb2Rocksdb(IMongoDatabase database)
        {
            this.mongoDBbase = database;
            InitializeComponent();
            this.DoubleBuffered = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        void addLog(string txt)
        {
            addColorLog(txt, Color.Black);
        }

        void addImportantLog(string txt)
        {
            addColorLog(txt, Color.Blue);
        }

        void addErr(string txt)
        {
            addColorLog(txt, Color.Red);
        }

        void clearLog()
        {
            logTxtbox.Text = "";
        }

        void addColorLog(string txt, Color color)
        {
            var charIndex = logTxtbox.Text.Length;
            logTxtbox.AppendText(txt + "\n");
            logTxtbox.SelectionStart = charIndex;
            logTxtbox.SelectionLength = txt.Length;
            logTxtbox.SelectionColor = color;

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    this.pathLable.Text = path;
                }
            }
        }


        private async void exportBtn_ClickAsync(object sender, EventArgs e)
        {
            if (isExport)
                return;
            clearLog();
            if (string.IsNullOrEmpty(path))
            {
                addErr($"路径不存在:{path}");
                return;
            }

            if (Directory.GetDirectories(path).Length > 0 || Directory.GetFiles(path).Length > 0)
            {
                addErr($"导出失败,目录不为空:{path}");
                return;
            }

            isExport = true;
            await new MongoDbConvertToRocksdb().Run(mongoDBbase, path, (t, s) => { if (t == LogType.Info) addLog(s); if (t == LogType.Err) addErr(s); }, UpdateProcess);
            isExport = false;
        }

        void UpdateProcess(float max, float curr)
        {
            processBar.Maximum = (int)(max * 100);
            processBar.Value = (int)(curr * 100);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = true;
            base.OnFormClosed(e);
        }

        private void Mongodb2Rocksdb_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isExport;
            if (isExport)
            {
                MessageBox.Show("导出中...不能关闭...");
            }
        }
    }
}
