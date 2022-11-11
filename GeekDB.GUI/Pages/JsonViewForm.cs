using Alex75.JsonViewer.WindowsForm;
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
using System.Xml.Linq;

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

        private void ExpandNode(TreeNode node, int num)
        {
            if (num <= 0)
                return;
            node.Expand();
            var childNodes = node.Nodes;
            var count = Math.Min(childNodes.Count, num);
            for (int i = 0; i < count; i++)
            {
                childNodes[i].Expand();
                ExpandNode(childNodes[i], num - 1);
            }
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

                ExpandNode(jsonTreeView.Nodes[0], 4);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to show JSON. " + exc);
            }
        }
    }
}
