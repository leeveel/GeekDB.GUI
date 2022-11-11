using Geek.Server;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekDB.GUI.Pages
{
    public partial class RocksDBDatasPage : UIPage
    {
        EmbeddedDB db;
        string tableName;

        class DataItem
        {
            public DataItem(string k, byte[] value)
            {
                Key = k;
                Data = value;
                DataJson = MessagePack.MessagePackSerializer.ConvertToJson(Data);
            }
            public string Key { get; set; }
            private byte[] Data { get; set; }
            public string DataJson { get; set; }
        }

        List<DataItem> datas = new List<DataItem>();
        List<DataItem> searchResults = new List<DataItem>();

        public RocksDBDatasPage(EmbeddedDB db, string name)
        {
            InitializeComponent();

            this.db = db;
            this.tableName = name;
            tableNameLable.Text = name;
            //读取所有数据
            var num = 0;
            var table = db.GetRawTable(name);
            if (table != null)
            {
                var iter = table.GetKVEnumerator();
                while (iter.MoveNext())
                {
                    datas.Add(new DataItem(iter.Key, iter.Current));
                    num++;
                }
            }

            this.dataCountLable.Text = num.ToString();
            searchResults.AddRange(datas);
            dataGridView.DataSource = searchResults;
            dataGridView.RowHeadersWidth = 100;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            var str = this.searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(str))
                return;
            var ids = str.Split(new char[] { ',', ';', '，', '；' });
            searchResults.Clear();
            foreach (var id in ids)
            {
                if (string.IsNullOrWhiteSpace(str))
                    continue;
                var idl = id.ToLower();
                var data = datas.Find(d => d.Key.ToLower().Contains(idl));
                if (data != null && searchResults.Find(d => d.Key.ToLower().Contains(idl)) == null)
                {
                    searchResults.Add(data);
                }
            }

            dataGridView.ClearAll();
            dataGridView.DataSource = searchResults;
            dataGridView.Refresh();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
            dataGridView.ClearAll();
            searchResults.Clear();
            searchResults.AddRange(datas);
            dataGridView.DataSource = searchResults;
            dataGridView.Refresh();
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
                var data = searchResults[e.RowIndex];
                new JsonViewForm(data.Key, data.DataJson).ShowDialog();
            }
        }
    }
}
