namespace GeekDB.GUI
{
    partial class MainForm
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
            leftMenu = new Sunny.UI.UINavMenu();
            TabControl = new Sunny.UI.UITabControl();
            uiContextMenuStrip = new Sunny.UI.UIContextMenuStrip();
            DisconnectToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            searchTxt = new Sunny.UI.UITextBox();
            uiContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // leftMenu
            // 
            leftMenu.AllowDrop = true;
            leftMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftMenu.BorderStyle = BorderStyle.None;
            leftMenu.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            leftMenu.ExpandSelectFirst = false;
            leftMenu.Font = new Font("微软雅黑", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            leftMenu.ForeColor = Color.White;
            leftMenu.FullRowSelect = true;
            leftMenu.ItemHeight = 30;
            leftMenu.Location = new Point(0, 37);
            leftMenu.Margin = new Padding(0, 3, 3, 0);
            leftMenu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            leftMenu.Name = "leftMenu";
            leftMenu.ScrollBarColor = Color.FromArgb(240, 240, 240);
            leftMenu.ScrollBarHoverColor = Color.FromArgb(240, 240, 240);
            leftMenu.ScrollBarPressColor = Color.Red;
            leftMenu.SelectedForeColor = Color.Turquoise;
            leftMenu.SelectedHighColor = Color.Silver;
            leftMenu.ShowLines = false;
            leftMenu.Size = new Size(429, 682);
            leftMenu.Style = Sunny.UI.UIStyle.Custom;
            leftMenu.StyleCustomMode = true;
            leftMenu.TabIndex = 0;
            leftMenu.TipsFont = new Font("微软雅黑 Light", 9F, FontStyle.Regular, GraphicsUnit.Point);
            // 
            // TabControl
            // 
            TabControl.AllowDrop = true;
            TabControl.Dock = DockStyle.Fill;
            TabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControl.FillColor = Color.White;
            TabControl.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            TabControl.ItemSize = new Size(190, 70);
            TabControl.Location = new Point(0, 0);
            TabControl.MainPage = "";
            TabControl.Margin = new Padding(0);
            TabControl.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.ShowCloseButton = true;
            TabControl.Size = new Size(858, 719);
            TabControl.SizeMode = TabSizeMode.Fixed;
            TabControl.Style = Sunny.UI.UIStyle.Custom;
            TabControl.StyleCustomMode = true;
            TabControl.TabBackColor = Color.White;
            TabControl.TabIndex = 1;
            TabControl.TabSelectedColor = Color.White;
            TabControl.TabSelectedForeColor = Color.FromArgb(0, 150, 136);
            TabControl.TabSelectedHighColor = Color.Green;
            TabControl.TabUnSelectedForeColor = Color.Gray;
            TabControl.TagString = "";
            TabControl.TipsFont = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            TabControl.TipsForeColor = Color.Gray;
            // 
            // uiContextMenuStrip
            // 
            uiContextMenuStrip.BackColor = Color.FromArgb(238, 248, 248);
            uiContextMenuStrip.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiContextMenuStrip.ForeColor = Color.FromArgb(48, 48, 48);
            uiContextMenuStrip.Items.AddRange(new ToolStripItem[] { DisconnectToolStripMenuItem });
            uiContextMenuStrip.Name = "uiContextMenuStrip1";
            uiContextMenuStrip.Size = new Size(165, 30);
            uiContextMenuStrip.Style = Sunny.UI.UIStyle.LayuiGreen;
            // 
            // DisconnectToolStripMenuItem
            // 
            DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            DisconnectToolStripMenuItem.Size = new Size(164, 26);
            DisconnectToolStripMenuItem.Text = "Disconnect";
            DisconnectToolStripMenuItem.Click += DisconnectToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Gainsboro;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(searchTxt);
            splitContainer1.Panel1.Controls.Add(leftMenu);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(TabControl);
            splitContainer1.Size = new Size(1300, 719);
            splitContainer1.SplitterDistance = 432;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 3;
            // 
            // searchTxt
            // 
            searchTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTxt.ButtonFillColor = Color.FromArgb(0, 150, 136);
            searchTxt.ButtonFillHoverColor = Color.FromArgb(51, 171, 160);
            searchTxt.ButtonFillPressColor = Color.FromArgb(0, 120, 109);
            searchTxt.ButtonRectColor = Color.FromArgb(0, 150, 136);
            searchTxt.ButtonRectHoverColor = Color.FromArgb(51, 171, 160);
            searchTxt.ButtonRectPressColor = Color.FromArgb(0, 120, 109);
            searchTxt.FillColor2 = Color.FromArgb(238, 248, 248);
            searchTxt.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchTxt.Location = new Point(4, 3);
            searchTxt.Margin = new Padding(4, 5, 4, 5);
            searchTxt.MinimumSize = new Size(1, 16);
            searchTxt.Name = "searchTxt";
            searchTxt.Padding = new Padding(5);
            searchTxt.RectColor = Color.FromArgb(0, 150, 136);
            searchTxt.ScrollBarColor = Color.FromArgb(0, 150, 136);
            searchTxt.ShowText = false;
            searchTxt.Size = new Size(425, 29);
            searchTxt.Style = Sunny.UI.UIStyle.LayuiGreen;
            searchTxt.TabIndex = 1;
            searchTxt.TextAlignment = ContentAlignment.MiddleLeft;
            searchTxt.Watermark = "";
            searchTxt.TextChanged += searchTxt_TextChanged;
            // 
            // MainForm
            // 
            AllowAddControlOnTitle = true;
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.FromArgb(238, 248, 248);
            ClientSize = new Size(1300, 754);
            ControlBoxFillHoverColor = Color.FromArgb(51, 171, 160);
            Controls.Add(splitContainer1);
            ExtendBox = true;
            ExtendMenu = uiContextMenuStrip;
            Name = "MainForm";
            RectColor = Color.FromArgb(0, 150, 136);
            ShowRadius = false;
            ShowShadow = true;
            ShowTitleIcon = true;
            Style = Sunny.UI.UIStyle.LayuiGreen;
            StyleCustomMode = true;
            Tag = "";
            TagString = "";
            Text = "rocksdb";
            TitleColor = Color.FromArgb(0, 150, 136);
            TitleFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ZoomScaleDisabled = true;
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            uiContextMenuStrip.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UINavMenu leftMenu;
        private Sunny.UI.UITabControl TabControl;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip;
        private ToolStripMenuItem DisconnectToolStripMenuItem;
        private SplitContainer splitContainer1;
        private Sunny.UI.UITextBox searchTxt;
    }
}