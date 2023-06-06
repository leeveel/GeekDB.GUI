using Alex75.JsonViewer.WindowsForm;

namespace GeekDB.GUI.Pages
{
    partial class JsonViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            jsonTreeView = new JsonTreeView();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // jsonTreeView
            // 
            jsonTreeView.BorderStyle = BorderStyle.None;
            jsonTreeView.Dock = DockStyle.Fill;
            jsonTreeView.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            jsonTreeView.ForeColor = Color.Black;
            jsonTreeView.FullRowSelect = true;
            jsonTreeView.HideSelection = false;
            jsonTreeView.ImageIndex = 0;
            jsonTreeView.Location = new Point(0, 0);
            jsonTreeView.Margin = new Padding(2);
            jsonTreeView.Name = "jsonTreeView";
            jsonTreeView.SelectedImageIndex = 0;
            jsonTreeView.ShowNodeToolTips = true;
            jsonTreeView.ShowRootLines = false;
            jsonTreeView.Size = new Size(770, 539);
            jsonTreeView.TabIndex = 0;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(jsonTreeView);
            uiPanel1.Dock = DockStyle.Fill;
            uiPanel1.FillColor = Color.FromArgb(238, 248, 248);
            uiPanel1.FillColor2 = Color.FromArgb(238, 248, 248);
            uiPanel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiPanel1.Location = new Point(2, 29);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RectColor = Color.FromArgb(0, 150, 136);
            uiPanel1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel1.Size = new Size(770, 539);
            uiPanel1.Style = Sunny.UI.UIStyle.LayuiGreen;
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // JsonViewForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(238, 248, 248);
            ClientSize = new Size(774, 570);
            ControlBoxFillHoverColor = Color.FromArgb(51, 171, 160);
            Controls.Add(uiPanel1);
            EscClose = true;
            Name = "JsonViewForm";
            Padding = new Padding(2, 29, 2, 2);
            RectColor = Color.FromArgb(0, 150, 136);
            ShowDragStretch = true;
            ShowIcon = false;
            ShowRadius = false;
            Style = Sunny.UI.UIStyle.LayuiGreen;
            Text = "JsonView";
            TitleColor = Color.FromArgb(0, 150, 136);
            TitleFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TitleHeight = 29;
            ZoomScaleRect = new Rectangle(15, 15, 520, 505);
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private JsonTreeView jsonTreeView;
        private Sunny.UI.UIPanel uiPanel1;
    }
}