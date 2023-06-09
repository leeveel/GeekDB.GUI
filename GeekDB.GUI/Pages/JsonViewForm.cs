using Newtonsoft.Json;
using Sunny.UI;
using System.Windows.Forms;

namespace GeekDB.GUI.Pages
{
    public sealed partial class JsonViewForm : UIForm
    {
        public JsonViewForm(string json)
        {
            KeyPreview = true;
            InitializeComponent();

            try
            {
                jTokenTree.SetJson(json);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, $"打开json错误:{e.Message}");
            }
        }


        private void jTokenTree_AfterSelect(object sender, JsonTreeView.AfterSelectEventArgs eventArgs)
        {
            if (!jsonValueTextBox.Focused)
            {
                jsonValueTextBox.Text = eventArgs.GetJsonString();
            }
        }

        private void JsonViewForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
