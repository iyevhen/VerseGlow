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
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.tsImport = new System.Windows.Forms.ToolStripDropDownButton();
			this.bibleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tblBibles = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tblDisplay = new System.Windows.Forms.TableLayoutPanel();
			this.displayView1 = new VerseFlow.UI.Controls.DisplayView();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tblDisplay.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsAbout,
            this.tsImport});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.ShowItemToolTips = false;
			this.toolStrip2.Size = new System.Drawing.Size(406, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsBibles
			// 
			this.tsBibles.Image = global::VerseFlow.Properties.Resources.book_open;
			this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBibles.Name = "tsBibles";
			this.tsBibles.Size = new System.Drawing.Size(94, 22);
			this.tsBibles.Text = "&Open Bible";
			this.tsBibles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBibles_DropDownItemClicked);
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
			// tsImport
			// 
			this.tsImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleQuoteToolStripMenuItem});
			this.tsImport.Image = global::VerseFlow.Properties.Resources._1402077846_inbox_download;
			this.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsImport.Name = "tsImport";
			this.tsImport.Size = new System.Drawing.Size(101, 22);
			this.tsImport.Text = "&Import Bible";
			// 
			// bibleQuoteToolStripMenuItem
			// 
			this.bibleQuoteToolStripMenuItem.Name = "bibleQuoteToolStripMenuItem";
			this.bibleQuoteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.bibleQuoteToolStripMenuItem.Text = "BibleQuote";
			this.bibleQuoteToolStripMenuItem.Click += new System.EventHandler(this.miBibleQuote_Click);
			// 
			// tblBibles
			// 
			this.tblBibles.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tblBibles.ColumnCount = 1;
			this.tblBibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 674F));
			this.tblBibles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblBibles.Location = new System.Drawing.Point(0, 25);
			this.tblBibles.Margin = new System.Windows.Forms.Padding(0);
			this.tblBibles.Name = "tblBibles";
			this.tblBibles.RowCount = 1;
			this.tblBibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblBibles.Size = new System.Drawing.Size(406, 449);
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
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tblBibles);
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
			this.splitContainer1.Size = new System.Drawing.Size(723, 478);
			this.splitContainer1.SplitterDistance = 311;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 3;
			// 
			// tblDisplay
			// 
			this.tblDisplay.AutoSize = true;
			this.tblDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tblDisplay.ColumnCount = 1;
			this.tblDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Controls.Add(this.displayView1, 0, 0);
			this.tblDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblDisplay.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tblDisplay.Location = new System.Drawing.Point(0, 0);
			this.tblDisplay.Margin = new System.Windows.Forms.Padding(0);
			this.tblDisplay.Name = "tblDisplay";
			this.tblDisplay.RowCount = 1;
			this.tblDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Size = new System.Drawing.Size(307, 474);
			this.tblDisplay.TabIndex = 4;
			// 
			// displayView1
			// 
			this.displayView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.displayView1.Location = new System.Drawing.Point(2, 2);
			this.displayView1.Margin = new System.Windows.Forms.Padding(0);
			this.displayView1.Name = "displayView1";
			this.displayView1.Size = new System.Drawing.Size(303, 470);
			this.displayView1.TabIndex = 2;
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
			this.tblDisplay.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tblBibles;
		private DisplayView displayView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tblDisplay;
		private System.Windows.Forms.ToolStripDropDownButton tsImport;
		private System.Windows.Forms.ToolStripMenuItem bibleQuoteToolStripMenuItem;

	}
}

