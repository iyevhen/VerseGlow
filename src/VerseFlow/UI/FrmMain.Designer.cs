﻿using VerseFlow.UI.Controls;

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
			this.tsSongs = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsSettings = new System.Windows.Forms.ToolStripButton();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainerDisplays = new System.Windows.Forms.SplitContainer();
			this.displayViewPreview = new VerseFlow.UI.Controls.DisplayView();
			this.toolsRight = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.displayViewLive = new VerseFlow.UI.Controls.DisplayView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplays)).BeginInit();
			this.splitContainerDisplays.Panel1.SuspendLayout();
			this.splitContainerDisplays.Panel2.SuspendLayout();
			this.splitContainerDisplays.SuspendLayout();
			this.toolsRight.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsSongs,
            this.tsSettings,
            this.tsAbout});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.ShowItemToolTips = false;
			this.toolStrip2.Size = new System.Drawing.Size(563, 25);
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
			// tsSongs
			// 
			this.tsSongs.Image = global::VerseFlow.Properties.Resources.music_beam;
			this.tsSongs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSongs.Name = "tsSongs";
			this.tsSongs.Size = new System.Drawing.Size(68, 22);
			this.tsSongs.Text = "&Songs";
			this.tsSongs.Visible = false;
			// 
			// tsSettings
			// 
			this.tsSettings.Image = global::VerseFlow.Properties.Resources.wrench_screwdriver;
			this.tsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSettings.Name = "tsSettings";
			this.tsSettings.Size = new System.Drawing.Size(69, 22);
			this.tsSettings.Text = "S&ettings";
			this.tsSettings.Visible = false;
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
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 25);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutTop);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainer1);
			this.splitContainerMain.Size = new System.Drawing.Size(563, 340);
			this.splitContainerMain.SplitterDistance = 154;
			this.splitContainerMain.SplitterWidth = 6;
			this.splitContainerMain.TabIndex = 1;
			// 
			// tableLayoutTop
			// 
			this.tableLayoutTop.ColumnCount = 1;
			this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutTop.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutTop.Name = "tableLayoutTop";
			this.tableLayoutTop.RowCount = 1;
			this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutTop.Size = new System.Drawing.Size(563, 154);
			this.tableLayoutTop.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainerDisplays);
			this.splitContainer1.Size = new System.Drawing.Size(563, 180);
			this.splitContainer1.SplitterDistance = 176;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainerDisplays
			// 
			this.splitContainerDisplays.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerDisplays.Location = new System.Drawing.Point(0, 0);
			this.splitContainerDisplays.Name = "splitContainerDisplays";
			// 
			// splitContainerDisplays.Panel1
			// 
			this.splitContainerDisplays.Panel1.Controls.Add(this.displayViewPreview);
			this.splitContainerDisplays.Panel1.Controls.Add(this.toolsRight);
			// 
			// splitContainerDisplays.Panel2
			// 
			this.splitContainerDisplays.Panel2.Controls.Add(this.displayViewLive);
			this.splitContainerDisplays.Panel2.Controls.Add(this.toolStrip1);
			this.splitContainerDisplays.Size = new System.Drawing.Size(383, 180);
			this.splitContainerDisplays.SplitterDistance = 190;
			this.splitContainerDisplays.TabIndex = 0;
			// 
			// displayViewPreview
			// 
			this.displayViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.displayViewPreview.Etalon = new System.Drawing.Size(4, 3);
			this.displayViewPreview.Location = new System.Drawing.Point(0, 25);
			this.displayViewPreview.Name = "displayViewPreview";
			this.displayViewPreview.Size = new System.Drawing.Size(190, 155);
			this.displayViewPreview.TabIndex = 0;
			// 
			// toolsRight
			// 
			this.toolsRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsGoLive});
			this.toolsRight.Location = new System.Drawing.Point(0, 0);
			this.toolsRight.Name = "toolsRight";
			this.toolsRight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsRight.Size = new System.Drawing.Size(190, 25);
			this.toolsRight.TabIndex = 0;
			this.toolsRight.Text = "toolsRight";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
			this.toolStripLabel1.Text = "Preview";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsGoLive
			// 
			this.tsGoLive.CheckOnClick = true;
			this.tsGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGoLive.Name = "tsGoLive";
			this.tsGoLive.Size = new System.Drawing.Size(50, 22);
			this.tsGoLive.Text = "&Go Live";
			this.tsGoLive.Click += new System.EventHandler(this.tsGoLive_Click);
			// 
			// displayViewLive
			// 
			this.displayViewLive.Dock = System.Windows.Forms.DockStyle.Fill;
			this.displayViewLive.Etalon = new System.Drawing.Size(4, 3);
			this.displayViewLive.Location = new System.Drawing.Point(0, 25);
			this.displayViewLive.Name = "displayViewLive";
			this.displayViewLive.Size = new System.Drawing.Size(189, 155);
			this.displayViewLive.TabIndex = 2;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripButton3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(189, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(30, 22);
			this.toolStripLabel2.Text = "Live";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.CheckOnClick = true;
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
			this.toolStripButton2.Text = "&Freeze";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.CheckOnClick = true;
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(57, 22);
			this.toolStripButton3.Text = "Fill &Black";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 365);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.toolStrip2);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainerDisplays.Panel1.ResumeLayout(false);
			this.splitContainerDisplays.Panel1.PerformLayout();
			this.splitContainerDisplays.Panel2.ResumeLayout(false);
			this.splitContainerDisplays.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplays)).EndInit();
			this.splitContainerDisplays.ResumeLayout(false);
			this.toolsRight.ResumeLayout(false);
			this.toolsRight.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStrip toolsRight;
		private System.Windows.Forms.ToolStripButton tsGoLive;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripDropDownButton tsSongs;
		private System.Windows.Forms.ToolStripButton tsSettings;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miBibleQuote;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tableLayoutTop;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainerDisplays;
		private DisplayView displayViewPreview;
		private DisplayView displayViewLive;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

	}
}

