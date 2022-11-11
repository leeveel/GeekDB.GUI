namespace GeekDB.GUI.Pages
{
    partial class ShowStateCollectionPage
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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Location = new System.Drawing.Point(35, 23);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(619, 366);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // ShowStateCollectionPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1117, 887);
            this.Controls.Add(this.objectListView1);
            this.Name = "ShowStateCollectionPage";
            this.Text = "ShowStateCollectionPage";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
    }
}