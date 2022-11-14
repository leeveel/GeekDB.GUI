using Geek.Server;
using Geek.Server.RemoteBackup.Logic;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SharpCompress.Writers;
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
        enum DataSourceType
        {
            DB,
            QueryResult
        }

        IMongoCollection<BsonDocument> dbCollection;
        string tableName;
        long dbTotalCount = 0;
        long curQueryTotalCount;
        int onePageDataCount = 20;
        int curPageIndex = 0;

        string curQueryStr = "{}";

        class DataItem
        {
            static JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson };
            public DataItem(BsonDocument Data)
            {
                this.Data = Data;
                Id = Data["_id"].ToString();
            }
            private BsonDocument Data { get; set; }
            private string jsonPartStr = null;
            public string Id { get; set; }
            public string DataJsonPart
            {
                get
                {
                    if (jsonPartStr == null)
                    {
                        jsonPartStr = Data.ToJson(jsonWriterSettings);
                        if (jsonPartStr.Length > 250)
                        {
                            jsonPartStr = jsonPartStr.Substring(0, 248) + "...";
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

        class RocksDbBackUpState
        {
            public string Id { get; set; }
            public long Timestamp { get; set; }
            public string Data { get; set; }
        }

        List<object> datas = new List<object>();

        public MongoDBDatasPage(IMongoCollection<BsonDocument> dbCollection, string dbName, string tableName)
        {
            InitializeComponent();

            this.dbCollection = dbCollection;
            this.tableName = tableName;
            this.dbPathLable.Text = dbName;
            tableNameLable.Text = tableName;
            indexCountLable.Text = dbCollection.Indexes.List().ToList().Count.ToString();
            refreshData();
        }

        void refreshData(int pageIndex = 0)
        {
            this.curPageIndex = pageIndex;
            try
            {
                curQueryTotalCount = dbCollection.CountDocuments(curQueryStr);

            }
            catch (Exception e)
            {
                UIMessageTip.ShowError(e.InnerException != null ? e.InnerException.Message : e.Message);
                curQueryTotalCount = 0;
            }

            if (dbTotalCount == 0)
            {
                dbTotalCount = curQueryTotalCount;
            }
            this.dataCountLable.Text = dbTotalCount.ToString();
            var startIndex = onePageDataCount * pageIndex;
            var curPageItemCount = Math.Min(onePageDataCount, curQueryTotalCount - startIndex);
            this.displayCountLable.Text = string.Format("displaying documents {0}-{1} of {2}", Math.Min(startIndex + 1, curQueryTotalCount), startIndex + curPageItemCount, curQueryTotalCount);
            var isFirstPage = pageIndex == 0;
            var isLastPage = startIndex + curPageItemCount >= curQueryTotalCount;
            this.leftBtn.Enabled = !isFirstPage;
            this.rightBtn.Enabled = !isLastPage;
            if (curQueryTotalCount > 0)
            {
                var result = dbCollection.Find(curQueryStr).Limit(onePageDataCount).Skip(startIndex).ToList();
                ParseQueryResult(result);
            }
            else
            {
                ParseQueryResult(new List<BsonDocument>());
            }
        }

        void ParseQueryResult(List<BsonDocument> result)
        {
            datas.Clear();
            foreach (var v in result)
            {
                try
                {
                    var value = BsonSerializer.Deserialize<MongoState>(v);
                    var state = new RocksDbBackUpState { Id = value.Id, Timestamp = value.Timestamp, Data = MessagePack.MessagePackSerializer.ConvertToJson(value.Data) };
                    datas.Add(state);
                }
                catch (Exception)
                {
                    datas.Add(new DataItem(v));
                }
            }
            dataGridView.ClearAll();
            dataGridView.DataSource = datas;
            dataGridView.Refresh();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            var query = this.searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(query))
            {
                UIMessageTip.ShowWarning("当前查询条件为空");
                return;
            }
            if (!query.StartsWith("{"))
                curQueryStr = "{ _id: " + query + "}";
            else
                curQueryStr = query;
            refreshData(0);
            UIMessageTip.ShowOk($"结果{curQueryTotalCount}条");
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
            curQueryStr = "{}";
            refreshData(0);
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.RowIndex >= datas.Count)
                return;
            if (e.ColumnIndex == 1)
            {
                var data = datas[e.RowIndex];
                if (data as DataItem != null)
                {
                    new JsonViewForm("", (data as DataItem).GetAllJson()).ShowDialog();
                }
            }
            else if (e.ColumnIndex == 2)
            {
                var data = datas[e.RowIndex];
                if (data is RocksDbBackUpState rdbs)
                {
                    new JsonViewForm("", rdbs.Data).ShowDialog();
                }
            }
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            curPageIndex = Math.Min(curPageIndex + 1, (int)(curQueryTotalCount / onePageDataCount));
            refreshData(curPageIndex);
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            curPageIndex = Math.Max(curPageIndex - 1, 0);
            refreshData(curPageIndex);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshData(0);
        }
    }
}
