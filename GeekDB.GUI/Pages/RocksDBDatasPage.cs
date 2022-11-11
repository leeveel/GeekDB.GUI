using Geek.Server;
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
                DataJsonStr = MessagePack.MessagePackSerializer.ConvertToJson(Data);
            }
            public string Key { get; set; }
            private byte[] Data { get; set; }
            public string DataJsonStr { get; set; }
        }

        List<DataItem> datas = new List<DataItem>();

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

            dataGridView.DataSource = datas;

        }
    }
}
