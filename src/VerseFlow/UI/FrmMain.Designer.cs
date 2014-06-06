using VerseFlow.UI.Controls;

namespace VerseFlow.UI
{
	partial class FrmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
			this.miImport = new System.Windows.Forms.ToolStripMenuItem();
			this.miBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.tblBibles = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsDisplay = new System.Windows.Forms.ToolStripDropDownButton();
			this.tblDisplay = new System.Windows.Forms.TableLayoutPanel();
			this.displayLiveView1 = new VerseFlow.UI.Controls.DisplayLiveView();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tblDisplay.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsAbout});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.ShowItemToolTips = false;
			this.toolStrip2.Size = new System.Drawing.Size(404, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsBibles
			// 
			this.tsBibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImport});
			this.tsBibles.Image = global::VerseFlow.Properties.Resources.book_open;
			this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBibles.Name = "tsBibles";
			this.tsBibles.Size = new System.Drawing.Size(67, 22);
			this.tsBibles.Text = "&Bibles";
			this.tsBibles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBibles_DropDownItemClicked);
			// 
			// miImport
			// 
			this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBibleQuote});
			this.miImport.Name = "miImport";
			this.miImport.Size = new System.Drawing.Size(110, 22);
			this.miImport.Text = "Import";
			// 
			// miBibleQuote
			// 
			this.miBibleQuote.Name = "miBibleQuote";
			this.miBibleQuote.Size = new System.Drawing.Size(133, 22);
			this.miBibleQuote.Text = "BibleQuote";
			this.miBibleQuote.Click += new System.EventHandler(this.miBibleQuote_Click);
			// 
			// tsAbout
			// 
			this.tsAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsAbout.Image = global::VerseFlow.Properties.Resources.information;
			this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Size = new System.Drawing.Size(23, 22);
			this.tsAbout.Text = "About";
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// tblBibles
			// 
			this.tblBibles.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
			this.tblBibles.ColumnCount = 1;
			this.tblBibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 646F));
			this.tblBibles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblBibles.Location = new System.Drawing.Point(0, 25);
			this.tblBibles.Margin = new System.Windows.Forms.Padding(0);
			this.tblBibles.Name = "tblBibles";
			this.tblBibles.RowCount = 1;
			this.tblBibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblBibles.Size = new System.Drawing.Size(404, 449);
			this.tblBibles.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tblDisplay);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tblBibles);
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
			this.splitContainer1.Size = new System.Drawing.Size(723, 478);
			this.splitContainer1.SplitterDistance = 311;
			this.splitContainer1.TabIndex = 3;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDisplay});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.ShowItemToolTips = false;
			this.toolStrip1.Size = new System.Drawing.Size(307, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsDisplay
			// 
			this.tsDisplay.Image = global::VerseFlow.Properties.Resources.monitor;
			this.tsDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDisplay.Name = "tsDisplay";
			this.tsDisplay.Size = new System.Drawing.Size(74, 22);
			this.tsDisplay.Text = "Display";
			this.tsDisplay.DropDownOpening += new System.EventHandler(this.tsDisplay_DropDownOpening);
			// 
			// tblDisplay
			// 
			this.tblDisplay.AutoSize = true;
			this.tblDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
			this.tblDisplay.ColumnCount = 1;
			this.tblDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Controls.Add(this.displayLiveView1, 0, 0);
			this.tblDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblDisplay.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tblDisplay.Location = new System.Drawing.Point(0, 25);
			this.tblDisplay.Margin = new System.Windows.Forms.Padding(0);
			this.tblDisplay.Name = "tblDisplay";
			this.tblDisplay.RowCount = 1;
			this.tblDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Size = new System.Drawing.Size(307, 449);
			this.tblDisplay.TabIndex = 4;
			// 
			// displayLiveView1
			// 
			this.displayLiveView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.displayLiveView1.Location = new System.Drawing.Point(2, 2);
			this.displayLiveView1.Margin = new System.Windows.Forms.Padding(0);
			this.displayLiveView1.Name = "displayLiveView1";
			this.displayLiveView1.Size = new System.Drawing.Size(303, 445);
			this.displayLiveView1.TabIndex = 2;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 478);
			this.Controls.Add(this.splitContainer1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tblDisplay.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miBibleQuote;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tblBibles;
		private DisplayLiveView displayLiveView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton tsDisplay;
		private System.Windows.Forms.TableLayoutPanel tblDisplay;

	}
}

