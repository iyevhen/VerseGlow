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


		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripBibles = new System.Windows.Forms.ToolStrip();
            this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAbout = new System.Windows.Forms.ToolStripButton();
            this.tblBibles = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tblDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.displayView = new VerseFlow.UI.Controls.DisplayView();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsDisplay = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tblDisplay.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripBibles
            // 
            this.toolStripBibles.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripBibles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBibles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsAbout});
            this.toolStripBibles.Location = new System.Drawing.Point(0, 0);
            this.toolStripBibles.Name = "toolStripBibles";
            this.toolStripBibles.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.toolStripBibles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripBibles.ShowItemToolTips = false;
            this.toolStripBibles.Size = new System.Drawing.Size(439, 25);
            this.toolStripBibles.TabIndex = 0;
            this.toolStripBibles.Text = "toolStrip2";
            // 
            // tsBibles
            // 
            this.tsBibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsBibleQuote});
            this.tsBibles.Image = global::VerseFlow.Properties.Resources.book;
            this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBibles.Name = "tsBibles";
            this.tsBibles.Size = new System.Drawing.Size(67, 22);
            this.tsBibles.Text = "&Bibles";
            this.tsBibles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBibles_DropDownItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // tsBibleQuote
            // 
            this.tsBibleQuote.Image = global::VerseFlow.Properties.Resources._1402077846_inbox_download;
            this.tsBibleQuote.Name = "tsBibleQuote";
            this.tsBibleQuote.Size = new System.Drawing.Size(133, 22);
            this.tsBibleQuote.Text = "BibleQuote";
            this.tsBibleQuote.Click += new System.EventHandler(this.miBibleQuote_Click);
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
            this.tblBibles.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tblBibles.ColumnCount = 1;
            this.tblBibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 657F));
            this.tblBibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBibles.Location = new System.Drawing.Point(0, 25);
            this.tblBibles.Margin = new System.Windows.Forms.Padding(0);
            this.tblBibles.Name = "tblBibles";
            this.tblBibles.RowCount = 1;
            this.tblBibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBibles.Size = new System.Drawing.Size(439, 497);
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStripMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tblBibles);
            this.splitContainer1.Panel2.Controls.Add(this.toolStripBibles);
            this.splitContainer1.Size = new System.Drawing.Size(780, 526);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // tblDisplay
            // 
            this.tblDisplay.AutoSize = true;
            this.tblDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tblDisplay.ColumnCount = 1;
            this.tblDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDisplay.Controls.Add(this.displayView, 0, 0);
            this.tblDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDisplay.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblDisplay.Location = new System.Drawing.Point(0, 25);
            this.tblDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.tblDisplay.Name = "tblDisplay";
            this.tblDisplay.RowCount = 1;
            this.tblDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDisplay.Size = new System.Drawing.Size(331, 497);
            this.tblDisplay.TabIndex = 4;
            // 
            // displayView
            // 
            this.displayView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayView.FullScreen = false;
            this.displayView.Location = new System.Drawing.Point(2, 2);
            this.displayView.Margin = new System.Windows.Forms.Padding(0);
            this.displayView.Name = "displayView";
            this.displayView.Size = new System.Drawing.Size(327, 493);
            this.displayView.TabIndex = 2;
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDisplay,
            this.toolStripButton1});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(331, 25);
            this.toolStripMain.TabIndex = 7;
            this.toolStripMain.Text = "toolStrip1";
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 526);
            this.Controls.Add(this.splitContainer1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStripBibles.ResumeLayout(false);
            this.toolStripBibles.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tblDisplay.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripBibles;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tblBibles;
		private DisplayView displayView;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tblDisplay;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripDropDownButton tsDisplay;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsBibleQuote;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

	}
}

