using Alex75.JsonViewer.WindowsForm;

namespace GeekDB.GUI.Pages
{
    partial class MongoDBDatasPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.indexCountLable = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.dbPathLable = new Sunny.UI.UIMarkLabel();
            this.ResetBtn = new Sunny.UI.UIButton();
            this.tableNameLable = new Sunny.UI.UIMarkLabel();
            this.FindBtn = new Sunny.UI.UIButton();
            this.dataCountLable = new Sunny.UI.UILabel();
            this.searchTextBox = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.dataGridView = new Sunny.UI.UIDataGridView();
            this.displayCountLable = new Sunny.UI.UILabel();
            this.leftBtn = new Sunny.UI.UISymbolButton();
            this.rightBtn = new Sunny.UI.UISymbolButton();
            this.refreshBtn = new Sunny.UI.UIButton();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.indexCountLable);
            this.uiPanel1.Controls.Add(this.uiLabel2);
            this.uiPanel1.Controls.Add(this.dbPathLable);
            this.uiPanel1.Controls.Add(this.ResetBtn);
            this.uiPanel1.Controls.Add(this.tableNameLable);
            this.uiPanel1.Controls.Add(this.FindBtn);
            this.uiPanel1.Controls.Add(this.dataCountLable);
            this.uiPanel1.Controls.Add(this.searchTextBox);
            this.uiPanel1.Controls.Add(this.uiLabel1);
            this.uiPanel1.FillColor = System.Drawing.Color.White;
            this.uiPanel1.FillColor2 = System.Drawing.Color.White;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiPanel1.Location = new System.Drawing.Point(4, 5);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.White;
            this.uiPanel1.Size = new System.Drawing.Size(961, 131);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // indexCountLable
            // 
            this.indexCountLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexCountLable.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.indexCountLable.ForeColor = System.Drawing.Color.Green;
            this.indexCountLable.Location = new System.Drawing.Point(811, -2);
            this.indexCountLable.Name = "indexCountLable";
            this.indexCountLable.Size = new System.Drawing.Size(134, 59);
            this.indexCountLable.Style = Sunny.UI.UIStyle.Custom;
            this.indexCountLable.StyleCustomMode = true;
            this.indexCountLable.TabIndex = 7;
            this.indexCountLable.Text = "999";
            this.indexCountLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.indexCountLable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel2.Location = new System.Drawing.Point(810, 51);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(133, 32);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 6;
            this.uiLabel2.Text = "INDEXES";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dbPathLable
            // 
            this.dbPathLable.AutoEllipsis = true;
            this.dbPathLable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dbPathLable.ForeColor = System.Drawing.Color.Silver;
            this.dbPathLable.Location = new System.Drawing.Point(11, 10);
            this.dbPathLable.MarkColor = System.Drawing.Color.Transparent;
            this.dbPathLable.Name = "dbPathLable";
            this.dbPathLable.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dbPathLable.Size = new System.Drawing.Size(546, 22);
            this.dbPathLable.Style = Sunny.UI.UIStyle.Custom;
            this.dbPathLable.StyleCustomMode = true;
            this.dbPathLable.TabIndex = 5;
            this.dbPathLable.Text = "name";
            this.dbPathLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dbPathLable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResetBtn.Location = new System.Drawing.Point(849, 97);
            this.ResetBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(92, 29);
            this.ResetBtn.Style = Sunny.UI.UIStyle.Custom;
            this.ResetBtn.TabIndex = 4;
            this.ResetBtn.Text = "RESET";
            this.ResetBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // tableNameLable
            // 
            this.tableNameLable.AutoEllipsis = true;
            this.tableNameLable.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tableNameLable.Location = new System.Drawing.Point(9, 32);
            this.tableNameLable.MarkColor = System.Drawing.Color.Transparent;
            this.tableNameLable.Name = "tableNameLable";
            this.tableNameLable.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tableNameLable.Size = new System.Drawing.Size(530, 46);
            this.tableNameLable.Style = Sunny.UI.UIStyle.Custom;
            this.tableNameLable.StyleCustomMode = true;
            this.tableNameLable.TabIndex = 2;
            this.tableNameLable.Text = "name";
            this.tableNameLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tableNameLable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FindBtn
            // 
            this.FindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.FindBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.FindBtn.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.FindBtn.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.FindBtn.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.FindBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FindBtn.Location = new System.Drawing.Point(751, 97);
            this.FindBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.FindBtn.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.FindBtn.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.FindBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.FindBtn.Size = new System.Drawing.Size(92, 29);
            this.FindBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.FindBtn.StyleCustomMode = true;
            this.FindBtn.TabIndex = 3;
            this.FindBtn.Text = "FIND";
            this.FindBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // dataCountLable
            // 
            this.dataCountLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataCountLable.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataCountLable.ForeColor = System.Drawing.Color.Green;
            this.dataCountLable.Location = new System.Drawing.Point(690, -2);
            this.dataCountLable.Name = "dataCountLable";
            this.dataCountLable.Size = new System.Drawing.Size(148, 59);
            this.dataCountLable.Style = Sunny.UI.UIStyle.Custom;
            this.dataCountLable.StyleCustomMode = true;
            this.dataCountLable.TabIndex = 1;
            this.dataCountLable.Text = "999";
            this.dataCountLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataCountLable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchTextBox.Location = new System.Drawing.Point(9, 97);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchTextBox.ShowText = false;
            this.searchTextBox.Size = new System.Drawing.Size(732, 29);
            this.searchTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.searchTextBox.StyleCustomMode = true;
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.Tag = "";
            this.searchTextBox.TagString = "";
            this.searchTextBox.Text = "{_id:your id}";
            this.searchTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchTextBox.Watermark = "";
            this.searchTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.searchTextBox.DoEnter += new System.EventHandler(this.FindBtn_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel1.Location = new System.Drawing.Point(690, 57);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(138, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "DOCUMENTS";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(164)))), ((int)(((byte)(152)))));
            this.dataGridView.Location = new System.Drawing.Point(12, 199);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowTemplate.Height = 35;
            this.dataGridView.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.dataGridView.ScrollBarHandleWidth = 16;
            this.dataGridView.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.dataGridView.SelectedIndex = -1;
            this.dataGridView.Size = new System.Drawing.Size(936, 676);
            this.dataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView.Style = Sunny.UI.UIStyle.Custom;
            this.dataGridView.StyleCustomMode = true;
            this.dataGridView.TabIndex = 1;
            this.dataGridView.VirtualMode = true;
            this.dataGridView.ZoomScaleDisabled = true;
            this.dataGridView.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_RowStateChanged);
            // 
            // displayCountLable
            // 
            this.displayCountLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displayCountLable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.displayCountLable.Location = new System.Drawing.Point(291, 146);
            this.displayCountLable.Name = "displayCountLable";
            this.displayCountLable.Size = new System.Drawing.Size(469, 35);
            this.displayCountLable.Style = Sunny.UI.UIStyle.Custom;
            this.displayCountLable.TabIndex = 2;
            this.displayCountLable.Text = "displaying documents 1-20 of 500";
            this.displayCountLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displayCountLable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // leftBtn
            // 
            this.leftBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftBtn.FillColor = System.Drawing.Color.Transparent;
            this.leftBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftBtn.ForeHoverColor = System.Drawing.Color.Gray;
            this.leftBtn.ForeSelectedColor = System.Drawing.Color.Gray;
            this.leftBtn.Location = new System.Drawing.Point(766, 146);
            this.leftBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.RectColor = System.Drawing.Color.Transparent;
            this.leftBtn.RectDisableColor = System.Drawing.SystemColors.ScrollBar;
            this.leftBtn.RectHoverColor = System.Drawing.Color.Black;
            this.leftBtn.Size = new System.Drawing.Size(37, 35);
            this.leftBtn.Style = Sunny.UI.UIStyle.Custom;
            this.leftBtn.StyleCustomMode = true;
            this.leftBtn.Symbol = 61514;
            this.leftBtn.SymbolColor = System.Drawing.Color.Black;
            this.leftBtn.SymbolDisableColor = System.Drawing.Color.LightGray;
            this.leftBtn.SymbolPressColor = System.Drawing.Color.Gray;
            this.leftBtn.SymbolSelectedColor = System.Drawing.Color.DarkGray;
            this.leftBtn.TabIndex = 3;
            this.leftBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // rightBtn
            // 
            this.rightBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightBtn.FillColor = System.Drawing.Color.Transparent;
            this.rightBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightBtn.Location = new System.Drawing.Point(805, 146);
            this.rightBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.RectColor = System.Drawing.Color.Transparent;
            this.rightBtn.RectDisableColor = System.Drawing.Color.White;
            this.rightBtn.RectHoverColor = System.Drawing.Color.Black;
            this.rightBtn.Size = new System.Drawing.Size(37, 35);
            this.rightBtn.Style = Sunny.UI.UIStyle.Custom;
            this.rightBtn.StyleCustomMode = true;
            this.rightBtn.Symbol = 61518;
            this.rightBtn.SymbolColor = System.Drawing.Color.Black;
            this.rightBtn.SymbolDisableColor = System.Drawing.Color.Silver;
            this.rightBtn.SymbolPressColor = System.Drawing.Color.DarkGray;
            this.rightBtn.SymbolSelectedColor = System.Drawing.Color.Gainsboro;
            this.rightBtn.TabIndex = 4;
            this.rightBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.refreshBtn.Location = new System.Drawing.Point(853, 147);
            this.refreshBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(92, 29);
            this.refreshBtn.Style = Sunny.UI.UIStyle.Custom;
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "RESET";
            this.refreshBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // MongoDBDatasPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 887);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.displayCountLable);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.uiPanel1);
            this.Name = "MongoDBDatasPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "ShowStateCollectionPage";
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel dataCountLable;
        private Sunny.UI.UIMarkLabel tableNameLable;
        private Sunny.UI.UIDataGridView dataGridView;
        private Sunny.UI.UITextBox searchTextBox;
        private Sunny.UI.UIButton FindBtn;
        private Sunny.UI.UIButton ResetBtn;
        private Sunny.UI.UIMarkLabel dbPathLable;
        private Sunny.UI.UILabel displayCountLable;
        private Sunny.UI.UISymbolButton leftBtn;
        private Sunny.UI.UISymbolButton rightBtn;
        private Sunny.UI.UIButton refreshBtn;
        private Sunny.UI.UILabel indexCountLable;
        private Sunny.UI.UILabel uiLabel2;
    }
}