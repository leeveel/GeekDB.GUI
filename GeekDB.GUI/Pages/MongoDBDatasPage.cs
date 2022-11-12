﻿using Geek.Server;
using MongoDB.Bson;
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

namespace GeekDB.GUI.Pages
{
    public partial class MongoDBDatasPage : UIPage
    {
        IMongoCollection<BsonDocument> dbCollection;
        string tableName;

        class DataItem
        {
            public DataItem(string k, byte[] value)
            {
                Key = k;
                Data = value;
            }
            [DisplayName("key")]
            public string Key { get; set; }
            private byte[] Data { get; set; }
            private string jsonStr = null;
            private string jsonPartStr = null;
            [DisplayName("value")]
            public string DataJsonPart
            {
                get
                {
                    if (jsonStr == null)
                    {
                        jsonStr = MessagePack.MessagePackSerializer.ConvertToJson(Data);
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

            public string GetAllJson()
            {
                return jsonStr;
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
            this.dataCountLable.Text = dbCollection.CountDocuments(new BsonDocument()).ToString();
            //读取所有数据
            //var num = 0;
            //var table = db.GetRawTable(name);
            //if (table != null)
            //{
            //    var iter = table.GetKVEnumerator();
            //    while (iter.MoveNext())
            //    {
            //        datas.Add(new DataItem(iter.Key, iter.Current));
            //        num++;
            //    }
            //}

            //this.dataCountLable.Text = num.ToString();
            //searchResults.AddRange(datas);
            //dataGridView.DataSource = searchResults;
            //dataGridView.RowHeadersWidth = 100;
            ////dataGridView.SetRowHeight(45);
            ////dataGridView.Columns[0].Width = 200;
            ////dataGridView.Columns[1].Width = 1000;
            //dataGridView.Columns[1].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
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
                foreach (var data in datas)
                {
                    if (data.Key.ToLower().Contains(idl))
                    {
                        if (searchResults.Find(d => d.Key == data.Key) == null)
                        {
                            searchResults.Add(data);
                        }
                    }
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
                new JsonViewForm(data.Key, data.GetAllJson()).ShowDialog();
            }
        }
    }
}
