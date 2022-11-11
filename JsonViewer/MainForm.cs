using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadJson("Data/Example 01.json");
        }

        private void LoadJson(string file)
        {
            try
            {
                var json = File.ReadAllText(file);
                jsonTreeView.ShowJson(json);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to show JSON. " + exc);
            }
        }

    }
}
