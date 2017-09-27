namespace xServer.Forms
{
    partial class FrmManageClients
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageClients));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToSleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToInteractiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstClientHolders = new xServer.Controls.AeroListView();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToSleepToolStripMenuItem,
            this.setToInteractiveToolStripMenuItem,
            this.setIntervalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 70);
            // 
            // setToSleepToolStripMenuItem
            // 
            this.setToSleepToolStripMenuItem.Name = "setToSleepToolStripMenuItem";
            this.setToSleepToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setToSleepToolStripMenuItem.Text = "Set to Sleep";
            this.setToSleepToolStripMenuItem.Click += new System.EventHandler(this.setModeToSleepToolStripMenuItem_Click);
            // 
            // setToInteractiveToolStripMenuItem
            // 
            this.setToInteractiveToolStripMenuItem.Name = "setToInteractiveToolStripMenuItem";
            this.setToInteractiveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setToInteractiveToolStripMenuItem.Text = "Set to Interactive";
            this.setToInteractiveToolStripMenuItem.Click += new System.EventHandler(this.setToInteractiveToolStripMenuItem_Click);
            // 
            // setIntervalToolStripMenuItem
            // 
            this.setIntervalToolStripMenuItem.Name = "setIntervalToolStripMenuItem";
            this.setIntervalToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setIntervalToolStripMenuItem.Text = "Set Interval";
            this.setIntervalToolStripMenuItem.Click += new System.EventHandler(this.setIntervalToolStripMenuItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "OS";
            this.columnHeader4.Width = 195;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 156;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last Connected";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Interval";
            this.columnHeader6.Width = 62;
            // 
            // lstClientHolders
            // 
            this.lstClientHolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.lstClientHolders.ContextMenuStrip = this.contextMenuStrip1;
            this.lstClientHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClientHolders.FullRowSelect = true;
            this.lstClientHolders.GridLines = true;
            this.lstClientHolders.Location = new System.Drawing.Point(0, 0);
            this.lstClientHolders.Name = "lstClientHolders";
            this.lstClientHolders.Size = new System.Drawing.Size(784, 178);
            this.lstClientHolders.TabIndex = 0;
            this.lstClientHolders.UseCompatibleStateImageBehavior = false;
            this.lstClientHolders.View = System.Windows.Forms.View.Details;
            this.lstClientHolders.VirtualMode = true;
            this.lstClientHolders.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.LvClientHolders_RetrieveVirtualItem);
            // 
            // FrmManageClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 178);
            this.ControlBox = false;
            this.Controls.Add(this.lstClientHolders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManageClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Manage Clients";
            this.Load += new System.EventHandler(this.FrmManageClients_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setToSleepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToInteractiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setIntervalToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private Controls.AeroListView lstClientHolders;
    }
}