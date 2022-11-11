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
            this.mongodbPanel = new Sunny.UI.UIPanel();
            this.mongodbConnectBtn = new Sunny.UI.UIButton();
            this.mongodbURLTextBox = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.rocksdbPanel = new Sunny.UI.UIPanel();
            this.mongodbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mongodbPanel
            // 
            this.mongodbPanel.Controls.Add(this.mongodbConnectBtn);
            this.mongodbPanel.Controls.Add(this.mongodbURLTextBox);
            this.mongodbPanel.Controls.Add(this.uiLabel1);
            this.mongodbPanel.FillColor = System.Drawing.Color.White;
            this.mongodbPanel.FillColor2 = System.Drawing.Color.White;
            this.mongodbPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mongodbPanel.Location = new System.Drawing.Point(86, 79);
            this.mongodbPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mongodbPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.mongodbPanel.Name = "mongodbPanel";
            this.mongodbPanel.RectColor = System.Drawing.Color.White;
            this.mongodbPanel.RectDisableColor = System.Drawing.Color.White;
            this.mongodbPanel.Size = new System.Drawing.Size(798, 184);
            this.mongodbPanel.Style = Sunny.UI.UIStyle.Custom;
            this.mongodbPanel.TabIndex = 0;
            this.mongodbPanel.Text = null;
            this.mongodbPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.mongodbPanel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // mongodbConnectBtn
            // 
            this.mongodbConnectBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mongodbConnectBtn.Location = new System.Drawing.Point(695, 96);
            this.mongodbConnectBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.mongodbConnectBtn.Name = "mongodbConnectBtn";
            this.mongodbConnectBtn.Size = new System.Drawing.Size(100, 35);
            this.mongodbConnectBtn.Style = Sunny.UI.UIStyle.Custom;
            this.mongodbConnectBtn.TabIndex = 2;
            this.mongodbConnectBtn.Text = "Connect";
            this.mongodbConnectBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // mongodbURLTextBox
            // 
            this.mongodbURLTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mongodbURLTextBox.Location = new System.Drawing.Point(4, 28);
            this.mongodbURLTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mongodbURLTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.mongodbURLTextBox.Name = "mongodbURLTextBox";
            this.mongodbURLTextBox.ShowText = false;
            this.mongodbURLTextBox.Size = new System.Drawing.Size(794, 60);
            this.mongodbURLTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.mongodbURLTextBox.TabIndex = 1;
            this.mongodbURLTextBox.Text = "mongodb://localhost:27017";
            this.mongodbURLTextBox.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.mongodbURLTextBox.Watermark = "";
            this.mongodbURLTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(190, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "mongodb URL";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rocksdbPanel
            // 
            this.rocksdbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rocksdbPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rocksdbPanel.Location = new System.Drawing.Point(86, 347);
            this.rocksdbPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rocksdbPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.rocksdbPanel.Name = "rocksdbPanel";
            this.rocksdbPanel.Size = new System.Drawing.Size(798, 189);
            this.rocksdbPanel.Style = Sunny.UI.UIStyle.Custom;
            this.rocksdbPanel.TabIndex = 1;
            this.rocksdbPanel.Text = "uiPanel1";
            this.rocksdbPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rocksdbPanel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 887);
            this.Controls.Add(this.rocksdbPanel);
            this.Controls.Add(this.mongodbPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.mongodbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel mongodbPanel;
        private Sunny.UI.UIPanel rocksdbPanel;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox mongodbURLTextBox;
        private Sunny.UI.UIButton mongodbConnectBtn;
    }
}