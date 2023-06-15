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
            mongodbURLTextBox = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            mongodbConnectBtn = new Sunny.UI.UIButton();
            rocksdbPanel = new Sunny.UI.UIPanel();
            rocksdbStartBtn = new Sunny.UI.UIButton();
            rocksdbPathTextBox = new Sunny.UI.UITextBox();
            rocksdbSelectDirBtn = new Sunny.UI.UIButton();
            uiLabel2 = new Sunny.UI.UILabel();
            uiPanel1 = new Sunny.UI.UIPanel();
            openRocksdbBackupBtn = new Sunny.UI.UIButton();
            rocksdbBackupTextBox = new Sunny.UI.UITextBox();
            selectRocksdbBuckupBtn = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            mongodbPanel.SuspendLayout();
            rocksdbPanel.SuspendLayout();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mongodbPanel
            // 
            mongodbPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mongodbPanel.Controls.Add(mongodbURLTextBox);
            mongodbPanel.Controls.Add(uiLabel1);
            mongodbPanel.Controls.Add(mongodbConnectBtn);
            mongodbPanel.FillColor = Color.White;
            mongodbPanel.FillColor2 = Color.White;
            mongodbPanel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbPanel.Location = new Point(12, 57);
            mongodbPanel.Margin = new Padding(4, 5, 4, 5);
            mongodbPanel.MinimumSize = new Size(1, 1);
            mongodbPanel.Name = "mongodbPanel";
            mongodbPanel.RectColor = Color.White;
            mongodbPanel.RectDisableColor = Color.White;
            mongodbPanel.Size = new Size(1270, 154);
            mongodbPanel.Style = Sunny.UI.UIStyle.Custom;
            mongodbPanel.TabIndex = 0;
            mongodbPanel.Text = null;
            mongodbPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // mongodbURLTextBox
            // 
            mongodbURLTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mongodbURLTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbURLTextBox.Location = new Point(4, 28);
            mongodbURLTextBox.Margin = new Padding(4, 5, 4, 5);
            mongodbURLTextBox.MinimumSize = new Size(1, 16);
            mongodbURLTextBox.Multiline = true;
            mongodbURLTextBox.Name = "mongodbURLTextBox";
            mongodbURLTextBox.Padding = new Padding(5);
            mongodbURLTextBox.RectColor = Color.Silver;
            mongodbURLTextBox.ShowText = false;
            mongodbURLTextBox.Size = new Size(1262, 60);
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
            // mongodbConnectBtn
            // 
            mongodbConnectBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mongodbConnectBtn.FillColor = Color.FromArgb(0, 150, 136);
            mongodbConnectBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            mongodbConnectBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            mongodbConnectBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            mongodbConnectBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mongodbConnectBtn.Location = new Point(1167, 96);
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
            // rocksdbPanel
            // 
            rocksdbPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rocksdbPanel.Controls.Add(rocksdbStartBtn);
            rocksdbPanel.Controls.Add(rocksdbPathTextBox);
            rocksdbPanel.Controls.Add(rocksdbSelectDirBtn);
            rocksdbPanel.Controls.Add(uiLabel2);
            rocksdbPanel.FillColor = Color.White;
            rocksdbPanel.FillColor2 = Color.White;
            rocksdbPanel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbPanel.Location = new Point(11, 232);
            rocksdbPanel.Margin = new Padding(4, 5, 4, 5);
            rocksdbPanel.MinimumSize = new Size(1, 1);
            rocksdbPanel.Name = "rocksdbPanel";
            rocksdbPanel.RectColor = Color.White;
            rocksdbPanel.Size = new Size(1271, 153);
            rocksdbPanel.Style = Sunny.UI.UIStyle.Custom;
            rocksdbPanel.TabIndex = 1;
            rocksdbPanel.Text = null;
            rocksdbPanel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rocksdbStartBtn
            // 
            rocksdbStartBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rocksdbStartBtn.FillColor = Color.FromArgb(0, 150, 136);
            rocksdbStartBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            rocksdbStartBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbStartBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbStartBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbStartBtn.Location = new Point(1164, 96);
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
            // rocksdbPathTextBox
            // 
            rocksdbPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rocksdbPathTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbPathTextBox.Location = new Point(4, 28);
            rocksdbPathTextBox.Margin = new Padding(4, 5, 4, 5);
            rocksdbPathTextBox.MinimumSize = new Size(1, 16);
            rocksdbPathTextBox.Multiline = true;
            rocksdbPathTextBox.Name = "rocksdbPathTextBox";
            rocksdbPathTextBox.Padding = new Padding(5);
            rocksdbPathTextBox.RectColor = Color.Silver;
            rocksdbPathTextBox.ShowText = false;
            rocksdbPathTextBox.Size = new Size(1263, 60);
            rocksdbPathTextBox.Style = Sunny.UI.UIStyle.Custom;
            rocksdbPathTextBox.StyleCustomMode = true;
            rocksdbPathTextBox.TabIndex = 4;
            rocksdbPathTextBox.TextAlignment = ContentAlignment.MiddleLeft;
            rocksdbPathTextBox.Watermark = "";
            // 
            // rocksdbSelectDirBtn
            // 
            rocksdbSelectDirBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rocksdbSelectDirBtn.FillColor = Color.FromArgb(0, 150, 136);
            rocksdbSelectDirBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            rocksdbSelectDirBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            rocksdbSelectDirBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            rocksdbSelectDirBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbSelectDirBtn.Location = new Point(1039, 96);
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
            // uiPanel1
            // 
            uiPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uiPanel1.Controls.Add(openRocksdbBackupBtn);
            uiPanel1.Controls.Add(rocksdbBackupTextBox);
            uiPanel1.Controls.Add(selectRocksdbBuckupBtn);
            uiPanel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiPanel1.Location = new Point(11, 422);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiPanel1.RectColor = Color.Transparent;
            uiPanel1.Size = new Size(1267, 163);
            uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            uiPanel1.TabIndex = 2;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // openRocksdbBackupBtn
            // 
            openRocksdbBackupBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openRocksdbBackupBtn.FillColor = Color.FromArgb(0, 150, 136);
            openRocksdbBackupBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            openRocksdbBackupBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            openRocksdbBackupBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            openRocksdbBackupBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            openRocksdbBackupBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            openRocksdbBackupBtn.Location = new Point(1164, 73);
            openRocksdbBackupBtn.MinimumSize = new Size(1, 1);
            openRocksdbBackupBtn.Name = "openRocksdbBackupBtn";
            openRocksdbBackupBtn.RectColor = Color.FromArgb(0, 150, 136);
            openRocksdbBackupBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            openRocksdbBackupBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            openRocksdbBackupBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            openRocksdbBackupBtn.Size = new Size(103, 35);
            openRocksdbBackupBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            openRocksdbBackupBtn.StyleCustomMode = true;
            openRocksdbBackupBtn.TabIndex = 8;
            openRocksdbBackupBtn.Text = "Open";
            openRocksdbBackupBtn.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            openRocksdbBackupBtn.Click += openRocksdbBackupBtn_Click;
            // 
            // rocksdbBackupTextBox
            // 
            rocksdbBackupTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rocksdbBackupTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rocksdbBackupTextBox.Location = new Point(5, 5);
            rocksdbBackupTextBox.Margin = new Padding(4, 5, 4, 5);
            rocksdbBackupTextBox.MinimumSize = new Size(1, 16);
            rocksdbBackupTextBox.Multiline = true;
            rocksdbBackupTextBox.Name = "rocksdbBackupTextBox";
            rocksdbBackupTextBox.Padding = new Padding(5);
            rocksdbBackupTextBox.RectColor = Color.Silver;
            rocksdbBackupTextBox.ShowText = false;
            rocksdbBackupTextBox.Size = new Size(1258, 60);
            rocksdbBackupTextBox.Style = Sunny.UI.UIStyle.Custom;
            rocksdbBackupTextBox.StyleCustomMode = true;
            rocksdbBackupTextBox.TabIndex = 5;
            rocksdbBackupTextBox.TextAlignment = ContentAlignment.MiddleLeft;
            rocksdbBackupTextBox.Watermark = "";
            // 
            // selectRocksdbBuckupBtn
            // 
            selectRocksdbBuckupBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectRocksdbBuckupBtn.FillColor = Color.FromArgb(0, 150, 136);
            selectRocksdbBuckupBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            selectRocksdbBuckupBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            selectRocksdbBuckupBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            selectRocksdbBuckupBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            selectRocksdbBuckupBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selectRocksdbBuckupBtn.Location = new Point(1039, 73);
            selectRocksdbBuckupBtn.MinimumSize = new Size(1, 1);
            selectRocksdbBuckupBtn.Name = "selectRocksdbBuckupBtn";
            selectRocksdbBuckupBtn.RectColor = Color.FromArgb(0, 150, 136);
            selectRocksdbBuckupBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            selectRocksdbBuckupBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            selectRocksdbBuckupBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            selectRocksdbBuckupBtn.Size = new Size(103, 35);
            selectRocksdbBuckupBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            selectRocksdbBuckupBtn.StyleCustomMode = true;
            selectRocksdbBuckupBtn.TabIndex = 7;
            selectRocksdbBuckupBtn.Text = "选择file";
            selectRocksdbBuckupBtn.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            selectRocksdbBuckupBtn.Click += selectRocksdbBuckupBtn_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(16, 390);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(190, 23);
            uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            uiLabel3.TabIndex = 7;
            uiLabel3.Text = "rocksdb backup file(.zip):";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1306, 643);
            Controls.Add(uiLabel3);
            Controls.Add(uiPanel1);
            Controls.Add(rocksdbPanel);
            Controls.Add(mongodbPanel);
            ForeColor = Color.Black;
            Name = "MainPage";
            Style = Sunny.UI.UIStyle.Custom;
            mongodbPanel.ResumeLayout(false);
            rocksdbPanel.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
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
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox rocksdbBackupTextBox;
        private Sunny.UI.UIButton openRocksdbBackupBtn;
        private Sunny.UI.UIButton selectRocksdbBuckupBtn;
    }
}