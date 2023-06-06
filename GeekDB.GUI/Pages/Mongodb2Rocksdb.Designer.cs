namespace GeekDB.GUI.Pages
{
    partial class Mongodb2Rocksdb
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
            selectBtn = new Sunny.UI.UIButton();
            label1 = new Label();
            label2 = new Label();
            exportBtn = new Sunny.UI.UIButton();
            pathLable = new Sunny.UI.UILabel();
            logTxtbox = new Sunny.UI.UIRichTextBox();
            processBar = new Sunny.UI.UIProcessBar();
            SuspendLayout();
            // 
            // selectBtn
            // 
            selectBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectBtn.FillColor = Color.FromArgb(0, 150, 136);
            selectBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            selectBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            selectBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            selectBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            selectBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selectBtn.Location = new Point(723, 51);
            selectBtn.MinimumSize = new Size(1, 1);
            selectBtn.Name = "selectBtn";
            selectBtn.RectColor = Color.FromArgb(0, 150, 136);
            selectBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            selectBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            selectBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            selectBtn.Size = new Size(108, 35);
            selectBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            selectBtn.StyleCustomMode = true;
            selectBtn.TabIndex = 3;
            selectBtn.Text = "选择路径";
            selectBtn.Click += selectBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 51);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 4;
            label1.Text = "保存路径:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 130);
            label2.Name = "label2";
            label2.Size = new Size(0, 21);
            label2.TabIndex = 5;
            // 
            // exportBtn
            // 
            exportBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exportBtn.FillColor = Color.FromArgb(0, 150, 136);
            exportBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            exportBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            exportBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            exportBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            exportBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            exportBtn.Location = new Point(722, 605);
            exportBtn.MinimumSize = new Size(1, 1);
            exportBtn.Name = "exportBtn";
            exportBtn.RectColor = Color.FromArgb(0, 150, 136);
            exportBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            exportBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            exportBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            exportBtn.Size = new Size(108, 35);
            exportBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            exportBtn.StyleCustomMode = true;
            exportBtn.TabIndex = 6;
            exportBtn.Text = "导出";
            exportBtn.Click += exportBtn_ClickAsync;
            // 
            // pathLable
            // 
            pathLable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathLable.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pathLable.Location = new Point(87, 51);
            pathLable.Name = "pathLable";
            pathLable.Size = new Size(630, 23);
            pathLable.Style = Sunny.UI.UIStyle.Custom;
            pathLable.TabIndex = 7;
            pathLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // logTxtbox
            // 
            logTxtbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTxtbox.FillColor = Color.White;
            logTxtbox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            logTxtbox.Location = new Point(4, 89);
            logTxtbox.Margin = new Padding(4, 5, 4, 5);
            logTxtbox.MinimumSize = new Size(1, 1);
            logTxtbox.Name = "logTxtbox";
            logTxtbox.Padding = new Padding(2);
            logTxtbox.RectColor = Color.Black;
            logTxtbox.RectSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            logTxtbox.ShowText = false;
            logTxtbox.Size = new Size(826, 508);
            logTxtbox.Style = Sunny.UI.UIStyle.Custom;
            logTxtbox.TabIndex = 8;
            logTxtbox.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // processBar
            // 
            processBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            processBar.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            processBar.Location = new Point(4, 607);
            processBar.MinimumSize = new Size(70, 3);
            processBar.Name = "processBar";
            processBar.Size = new Size(713, 31);
            processBar.Style = Sunny.UI.UIStyle.Custom;
            processBar.TabIndex = 9;
            processBar.Text = "uiProcessBar1";
            // 
            // Mongodb2Rocksdb
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(834, 643);
            Controls.Add(processBar);
            Controls.Add(logTxtbox);
            Controls.Add(pathLable);
            Controls.Add(exportBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(selectBtn);
            Name = "Mongodb2Rocksdb";
            Style = Sunny.UI.UIStyle.Custom;
            Text = "Mongodb2RocksdbForm";
            TitleColor = Color.FromArgb(0, 150, 136);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIButton selectBtn;
        private Label label1;
        private Label label2;
        private Sunny.UI.UIButton exportBtn;
        private Sunny.UI.UILabel pathLable;
        private Sunny.UI.UIRichTextBox logTxtbox;
        private Sunny.UI.UIProcessBar processBar;
    }
}