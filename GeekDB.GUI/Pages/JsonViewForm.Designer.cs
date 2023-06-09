using JsonTreeView.Controls;

namespace GeekDB.GUI.Pages
{
    partial class JsonViewForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            jsonTreeViewSplitContainer = new SplitContainer();
            jTokenTree = new JTokenTreeUserControl();
            panel2 = new Panel();
            jsonValueTextBox = new RichTextBox();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)jsonTreeViewSplitContainer).BeginInit();
            jsonTreeViewSplitContainer.Panel1.SuspendLayout();
            jsonTreeViewSplitContainer.Panel2.SuspendLayout();
            jsonTreeViewSplitContainer.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // jsonTreeViewSplitContainer
            // 
            jsonTreeViewSplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            jsonTreeViewSplitContainer.Location = new Point(0, 35);
            jsonTreeViewSplitContainer.Margin = new Padding(4);
            jsonTreeViewSplitContainer.Name = "jsonTreeViewSplitContainer";
            // 
            // jsonTreeViewSplitContainer.Panel1
            // 
            jsonTreeViewSplitContainer.Panel1.Controls.Add(jTokenTree);
            jsonTreeViewSplitContainer.Panel1MinSize = 200;
            // 
            // jsonTreeViewSplitContainer.Panel2
            // 
            jsonTreeViewSplitContainer.Panel2.BackColor = Color.Transparent;
            jsonTreeViewSplitContainer.Panel2.Controls.Add(panel2);
            jsonTreeViewSplitContainer.Panel2MinSize = 320;
            jsonTreeViewSplitContainer.Size = new Size(1176, 566);
            jsonTreeViewSplitContainer.SplitterDistance = 647;
            jsonTreeViewSplitContainer.SplitterWidth = 5;
            jsonTreeViewSplitContainer.TabIndex = 8;
            // 
            // jTokenTree
            // 
            jTokenTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            jTokenTree.CollapsedFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            jTokenTree.ExpandedFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            jTokenTree.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            jTokenTree.Location = new Point(4, 4);
            jTokenTree.Margin = new Padding(7, 8, 7, 8);
            jTokenTree.Name = "jTokenTree";
            jTokenTree.Size = new Size(640, 558);
            jTokenTree.TabIndex = 2;
            jTokenTree.AfterSelect += jTokenTree_AfterSelect;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(jsonValueTextBox);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(524, 566);
            panel2.TabIndex = 1;
            // 
            // jsonValueTextBox
            // 
            jsonValueTextBox.Dock = DockStyle.Fill;
            jsonValueTextBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            jsonValueTextBox.Location = new Point(0, 0);
            jsonValueTextBox.Margin = new Padding(4);
            jsonValueTextBox.Name = "jsonValueTextBox";
            jsonValueTextBox.ReadOnly = true;
            jsonValueTextBox.Size = new Size(524, 566);
            jsonValueTextBox.TabIndex = 15;
            jsonValueTextBox.Text = "";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(32, 19);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(892, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // JsonViewForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1176, 570);
            ControlBoxFillHoverColor = Color.FromArgb(51, 171, 160);
            Controls.Add(jsonTreeViewSplitContainer);
            Margin = new Padding(4);
            Name = "JsonViewForm";
            RectColor = Color.FromArgb(0, 150, 136);
            ShowRadius = false;
            ShowShadow = true;
            Style = Sunny.UI.UIStyle.LayuiGreen;
            Text = "";
            TitleColor = Color.FromArgb(0, 150, 136);
            ZoomScaleRect = new Rectangle(15, 15, 1176, 570);
            jsonTreeViewSplitContainer.Panel1.ResumeLayout(false);
            jsonTreeViewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)jsonTreeViewSplitContainer).EndInit();
            jsonTreeViewSplitContainer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer jsonTreeViewSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private JTokenTreeUserControl jTokenTree;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox jsonValueTextBox;
    }
}

