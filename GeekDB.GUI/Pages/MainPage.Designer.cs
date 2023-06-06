namespace GeekDB.GUI.Pages
{
    partial class MainPage
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
            mongodbPanel = new Sunny.UI.UIPanel();
            mongodbConnectBtn = new Sunny.UI.UIButton();
            mongodbURLTextBox = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            rocksdbPanel = new Sunny.UI.UIPanel();
            rocksdbStartBtn = new Sunny.UI.UIButton();
            rocksdbSelectDirBtn = new Sunny.UI.UIButton();
            rocksdbPathTextBox = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            mongodbPanel.SuspendLayout();
            rocksdbPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mongodbPanel
            // 
            mongodbPanel.Controls.Add(mongodbConnectBtn);
            mongodbPanel.Controls.Add(mongodbURLTextBox);
            mongodbPanel.Controls.Add(uiLabel1);
            mongodbPanel.FillColor = Color.White;
            mongodbPanel.FillColor2 = Color.White;
            mongodbPanel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbPanel.Location = new Point(12, 107);
            mongodbPanel.Margin = new Padding(4, 5, 4, 5);
            mongodbPanel.MinimumSize = new Size(1, 1);
            mongodbPanel.Name = "mongodbPanel";
            mongodbPanel.RectColor = Color.White;
            mongodbPanel.RectDisableColor = Color.White;
            mongodbPanel.Size = new Size(799, 184);
            mongodbPanel.Style = Sunny.UI.UIStyle.Custom;
            mongodbPanel.TabIndex = 0;
            mongodbPanel.Text = null;
            mongodbPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // mongodbConnectBtn
            // 
            mongodbConnectBtn.FillColor = Color.FromArgb(0, 150, 136);
            mongodbConnectBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            mongodbConnectBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            mongodbConnectBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbConnectBtn.Location = new Point(695, 96);
            mongodbConnectBtn.MinimumSize = new Size(1, 1);
            mongodbConnectBtn.Name = "mongodbConnectBtn";
            mongodbConnectBtn.RectColor = Color.FromArgb(0, 150, 136);
            mongodbConnectBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            mongodbConnectBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.Size = new Size(100, 35);
            mongodbConnectBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            mongodbConnectBtn.StyleCustomMode = true;
            mongodbConnectBtn.TabIndex = 2;
            mongodbConnectBtn.Text = "Connect";
            mongodbConnectBtn.Click += mongodbConnectBtn_Click;
            // 
            // mongodbURLTextBox
            // 
            mongodbURLTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbURLTextBox.Location = new Point(4, 28);
            mongodbURLTextBox.Margin = new Padding(4, 5, 4, 5);
            mongodbURLTextBox.MinimumSize = new Size(1, 16);
            mongodbURLTextBox.Multiline = true;
            mongodbURLTextBox.Name = "mongodbURLTextBox";
            mongodbURLTextBox.Padding = new Padding(5);
            mongodbURLTextBox.RectColor = Color.Silver;
            mongodbURLTextBox.ShowText = false;
            mongodbURLTextBox.Size = new Size(794, 60);
            mongodbURLTextBox.Style = Sunny.UI.UIStyle.Custom;
            mongodbURLTextBox.StyleCustomMode = true;
            mongodbURLTextBox.TabIndex = 1;
            mongodbURLTextBox.Text = "mongodb://localhost:27017";
            mongodbURLTextBox.TextAlignment = ContentAlignment.TopLeft;
            mongodbURLTextBox.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(0, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(190, 23);
            uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "mongodb url:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rocksdbPanel
            // 
            rocksdbPanel.Controls.Add(rocksdbStartBtn);
            rocksdbPanel.Controls.Add(rocksdbSelectDirBtn);
            rocksdbPanel.Controls.Add(rocksdbPathTextBox);
            rocksdbPanel.Controls.Add(uiLabel2);
            rocksdbPanel.FillColor = Color.White;
            rocksdbPanel.FillColor2 = Color.White;
            rocksdbPanel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbPanel.Location = new Point(11, 271);
            rocksdbPanel.Margin = new Padding(4, 5, 4, 5);
            rocksdbPanel.MinimumSize = new Size(1, 1);
            rocksdbPanel.Name = "rocksdbPanel";
            rocksdbPanel.RectColor = Color.White;
            rocksdbPanel.Size = new Size(799, 189);
            rocksdbPanel.Style = Sunny.UI.UIStyle.Custom;
            rocksdbPanel.TabIndex = 1;
            rocksdbPanel.Text = null;
            rocksdbPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rocksdbStartBtn
            // 
            rocksdbStartBtn.FillColor = Color.FromArgb(0, 150, 136);
            rocksdbStartBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            rocksdbStartBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbStartBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbStartBtn.Location = new Point(695, 107);
            rocksdbStartBtn.MinimumSize = new Size(1, 1);
            rocksdbStartBtn.Name = "rocksdbStartBtn";
            rocksdbStartBtn.RectColor = Color.FromArgb(0, 150, 136);
            rocksdbStartBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbStartBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.Size = new Size(103, 35);
            rocksdbStartBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            rocksdbStartBtn.StyleCustomMode = true;
            rocksdbStartBtn.TabIndex = 6;
            rocksdbStartBtn.Text = "Open";
            rocksdbStartBtn.Click += rocksdbStartBtn_Click;
            // 
            // rocksdbSelectDirBtn
            // 
            rocksdbSelectDirBtn.FillColor = Color.FromArgb(0, 150, 136);
            rocksdbSelectDirBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            rocksdbSelectDirBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbSelectDirBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbSelectDirBtn.Location = new Point(570, 107);
            rocksdbSelectDirBtn.MinimumSize = new Size(1, 1);
            rocksdbSelectDirBtn.Name = "rocksdbSelectDirBtn";
            rocksdbSelectDirBtn.RectColor = Color.FromArgb(0, 150, 136);
            rocksdbSelectDirBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbSelectDirBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.Size = new Size(103, 35);
            rocksdbSelectDirBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            rocksdbSelectDirBtn.StyleCustomMode = true;
            rocksdbSelectDirBtn.TabIndex = 5;
            rocksdbSelectDirBtn.Text = "选择db";
            rocksdbSelectDirBtn.Click += rocksdbSelectDirBtn_Click;
            // 
            // rocksdbPathTextBox
            // 
            rocksdbPathTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbPathTextBox.Location = new Point(4, 28);
            rocksdbPathTextBox.Margin = new Padding(4, 5, 4, 5);
            rocksdbPathTextBox.MinimumSize = new Size(1, 16);
            rocksdbPathTextBox.Multiline = true;
            rocksdbPathTextBox.Name = "rocksdbPathTextBox";
            rocksdbPathTextBox.Padding = new Padding(5);
            rocksdbPathTextBox.RectColor = Color.Silver;
            rocksdbPathTextBox.ShowText = false;
            rocksdbPathTextBox.Size = new Size(794, 60);
            rocksdbPathTextBox.Style = Sunny.UI.UIStyle.Custom;
            rocksdbPathTextBox.StyleCustomMode = true;
            rocksdbPathTextBox.TabIndex = 4;
            rocksdbPathTextBox.TextAlignment = ContentAlignment.MiddleLeft;
            rocksdbPathTextBox.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(0, 0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(190, 23);
            uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            uiLabel2.TabIndex = 3;
            uiLabel2.Text = "rocksdb path:";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1306, 581);
            Controls.Add(rocksdbPanel);
            Controls.Add(mongodbPanel);
            ForeColor = Color.Black;
            Name = "MainPage";
            Style = Sunny.UI.UIStyle.Custom;
            mongodbPanel.ResumeLayout(false);
            rocksdbPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel mongodbPanel;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox mongodbURLTextBox;
        private Sunny.UI.UIButton mongodbConnectBtn;
        private Sunny.UI.UIPanel rocksdbPanel;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox rocksdbPathTextBox;
        private Sunny.UI.UIButton rocksdbSelectDirBtn;
        private Sunny.UI.UIButton rocksdbStartBtn;
    }
}