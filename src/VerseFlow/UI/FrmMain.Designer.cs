using VerseFlow.UI.Controls;

namespace VerseFlow.UI
{
	partial class FrmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsAbout = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.pnlLeftNavigation = new System.Windows.Forms.Panel();
			this.toolsLeftNavigation = new System.Windows.Forms.ToolStrip();
			this.cmbContents = new System.Windows.Forms.ToolStripComboBox();
			this.cmbChapters = new System.Windows.Forms.ToolStripComboBox();
			this.cmbFind = new System.Windows.Forms.ToolStripComboBox();
			this.tsFind = new System.Windows.Forms.ToolStripButton();
			this.lblOpened = new System.Windows.Forms.Label();
			this.toolsLeft = new System.Windows.Forms.ToolStrip();
			this.tsOpen = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsImport = new System.Windows.Forms.ToolStripDropDownButton();
			this.bibleFromBibleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsBackColor = new System.Windows.Forms.ToolStripButton();
			this.toolsRight = new System.Windows.Forms.ToolStrip();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.tsFreeze = new System.Windows.Forms.ToolStripButton();
			this.tsBlack = new System.Windows.Forms.ToolStripButton();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.statusStrip1.SuspendLayout();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.pnlLeftNavigation.SuspendLayout();
			this.toolsLeftNavigation.SuspendLayout();
			this.toolsLeft.SuspendLayout();
			this.toolsRight.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAbout});
			this.statusStrip1.Location = new System.Drawing.Point(0, 393);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(656, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsAbout
			// 
			this.tsAbout.IsLink = true;
			this.tsAbout.LinkColor = System.Drawing.Color.DimGray;
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.tsAbout.Size = new System.Drawing.Size(41, 17);
			this.tsAbout.Text = "About";
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.verseView1);
			this.splitContainerMain.Panel1.Controls.Add(this.pnlLeftNavigation);
			this.splitContainerMain.Panel1.Controls.Add(this.lblOpened);
			this.splitContainerMain.Panel1.Controls.Add(this.toolsLeft);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.toolsRight);
			this.splitContainerMain.Size = new System.Drawing.Size(656, 393);
			this.splitContainerMain.SplitterDistance = 313;
			this.splitContainerMain.SplitterWidth = 6;
			this.splitContainerMain.TabIndex = 13;
			// 
			// pnlLeftNavigation
			// 
			this.pnlLeftNavigation.Controls.Add(this.toolsLeftNavigation);
			this.pnlLeftNavigation.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlLeftNavigation.Location = new System.Drawing.Point(0, 42);
			this.pnlLeftNavigation.Name = "pnlLeftNavigation";
			this.pnlLeftNavigation.Size = new System.Drawing.Size(313, 26);
			this.pnlLeftNavigation.TabIndex = 4;
			// 
			// toolsLeftNavigation
			// 
			this.toolsLeftNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolsLeftNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbContents,
            this.cmbChapters,
            this.cmbFind,
            this.tsFind});
			this.toolsLeftNavigation.Location = new System.Drawing.Point(0, 0);
			this.toolsLeftNavigation.Name = "toolsLeftNavigation";
			this.toolsLeftNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsLeftNavigation.ShowItemToolTips = false;
			this.toolsLeftNavigation.Size = new System.Drawing.Size(313, 25);
			this.toolsLeftNavigation.TabIndex = 4;
			this.toolsLeftNavigation.Text = "toolsLeftNavigation";
			// 
			// cmbContents
			// 
			this.cmbContents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbContents.DropDownWidth = 300;
			this.cmbContents.Name = "cmbContents";
			this.cmbContents.Size = new System.Drawing.Size(150, 25);
			this.cmbContents.SelectedIndexChanged += new System.EventHandler(this.cmbContents_SelectedIndexChanged);
			// 
			// cmbChapters
			// 
			this.cmbChapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChapters.Name = "cmbChapters";
			this.cmbChapters.Size = new System.Drawing.Size(75, 25);
			this.cmbChapters.SelectedIndexChanged += new System.EventHandler(this.cmbChapters_SelectedIndexChanged);
			// 
			// cmbFind
			// 
			this.cmbFind.DropDownWidth = 300;
			this.cmbFind.Name = "cmbFind";
			this.cmbFind.Size = new System.Drawing.Size(121, 21);
			this.cmbFind.Visible = false;
			// 
			// tsFind
			// 
			this.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFind.Image = global::VerseFlow.Properties.Resources._1357146337_find;
			this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFind.Name = "tsFind";
			this.tsFind.Size = new System.Drawing.Size(23, 22);
			this.tsFind.Text = "Find";
			this.tsFind.Visible = false;
			// 
			// lblOpened
			// 
			this.lblOpened.AutoSize = true;
			this.lblOpened.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblOpened.ForeColor = System.Drawing.Color.DimGray;
			this.lblOpened.Location = new System.Drawing.Point(0, 25);
			this.lblOpened.Name = "lblOpened";
			this.lblOpened.Padding = new System.Windows.Forms.Padding(2);
			this.lblOpened.Size = new System.Drawing.Size(43, 17);
			this.lblOpened.TabIndex = 2;
			this.lblOpened.Text = "<Title>";
			// 
			// toolsLeft
			// 
			this.toolsLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpen,
            this.tsImport,
            this.toolStripSeparator1,
            this.tsFont,
            this.tsBackColor});
			this.toolsLeft.Location = new System.Drawing.Point(0, 0);
			this.toolsLeft.Name = "toolsLeft";
			this.toolsLeft.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsLeft.Size = new System.Drawing.Size(313, 25);
			this.toolsLeft.TabIndex = 3;
			this.toolsLeft.Text = "toolsLeft";
			// 
			// tsOpen
			// 
			this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsOpen.Image")));
			this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsOpen.Name = "tsOpen";
			this.tsOpen.Size = new System.Drawing.Size(46, 22);
			this.tsOpen.Text = "&Open";
			this.tsOpen.DropDownOpening += new System.EventHandler(this.tsOpen_DropDownOpening);
			this.tsOpen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsOpen_DropDownItemClicked);
			// 
			// tsImport
			// 
			this.tsImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleFromBibleQuoteToolStripMenuItem});
			this.tsImport.Image = ((System.Drawing.Image)(resources.GetObject("tsImport.Image")));
			this.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsImport.Name = "tsImport";
			this.tsImport.Size = new System.Drawing.Size(52, 22);
			this.tsImport.Text = "&Import";
			// 
			// bibleFromBibleQuoteToolStripMenuItem
			// 
			this.bibleFromBibleQuoteToolStripMenuItem.Name = "bibleFromBibleQuoteToolStripMenuItem";
			this.bibleFromBibleQuoteToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.bibleFromBibleQuoteToolStripMenuItem.Text = "Bible from BibleQuote";
			this.bibleFromBibleQuoteToolStripMenuItem.Click += new System.EventHandler(this.bibleFromBibleQuoteToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsFont
			// 
			this.tsFont.Image = global::VerseFlow.Properties.Resources._1357145973_font;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(49, 22);
			this.tsFont.Text = "Fon&t";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// tsBackColor
			// 
			this.tsBackColor.Image = global::VerseFlow.Properties.Resources._1360462391_color_picker_alternative;
			this.tsBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBackColor.Name = "tsBackColor";
			this.tsBackColor.Size = new System.Drawing.Size(77, 22);
			this.tsBackColor.Text = "Back &Color";
			this.tsBackColor.Click += new System.EventHandler(this.tsColor_Click);
			// 
			// toolsRight
			// 
			this.toolsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGoLive,
            this.tsFreeze,
            this.tsBlack});
			this.toolsRight.Location = new System.Drawing.Point(0, 0);
			this.toolsRight.Name = "toolsRight";
			this.toolsRight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsRight.Size = new System.Drawing.Size(337, 25);
			this.toolsRight.TabIndex = 4;
			this.toolsRight.Text = "toolsRight";
			// 
			// tsGoLive
			// 
			this.tsGoLive.CheckOnClick = true;
			this.tsGoLive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.tsGoLive.Image = global::VerseFlow.Properties.Resources._1357332757_cctv_camera;
			this.tsGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGoLive.Name = "tsGoLive";
			this.tsGoLive.Size = new System.Drawing.Size(68, 22);
			this.tsGoLive.Text = "&Go Live";
			this.tsGoLive.Click += new System.EventHandler(this.tsGoLive_Click);
			// 
			// tsFreeze
			// 
			this.tsFreeze.CheckOnClick = true;
			this.tsFreeze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsFreeze.Image = ((System.Drawing.Image)(resources.GetObject("tsFreeze.Image")));
			this.tsFreeze.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFreeze.Name = "tsFreeze";
			this.tsFreeze.Size = new System.Drawing.Size(44, 22);
			this.tsFreeze.Text = "&Freeze";
			// 
			// tsBlack
			// 
			this.tsBlack.CheckOnClick = true;
			this.tsBlack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBlack.Image = ((System.Drawing.Image)(resources.GetObject("tsBlack.Image")));
			this.tsBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBlack.Name = "tsBlack";
			this.tsBlack.Size = new System.Drawing.Size(50, 22);
			this.tsBlack.Text = "Fill &Black";
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(276, 0);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 68);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(313, 325);
			this.verseView1.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(656, 415);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel1.PerformLayout();
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.Panel2.PerformLayout();
			this.splitContainerMain.ResumeLayout(false);
			this.pnlLeftNavigation.ResumeLayout(false);
			this.pnlLeftNavigation.PerformLayout();
			this.toolsLeftNavigation.ResumeLayout(false);
			this.toolsLeftNavigation.PerformLayout();
			this.toolsLeft.ResumeLayout(false);
			this.toolsLeft.PerformLayout();
			this.toolsRight.ResumeLayout(false);
			this.toolsRight.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private VerseView verseView1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.Label lblOpened;
		private System.Windows.Forms.ToolStrip toolsLeft;
		private System.Windows.Forms.ToolStripDropDownButton tsOpen;
		private System.Windows.Forms.ToolStripDropDownButton tsImport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsBackColor;
		private System.Windows.Forms.ToolStrip toolsRight;
		private System.Windows.Forms.ToolStripButton tsGoLive;
		private System.Windows.Forms.ToolStripButton tsBlack;
		private System.Windows.Forms.ToolStripButton tsFreeze;
		private System.Windows.Forms.ToolStripStatusLabel tsAbout;
		private System.Windows.Forms.Panel pnlLeftNavigation;
		private System.Windows.Forms.ToolStrip toolsLeftNavigation;
		private System.Windows.Forms.ToolStripComboBox cmbContents;
		private System.Windows.Forms.ToolStripComboBox cmbChapters;
		private System.Windows.Forms.ToolStripComboBox cmbFind;
		private System.Windows.Forms.ToolStripButton tsFind;
		private System.Windows.Forms.ToolStripMenuItem bibleFromBibleQuoteToolStripMenuItem;

	}
}

