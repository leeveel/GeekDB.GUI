
namespace GeekDB.GUI.Pages
{
    partial class RocksDBDatasPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            uiPanel1 = new Sunny.UI.UIPanel();
            dbPathLable = new Sunny.UI.UIMarkLabel();
            ResetBtn = new Sunny.UI.UIButton();
            tableNameLable = new Sunny.UI.UIMarkLabel();
            FindBtn = new Sunny.UI.UIButton();
            dataCountLable = new Sunny.UI.UILabel();
            searchTextBox = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            dataGridView = new Sunny.UI.UIDataGridView();
            displayCountLable = new Sunny.UI.UILabel();
            refreshBtn = new Sunny.UI.UIButton();
            rightBtn = new Sunny.UI.UISymbolButton();
            leftBtn = new Sunny.UI.UISymbolButton();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uiPanel1.Controls.Add(dbPathLable);
            uiPanel1.Controls.Add(ResetBtn);
            uiPanel1.Controls.Add(tableNameLable);
            uiPanel1.Controls.Add(FindBtn);
            uiPanel1.Controls.Add(dataCountLable);
            uiPanel1.Controls.Add(searchTextBox);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.FillColor = Color.White;
            uiPanel1.FillColor2 = Color.White;
            uiPanel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiPanel1.Location = new Point(4, 5);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RectColor = Color.White;
            uiPanel1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel1.Size = new Size(1531, 131);
            uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiPanel1.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // dbPathLable
            // 
            dbPathLable.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dbPathLable.ForeColor = Color.Silver;
            dbPathLable.Location = new Point(11, 10);
            dbPathLable.MarkColor = Color.Transparent;
            dbPathLable.Name = "dbPathLable";
            dbPathLable.Padding = new Padding(5, 0, 0, 0);
            dbPathLable.Size = new Size(664, 22);
            dbPathLable.Style = Sunny.UI.UIStyle.Custom;
            dbPathLable.StyleCustomMode = true;
            dbPathLable.TabIndex = 5;
            dbPathLable.Text = "name";
            dbPathLable.TextAlign = ContentAlignment.MiddleLeft;
            dbPathLable.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // ResetBtn
            // 
            ResetBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ResetBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ResetBtn.Location = new Point(1419, 97);
            ResetBtn.MinimumSize = new Size(1, 1);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(92, 29);
            ResetBtn.Style = Sunny.UI.UIStyle.Custom;
            ResetBtn.TabIndex = 4;
            ResetBtn.Text = "重置";
            ResetBtn.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            ResetBtn.Click += ResetBtn_Click;
            // 
            // tableNameLable
            // 
            tableNameLable.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            tableNameLable.Location = new Point(9, 32);
            tableNameLable.MarkColor = Color.Transparent;
            tableNameLable.Name = "tableNameLable";
            tableNameLable.Padding = new Padding(5, 0, 0, 0);
            tableNameLable.Size = new Size(664, 46);
            tableNameLable.Style = Sunny.UI.UIStyle.Custom;
            tableNameLable.StyleCustomMode = true;
            tableNameLable.TabIndex = 2;
            tableNameLable.Text = "name";
            tableNameLable.TextAlign = ContentAlignment.MiddleLeft;
            tableNameLable.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // FindBtn
            // 
            FindBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FindBtn.FillColor = Color.FromArgb(0, 150, 136);
            FindBtn.FillColor2 = Color.FromArgb(0, 150, 136);
            FindBtn.FillHoverColor = Color.FromArgb(51, 171, 160);
            FindBtn.FillPressColor = Color.FromArgb(0, 120, 109);
            FindBtn.FillSelectedColor = Color.FromArgb(0, 120, 109);
            FindBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FindBtn.Location = new Point(1321, 97);
            FindBtn.MinimumSize = new Size(1, 1);
            FindBtn.Name = "FindBtn";
            FindBtn.RectColor = Color.FromArgb(0, 150, 136);
            FindBtn.RectHoverColor = Color.FromArgb(51, 171, 160);
            FindBtn.RectPressColor = Color.FromArgb(0, 120, 109);
            FindBtn.RectSelectedColor = Color.FromArgb(0, 120, 109);
            FindBtn.Size = new Size(92, 29);
            FindBtn.Style = Sunny.UI.UIStyle.LayuiGreen;
            FindBtn.StyleCustomMode = true;
            FindBtn.TabIndex = 3;
            FindBtn.Text = "查找";
            FindBtn.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            FindBtn.Click += FindBtn_Click;
            // 
            // dataCountLable
            // 
            dataCountLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataCountLable.Font = new Font("微软雅黑", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataCountLable.ForeColor = Color.Green;
            dataCountLable.Location = new Point(1366, 3);
            dataCountLable.Name = "dataCountLable";
            dataCountLable.Size = new Size(158, 59);
            dataCountLable.Style = Sunny.UI.UIStyle.Custom;
            dataCountLable.StyleCustomMode = true;
            dataCountLable.TabIndex = 1;
            dataCountLable.Text = "999";
            dataCountLable.TextAlign = ContentAlignment.MiddleCenter;
            dataCountLable.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchTextBox.Location = new Point(11, 97);
            searchTextBox.Margin = new Padding(4, 5, 4, 5);
            searchTextBox.MinimumSize = new Size(1, 16);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Radius = 1;
            searchTextBox.RectColor = Color.FromArgb(224, 224, 224);
            searchTextBox.ShowText = false;
            searchTextBox.Size = new Size(1292, 29);
            searchTextBox.Style = Sunny.UI.UIStyle.Custom;
            searchTextBox.StyleCustomMode = true;
            searchTextBox.TabIndex = 2;
            searchTextBox.TextAlignment = ContentAlignment.MiddleLeft;
            searchTextBox.Watermark = "";
            searchTextBox.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            searchTextBox.DoEnter += FindBtn_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(1358, 62);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(174, 20);
            uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "DOCUMENTS";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            uiLabel1.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 248, 248);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CausesValidation = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 32;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(204, 234, 232);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView.GridColor = Color.FromArgb(34, 164, 152);
            dataGridView.Location = new Point(12, 190);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RectColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(238, 248, 248);
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(204, 234, 232);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView.RowTemplate.Height = 35;
            dataGridView.ScrollBarBackColor = Color.FromArgb(238, 248, 248);
            dataGridView.ScrollBarColor = Color.FromArgb(0, 150, 136);
            dataGridView.ScrollBarHandleWidth = 18;
            dataGridView.ScrollBarRectColor = Color.FromArgb(0, 150, 136);
            dataGridView.SelectedIndex = -1;
            dataGridView.Size = new Size(1506, 379);
            dataGridView.StripeOddColor = Color.FromArgb(238, 248, 248);
            dataGridView.Style = Sunny.UI.UIStyle.Custom;
            dataGridView.StyleCustomMode = true;
            dataGridView.TabIndex = 1;
            dataGridView.VirtualMode = true;
            dataGridView.ZoomScaleDisabled = true;
            dataGridView.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            dataGridView.RowStateChanged += dataGridView_RowStateChanged;
            // 
            // displayCountLable
            // 
            displayCountLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            displayCountLable.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
            displayCountLable.Location = new Point(861, 149);
            displayCountLable.Name = "displayCountLable";
            displayCountLable.Size = new Size(469, 35);
            displayCountLable.Style = Sunny.UI.UIStyle.Custom;
            displayCountLable.TabIndex = 7;
            displayCountLable.Text = "displaying documents 1-20 of 500";
            displayCountLable.TextAlign = ContentAlignment.MiddleRight;
            displayCountLable.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            // 
            // refreshBtn
            // 
            refreshBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            refreshBtn.Location = new Point(1423, 150);
            refreshBtn.MinimumSize = new Size(1, 1);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(92, 29);
            refreshBtn.Style = Sunny.UI.UIStyle.Custom;
            refreshBtn.TabIndex = 13;
            refreshBtn.Text = "刷新";
            refreshBtn.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            refreshBtn.Click += refreshBtn_Click;
            // 
            // rightBtn
            // 
            rightBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rightBtn.Cursor = Cursors.Hand;
            rightBtn.FillColor = Color.Transparent;
            rightBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rightBtn.Location = new Point(1375, 149);
            rightBtn.MinimumSize = new Size(1, 1);
            rightBtn.Name = "rightBtn";
            rightBtn.RectColor = Color.Transparent;
            rightBtn.RectDisableColor = Color.White;
            rightBtn.RectHoverColor = Color.Black;
            rightBtn.Size = new Size(37, 35);
            rightBtn.Style = Sunny.UI.UIStyle.Custom;
            rightBtn.StyleCustomMode = true;
            rightBtn.Symbol = 61518;
            rightBtn.SymbolColor = Color.Black;
            rightBtn.SymbolDisableColor = Color.Silver;
            rightBtn.SymbolPressColor = Color.DarkGray;
            rightBtn.SymbolSelectedColor = Color.Gainsboro;
            rightBtn.TabIndex = 12;
            rightBtn.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            rightBtn.Click += rightBtn_Click;
            // 
            // leftBtn
            // 
            leftBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            leftBtn.Cursor = Cursors.Hand;
            leftBtn.FillColor = Color.Transparent;
            leftBtn.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            leftBtn.ForeHoverColor = Color.Gray;
            leftBtn.ForeSelectedColor = Color.Gray;
            leftBtn.Location = new Point(1336, 149);
            leftBtn.MinimumSize = new Size(1, 1);
            leftBtn.Name = "leftBtn";
            leftBtn.RectColor = Color.Transparent;
            leftBtn.RectDisableColor = SystemColors.ScrollBar;
            leftBtn.RectHoverColor = Color.Black;
            leftBtn.Size = new Size(37, 35);
            leftBtn.Style = Sunny.UI.UIStyle.Custom;
            leftBtn.StyleCustomMode = true;
            leftBtn.Symbol = 61514;
            leftBtn.SymbolColor = Color.Black;
            leftBtn.SymbolDisableColor = Color.LightGray;
            leftBtn.SymbolPressColor = Color.Gray;
            leftBtn.SymbolSelectedColor = Color.DarkGray;
            leftBtn.TabIndex = 10;
            leftBtn.ZoomScaleRect = new Rectangle(0, 0, 0, 0);
            leftBtn.Click += leftBtn_Click;
            // 
            // RocksDBDatasPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1530, 581);
            Controls.Add(displayCountLable);
            Controls.Add(refreshBtn);
            Controls.Add(rightBtn);
            Controls.Add(leftBtn);
            Controls.Add(dataGridView);
            Controls.Add(uiPanel1);
            Name = "RocksDBDatasPage";
            Style = Sunny.UI.UIStyle.Custom;
            Text = "ShowStateCollectionPage";
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
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
        private Sunny.UI.UIButton refreshBtn;
        private Sunny.UI.UISymbolButton rightBtn;
        private Sunny.UI.UISymbolButton leftBtn;
    }
}