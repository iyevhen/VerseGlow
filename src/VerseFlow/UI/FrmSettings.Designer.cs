namespace VerseFlow.UI
{
	partial class FrmSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Fonts and Colors");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("from \"BibleQuote\" (http://bqt.ru)");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("from \"CSV\" file");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Import", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Download");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Bibles", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Import");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Download");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Psalms", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Display");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Updates");
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeSettings = new System.Windows.Forms.TreeView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(494, 323);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(575, 323);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(646, 313);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Categories";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(5, 18);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeSettings);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainer1.Size = new System.Drawing.Size(636, 290);
			this.splitContainer1.SplitterDistance = 262;
			this.splitContainer1.TabIndex = 1;
			// 
			// treeSettings
			// 
			this.treeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeSettings.HideSelection = false;
			this.treeSettings.HotTracking = true;
			this.treeSettings.Indent = 19;
			this.treeSettings.ItemHeight = 16;
			this.treeSettings.Location = new System.Drawing.Point(0, 0);
			this.treeSettings.Margin = new System.Windows.Forms.Padding(10);
			this.treeSettings.Name = "treeSettings";
			treeNode1.Name = "Node0";
			treeNode1.Text = "Fonts and Colors";
			treeNode2.Name = "ndBibleImportBQT";
			treeNode2.Text = "from \"BibleQuote\" (http://bqt.ru)";
			treeNode3.Name = "ndBibleImportCSV";
			treeNode3.Text = "from \"CSV\" file";
			treeNode4.Name = "Node2";
			treeNode4.Text = "Import";
			treeNode5.Name = "Node3";
			treeNode5.Text = "Download";
			treeNode6.Name = "Node1";
			treeNode6.Text = "Bibles";
			treeNode7.Name = "Node5";
			treeNode7.Text = "Import";
			treeNode8.Name = "Node6";
			treeNode8.Text = "Download";
			treeNode9.Name = "Node4";
			treeNode9.Text = "Psalms";
			treeNode10.Name = "Node7";
			treeNode10.Text = "Display";
			treeNode11.Name = "Node0";
			treeNode11.Text = "Updates";
			this.treeSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode9,
            treeNode10,
            treeNode11});
			this.treeSettings.ShowLines = false;
			this.treeSettings.Size = new System.Drawing.Size(262, 290);
			this.treeSettings.TabIndex = 0;
			this.treeSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSettings_AfterSelect);
			// 
			// FrmSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(652, 358);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FrmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeSettings;
	}
}