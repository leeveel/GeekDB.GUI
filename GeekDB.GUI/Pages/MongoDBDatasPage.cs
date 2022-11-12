using Geek.Server;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MongoDB.Driver.WriteConcern;

namespace GeekDB.GUI.Pages
{
    public partial class MongoDBDatasPage : UIPage
    {
        IMongoCollection<BsonDocument> dbCollection;
        string tableName;
        long count;
        int pageCount = 20;
        class DataItem
        {
            static JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };
            public DataItem(BsonDocument Data)
            {
                this.Data = Data;
            }
            private BsonDocument Data { get; set; }
            private string jsonPartStr = null;
            [DisplayName("value")]
            public string DataJsonPart
            {
                get
                {
                    if (jsonPartStr == null)
                    {
                        jsonPartStr = Data.ToJson(jsonWriterSettings);
                        if (jsonPartStr.Length > 150)
                        {
                            jsonPartStr = jsonPartStr.Substring(0, 150) + "...";
                        }
                    }
                    return jsonPartStr;
                }
            }

            public string GetAllJson()
            {
                return Data.ToJson(jsonWriterSettings);
            }
        }

        List<DataItem> datas = new List<DataItem>();
        List<DataItem> searchResults = new List<DataItem>();

        public MongoDBDatasPage(IMongoCollection<BsonDocument> dbCollection, string dbName, string tableName)
        {
            InitializeComponent();

            this.dbCollection = dbCollection;
            this.tableName = tableName;
            this.dbPathLable.Text = dbName;
            tableNameLable.Text = tableName;
            refrshData();

            //this.dataCountLable.Text = num.ToString();
            //searchResults.AddRange(datas);
            //dataGridView.DataSource = searchResults;
            //dataGridView.RowHeadersWidth = 100;
            ////dataGridView.SetRowHeight(45);
            ////dataGridView.Columns[0].Width = 200;
            ////dataGridView.Columns[1].Width = 1000;
            //dataGridView.Columns[1].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
        }

        void refrshData(int pageIndex = 0)
        {
            count = dbCollection.CountDocuments(new BsonDocument());
            this.dataCountLable.Text = count.ToString();
            var startIndex = pageCount * pageIndex;
            //limit skip 
            var result = dbCollection.Find(new BsonDocument()).Limit(pageCount).Skip(startIndex).ToList();
            datas.Clear();
            foreach (var v in result)
            {
                datas.Add(new DataItem(v));
            }
            dataGridView.DataSource = datas;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            refrshData(0);
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                var data = datas[e.RowIndex];
                new JsonViewForm("", data.GetAllJson()).ShowDialog();
            }
        }
    }
}
