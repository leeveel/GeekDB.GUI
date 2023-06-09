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
            uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            uiContextMenuStrip.SuspendLayout();
            uiSplitContainer1.BeginInit();
            uiSplitContainer1.Panel1.SuspendLayout();
            uiSplitContainer1.Panel2.SuspendLayout();
            uiSplitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // leftMenu
            // 
            leftMenu.AllowDrop = true;
            leftMenu.BorderStyle = BorderStyle.None;
            leftMenu.Dock = DockStyle.Fill;
            leftMenu.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            leftMenu.ExpandSelectFirst = false;
            leftMenu.Font = new Font("微软雅黑", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            leftMenu.ForeColor = Color.White;
            leftMenu.FullRowSelect = true;
            leftMenu.ItemHeight = 30;
            leftMenu.Location = new Point(0, 0);
            leftMenu.Margin = new Padding(0, 3, 3, 0);
            leftMenu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            leftMenu.Name = "leftMenu";
            leftMenu.ScrollBarColor = Color.FromArgb(240, 240, 240);
            leftMenu.ScrollBarHoverColor = Color.FromArgb(240, 240, 240);
            leftMenu.ScrollBarPressColor = Color.Red;
            leftMenu.SelectedForeColor = Color.Turquoise;
            leftMenu.SelectedHighColor = Color.Silver;
            leftMenu.ShowLines = false;
            leftMenu.Size = new Size(361, 719);
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
            TabControl.Size = new Size(928, 719);
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
            uiContextMenuStrip.BackColor = Color.FromArgb(248, 248, 248);
            uiContextMenuStrip.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiContextMenuStrip.ForeColor = Color.FromArgb(48, 48, 48);
            uiContextMenuStrip.Items.AddRange(new ToolStripItem[] { DisconnectToolStripMenuItem });
            uiContextMenuStrip.Name = "uiContextMenuStrip1";
            uiContextMenuStrip.Size = new Size(165, 30);
            uiContextMenuStrip.Style = Sunny.UI.UIStyle.Custom;
            // 
            // DisconnectToolStripMenuItem
            // 
            DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            DisconnectToolStripMenuItem.Size = new Size(164, 26);
            DisconnectToolStripMenuItem.Text = "Disconnect";
            DisconnectToolStripMenuItem.Click += DisconnectToolStripMenuItem_Click;
            // 
            // uiSplitContainer1
            // 
            uiSplitContainer1.ArrowColor = Color.FromArgb(0, 150, 136);
            uiSplitContainer1.Dock = DockStyle.Fill;
            uiSplitContainer1.Location = new Point(0, 35);
            uiSplitContainer1.Margin = new Padding(10, 3, 3, 10);
            uiSplitContainer1.MinimumSize = new Size(20, 20);
            uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            uiSplitContainer1.Panel1.Controls.Add(leftMenu);
            // 
            // uiSplitContainer1.Panel2
            // 
            uiSplitContainer1.Panel2.Controls.Add(TabControl);
            uiSplitContainer1.Size = new Size(1300, 719);
            uiSplitContainer1.SplitterDistance = 361;
            uiSplitContainer1.SplitterWidth = 11;
            uiSplitContainer1.Style = Sunny.UI.UIStyle.Custom;
            uiSplitContainer1.TabIndex = 2;
            // 
            // MainForm
            // 
            AllowAddControlOnTitle = true;
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1300, 754);
            ControlBoxFillHoverColor = Color.FromArgb(51, 171, 160);
            ControlBoxForeColor = Color.Black;
            Controls.Add(uiSplitContainer1);
            ExtendBox = true;
            ExtendMenu = uiContextMenuStrip;
            Name = "MainForm";
            RectColor = Color.Black;
            ShowRadius = false;
            ShowShadow = true;
            ShowTitleIcon = true;
            Style = Sunny.UI.UIStyle.Custom;
            StyleCustomMode = true;
            Tag = "";
            TagString = "";
            Text = "rocksdb";
            TitleColor = Color.White;
            TitleFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TitleForeColor = Color.Black;
            ZoomScaleDisabled = true;
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            uiContextMenuStrip.ResumeLayout(false);
            uiSplitContainer1.Panel1.ResumeLayout(false);
            uiSplitContainer1.Panel2.ResumeLayout(false);
            uiSplitContainer1.EndInit();
            uiSplitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UINavMenu leftMenu;
        private Sunny.UI.UITabControl TabControl;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip;
        private ToolStripMenuItem DisconnectToolStripMenuItem;
        private Sunny.UI.UISplitContainer uiSplitContainer1;
    }
}