using Geek.Server;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrightIdeasSoftware.TreeListView;

namespace GeekDB.GUI.Pages
{
    public partial class RocksDBDatasPage : UIPage
    {
        EmbeddedDB db;
        string tableName;
        long dbTotalCount = 0;
        long curQueryTotalCount;
        int onePageDataCount = 20;
        int curPageIndex = 0;

        class DataItem
        {
            public DataItem(byte[] keyBytes, byte[] value)
            {
                this.keyBytes = keyBytes;
                valueBytes = value;
            }

            private byte[] keyBytes { get; set; }
            private byte[] valueBytes { get; set; }
            [DisplayName("key")]
            public string Key
            {
                get
                {
                    return Encoding.UTF8.GetString(keyBytes);
                }
            }
            private string jsonStr = null;
            private string jsonPartStr = null;
            [DisplayName("value")]
            public string DataJsonPart
            {
                get
                {
                    if (jsonPartStr == null)
                    {
                        jsonStr = JsonText();
                        if (jsonStr.Length > 150)
                        {
                            jsonPartStr = jsonStr.Substring(0, 150) + "...";
                        }
                        else
                        {
                            jsonPartStr = jsonStr;
                        }
                    }
                    return jsonPartStr;
                }
            }

            public string JsonText()
            {
                if (jsonStr == null)
                {
                    try
                    {
                        jsonStr = MessagePack.MessagePackSerializer.ConvertToJson(valueBytes);
                    }
                    catch (Exception e)
                    {
                        jsonStr = UTF8Encoding.UTF8.GetString(valueBytes);
                    }
                }
                return jsonStr;
            }

            [DisplayName("size")]
            public string size
            {
                get
                {
                    string[] Suffix = { "b", "kb", "mb", "gb", "tb" };
                    int i = 0;
                    long bytes = valueBytes.LongLength;
                    double dblSByte = bytes;
                    if (bytes > 1024)
                        for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024)
                            dblSByte = bytes / 1024.0;
                    return String.Format("{0:0.##}{1}", dblSByte, Suffix[i]);
                }
            }
        }


        List<DataItem> sourceDatas = new();
        List<DataItem> searchResults;
        List<DataItem> showResults = new List<DataItem>();

        public RocksDBDatasPage(EmbeddedDB db, string name)
        {
            InitializeComponent();

            this.db = db;
            this.tableName = name;
            tableNameLable.Text = name;
            dbPathLable.Text = db.DbPath;
            //读取所有数据
            var num = 0;
            var table = db.GetRawTable(name);
            if (table != null)
            {
                var iter = table.GetKVEnumerator();
                while (iter.MoveNext())
                {
                    sourceDatas.Add(new DataItem(iter.KeyBytes, iter.Current));
                    num++;
                }
            }
            dbTotalCount = num;
            searchResults = new List<DataItem>(sourceDatas.Count);
            searchResults.AddRange(sourceDatas);
            //dataGridView.RowHeadersWidth = 60; 

            RefreshGridView();
        }

        void dataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= searchResults.Count)
                return;
            var data = searchResults[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = data.Key;
                    break;

                case 1:
                    e.Value = data.DataJsonPart;
                    break;
            }
        }

        void RefreshGridView(int pageIndex = 0)
        {
            this.curPageIndex = pageIndex;
            curQueryTotalCount = searchResults.Count;
            this.dataCountLable.Text = dbTotalCount.ToString();
            var startIndex = onePageDataCount * pageIndex;
            var curPageItemCount = Math.Min(onePageDataCount, curQueryTotalCount - startIndex);
            var endIndex = startIndex + curPageItemCount - 1;
            this.displayCountLable.Text = string.Format("displaying documents {0}-{1} of {2}", Math.Min(startIndex + 1, curQueryTotalCount), endIndex + 1, curQueryTotalCount);
            var isFirstPage = pageIndex == 0;
            var isLastPage = startIndex + curPageItemCount >= curQueryTotalCount;
            this.leftBtn.Enabled = !isFirstPage;
            this.rightBtn.Enabled = !isLastPage;

            showResults.Clear();
            for (int i = startIndex; i <= endIndex; i++)
            {
                showResults.Add(searchResults[i]);
            }
            dataGridView.ClearAll();
            dataGridView.DataSource = showResults;
            dataGridView.Refresh();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            var queryStr = this.searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(queryStr))
                return;

            searchResults.Clear();
            var keys = queryStr.Split(new char[] { ',', ';', '，', '；' });
            foreach (var key in keys)
            {
                if (string.IsNullOrWhiteSpace(key))
                    continue;
                var lkey = key.ToLower();
                foreach (var data in sourceDatas)
                {
                    if (data.Key.ToLower().Contains(lkey) || data.JsonText().ToLower().Contains(lkey))
                    {
                        if (searchResults.Find(d => d.Key == data.Key) == null)
                        {
                            searchResults.Add(data);
                        }
                    }
                }
            }

            RefreshGridView();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
            searchResults.Clear();
            searchResults.AddRange(sourceDatas);
            RefreshGridView();
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 1)
            {
                var data = showResults[e.RowIndex];
                new JsonViewForm(data.JsonText()).ShowDialog();
            }
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            curPageIndex = Math.Min(curPageIndex + 1, (int)(curQueryTotalCount / onePageDataCount));
            RefreshGridView(curPageIndex);
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            curPageIndex = Math.Max(curPageIndex - 1, 0);
            RefreshGridView(curPageIndex);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshGridView(0);
        }
    }
}
