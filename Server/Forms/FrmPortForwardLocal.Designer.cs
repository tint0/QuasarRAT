namespace xServer.Forms
{
    partial class FrmPortForwardLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPortForwardLocal));
            this.tabControlConnections = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstConnections = new xServer.Controls.AeroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nudClientPort = new System.Windows.Forms.NumericUpDown();
            this.lblLocalServerPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtFwdHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFwdPort = new System.Windows.Forms.NumericUpDown();
            this.lstServers = new xServer.Controls.AeroListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlServers = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControlConnections.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClientPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFwdPort)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlServers.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlConnections
            // 
            this.tabControlConnections.AllowDrop = true;
            this.tabControlConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlConnections.Controls.Add(this.tabPage1);
            this.tabControlConnections.Location = new System.Drawing.Point(32, 152);
            this.tabControlConnections.Name = "tabControlConnections";
            this.tabControlConnections.SelectedIndex = 0;
            this.tabControlConnections.Size = new System.Drawing.Size(732, 249);
            this.tabControlConnections.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstConnections);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Open Connections";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstConnections
            // 
            this.lstConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader4});
            this.lstConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConnections.FullRowSelect = true;
            this.lstConnections.GridLines = true;
            this.lstConnections.Location = new System.Drawing.Point(3, 3);
            this.lstConnections.Name = "lstConnections";
            this.lstConnections.Size = new System.Drawing.Size(718, 217);
            this.lstConnections.TabIndex = 0;
            this.lstConnections.UseCompatibleStateImageBehavior = false;
            this.lstConnections.View = System.Windows.Forms.View.Details;
            this.lstConnections.VirtualMode = true;
            this.lstConnections.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.LvConnections_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Local Port";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Remote Host";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Remote Port";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Client";
            this.columnHeader6.Width = 105;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Client Socket";
            this.columnHeader10.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Received";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sent";
            this.columnHeader4.Width = 94;
            // 
            // nudClientPort
            // 
            this.nudClientPort.Location = new System.Drawing.Point(123, 27);
            this.nudClientPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudClientPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudClientPort.Name = "nudClientPort";
            this.nudClientPort.Size = new System.Drawing.Size(120, 20);
            this.nudClientPort.TabIndex = 1;
            this.nudClientPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudClientPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblLocalServerPort
            // 
            this.lblLocalServerPort.AutoSize = true;
            this.lblLocalServerPort.Location = new System.Drawing.Point(28, 29);
            this.lblLocalServerPort.Name = "lblLocalServerPort";
            this.lblLocalServerPort.Size = new System.Drawing.Size(89, 13);
            this.lblLocalServerPort.TabIndex = 9;
            this.lblLocalServerPort.Text = "Local Server Port";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(249, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Forwarding";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFwdHost
            // 
            this.txtFwdHost.Location = new System.Drawing.Point(123, 55);
            this.txtFwdHost.Name = "txtFwdHost";
            this.txtFwdHost.Size = new System.Drawing.Size(120, 20);
            this.txtFwdHost.TabIndex = 2;
            this.txtFwdHost.Text = "123.30.75.2";
            this.txtFwdHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Remote Client";
            // 
            // nudFwdPort
            // 
            this.nudFwdPort.Location = new System.Drawing.Point(249, 55);
            this.nudFwdPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudFwdPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFwdPort.Name = "nudFwdPort";
            this.nudFwdPort.Size = new System.Drawing.Size(120, 20);
            this.nudFwdPort.TabIndex = 3;
            this.nudFwdPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFwdPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lstServers
            // 
            this.lstServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11});
            this.lstServers.ContextMenuStrip = this.contextMenuStrip1;
            this.lstServers.FullRowSelect = true;
            this.lstServers.GridLines = true;
            this.lstServers.Location = new System.Drawing.Point(0, 3);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(350, 109);
            this.lstServers.TabIndex = 16;
            this.lstServers.UseCompatibleStateImageBehavior = false;
            this.lstServers.View = System.Windows.Forms.View.Details;
            this.lstServers.VirtualMode = true;
            this.lstServers.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.LvServers_RetrieveVirtualItem);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Local Port";
            this.columnHeader7.Width = 67;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Remote Host";
            this.columnHeader8.Width = 108;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Remote Port";
            this.columnHeader9.Width = 109;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Status";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tabControlServers
            // 
            this.tabControlServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlServers.Controls.Add(this.tabPage3);
            this.tabControlServers.Location = new System.Drawing.Point(403, 12);
            this.tabControlServers.Name = "tabControlServers";
            this.tabControlServers.SelectedIndex = 0;
            this.tabControlServers.Size = new System.Drawing.Size(361, 134);
            this.tabControlServers.TabIndex = 17;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstServers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(353, 108);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Forward Instances";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FrmPortForwardLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 425);
            this.Controls.Add(this.tabControlServers);
            this.Controls.Add(this.nudFwdPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFwdHost);
            this.Controls.Add(this.tabControlConnections);
            this.Controls.Add(this.nudClientPort);
            this.Controls.Add(this.lblLocalServerPort);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPortForwardLocal";
            this.Text = "Port Forward - Local Machine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPortForwardLocal_FormClosing);
            this.tabControlConnections.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudClientPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFwdPort)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControlServers.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlConnections;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.AeroListView lstConnections;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.NumericUpDown nudClientPort;
        private System.Windows.Forms.Label lblLocalServerPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtFwdHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFwdPort;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private Controls.AeroListView lstServers;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControlServers;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}