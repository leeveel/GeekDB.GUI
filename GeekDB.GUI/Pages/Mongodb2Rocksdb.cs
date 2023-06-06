using Geek.Server;
using Geek.Server.RemoteBackup.Logic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GeekDB.GUI.Pages
{
    public partial class Mongodb2Rocksdb : UIForm
    {
        IMongoDatabase mongoDBbase;
        string path;
        bool isExport;
        public Mongodb2Rocksdb(IMongoDatabase database)
        {
            this.mongoDBbase = database;
            InitializeComponent();
        }

        List<string> logs = new List<string>();
        List<Color> logColors = new List<Color>();
        void addLog(string txt)
        {
            addColorLog(txt, Color.Black);
        }

        void addErr(string txt)
        {
            addColorLog(txt, Color.Red);
        }

        void clearLog()
        {
            logs.Clear();
            logColors.Clear();
            logTxtbox.Lines = logs.ToArray();
        }

        void addColorLog(string txt, Color color)
        {
            if (logs.Count > 400)
            {
                logs.RemoveAt(0);
                logColors.RemoveAt(0);
            }
            logs.Add(txt);
            logColors.Add(color);
            logTxtbox.Lines = logs.ToArray();
            var charIndex = 0;
            for (int i = 0; i < logs.Count; i++)
            {
                logTxtbox.SelectionStart = charIndex;
                logTxtbox.SelectionLength = logs[i].Length;
                logTxtbox.SelectionColor = logColors[i];
                charIndex += logs[i].Length + 1;
            }
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
            await export();
            isExport = false;
        }

        EmbeddedDB rocksDb;
        async Task export()
        {
            await Task.Run(() =>
            {
                try
                {
                    rocksDb = new EmbeddedDB(path);
                    var tableNames = mongoDBbase.ListCollectionNames().ToList();
                    foreach (var name in tableNames)
                    {
                        addLog("开始导出" + name);
                        var rocksdbTable = rocksDb.GetRawTable(name);
                        var mongoTable = mongoDBbase.GetCollection<BsonDocument>(name);
                        var mongoQueryStr = "{}";
                        var totalCount = mongoTable.CountDocuments(mongoQueryStr);
                        int startIndex = 0;
                        while (startIndex < totalCount)
                        {
                            if (rocksDb == null)
                            {
                                return;
                            }
                            var everyTimeQueryCount = 200;
                            var result = mongoTable.Find(mongoQueryStr).Limit(everyTimeQueryCount).Skip(startIndex).ToList();
                            startIndex += everyTimeQueryCount;
                            foreach (var data in result)
                            {
                                try
                                {
                                    var value = BsonSerializer.Deserialize<MongoState>(data);
                                    rocksdbTable.SetRaw(value.Id, value.Data);
                                }
                                catch (Exception e)
                                {
                                    addErr($"导出数据出错:{e.Message}");
                                    return;
                                }
                            }
                        }

                        addLog($"导出{name}完成,共导出{totalCount}条数据");
                    }
                }
                finally
                {
                    if (rocksDb != null)
                    {
                        rocksDb.Close();
                        rocksDb = null;
                    }
                }
            });
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (rocksDb != null)
            {
                rocksDb.Close();
                rocksDb = null;
            }
            base.OnFormClosed(e);
        }
    }
}
