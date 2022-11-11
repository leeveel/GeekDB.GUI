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
    public partial class JsonViewForm : UIForm
    {
        public JsonViewForm(string title, string json)
        {
            InitializeComponent();
            this.Text = title;
            ShowJosn(json);
        }

        private void ShowJosn(string json)
        {
            try
            {
                if (json.StartsWith("["))
                {
                    json = "{\"\":" + json + "}";
                }
                jsonTreeView.ShowJson(json);
                jsonTreeView.ExpandAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to show JSON. " + exc);
            }
        }
    }
}
