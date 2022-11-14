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
            this.leftMenu = new Sunny.UI.UINavMenu();
            this.TabControl = new Sunny.UI.UITabControl();
            this.SuspendLayout();
            // 
            // leftMenu
            // 
            this.leftMenu.AllowDrop = true;
            this.leftMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.leftMenu.ExpandSelectFirst = false;
            this.leftMenu.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftMenu.ForeColor = System.Drawing.Color.White;
            this.leftMenu.FullRowSelect = true;
            this.leftMenu.ItemHeight = 50;
            this.leftMenu.Location = new System.Drawing.Point(0, 35);
            this.leftMenu.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.leftMenu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.leftMenu.Name = "leftMenu";
            this.leftMenu.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.leftMenu.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.leftMenu.ScrollBarPressColor = System.Drawing.Color.Red;
            this.leftMenu.SelectedForeColor = System.Drawing.Color.Turquoise;
            this.leftMenu.SelectedHighColor = System.Drawing.Color.Silver;
            this.leftMenu.ShowLines = false;
            this.leftMenu.Size = new System.Drawing.Size(277, 719);
            this.leftMenu.Style = Sunny.UI.UIStyle.Custom;
            this.leftMenu.StyleCustomMode = true;
            this.leftMenu.TabIndex = 0;
            this.leftMenu.TipsFont = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftMenu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TabControl
            // 
            this.TabControl.AllowDrop = true;
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControl.FillColor = System.Drawing.Color.White;
            this.TabControl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabControl.Frame = null;
            this.TabControl.ItemSize = new System.Drawing.Size(190, 70);
            this.TabControl.Location = new System.Drawing.Point(275, 35);
            this.TabControl.MainPage = "";
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.ShowCloseButton = true;
            this.TabControl.Size = new System.Drawing.Size(848, 716);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.Style = Sunny.UI.UIStyle.Custom;
            this.TabControl.StyleCustomMode = true;
            this.TabControl.TabBackColor = System.Drawing.Color.White;
            this.TabControl.TabIndex = 1;
            this.TabControl.TabSelectedColor = System.Drawing.Color.White;
            this.TabControl.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.TabControl.TabSelectedHighColor = System.Drawing.Color.Green;
            this.TabControl.TabUnSelectedForeColor = System.Drawing.Color.Gray;
            this.TabControl.TagString = "";
            this.TabControl.TipsFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabControl.TipsForeColor = System.Drawing.Color.Gray;
            this.TabControl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1126, 754);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ControlBoxForeColor = System.Drawing.Color.Black;
            this.Controls.Add(this.leftMenu);
            this.Controls.Add(this.TabControl);
            this.ExtendBox = true;
            this.Name = "MainForm";
            this.RectColor = System.Drawing.Color.Black;
            this.ShowRadius = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Tag = "";
            this.TagString = "";
            this.Text = "rocksdb";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleForeColor = System.Drawing.Color.Black;
            this.ZoomScaleDisabled = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UINavMenu leftMenu;
        private Sunny.UI.UITabControl TabControl;
    }
}