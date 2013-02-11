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
			this.bibleView1 = new VerseFlow.UI.BibleView();
			this.pnlLeftNavigation = new System.Windows.Forms.Panel();
			this.toolsLeftNavigation = new System.Windows.Forms.ToolStrip();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsSearch = new System.Windows.Forms.ToolStripButton();
			this.tsFullName = new System.Windows.Forms.ToolStripLabel();
			this.toolsRight = new System.Windows.Forms.ToolStrip();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.tsFreeze = new System.Windows.Forms.ToolStripButton();
			this.tsBlack = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.miFile = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.resentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.miImport = new System.Windows.Forms.ToolStripMenuItem();
			this.miImportBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.pnlLeftNavigation.SuspendLayout();
			this.toolsLeftNavigation.SuspendLayout();
			this.toolsRight.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAbout});
			this.statusStrip1.Location = new System.Drawing.Point(0, 467);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(706, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsAbout
			// 
			this.tsAbout.IsLink = true;
			this.tsAbout.LinkColor = System.Drawing.Color.DimGray;
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.tsAbout.Size = new System.Drawing.Size(46, 17);
			this.tsAbout.Text = "About";
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.bibleView1);
			this.splitContainerMain.Panel1.Controls.Add(this.pnlLeftNavigation);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.toolsRight);
			this.splitContainerMain.Size = new System.Drawing.Size(706, 443);
			this.splitContainerMain.SplitterDistance = 323;
			this.splitContainerMain.SplitterWidth = 6;
			this.splitContainerMain.TabIndex = 13;
			// 
			// bibleView1
			// 
			this.bibleView1.AutoSize = true;
			this.bibleView1.CurrentBible = null;
			this.bibleView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bibleView1.Location = new System.Drawing.Point(0, 26);
			this.bibleView1.Name = "bibleView1";
			this.bibleView1.Size = new System.Drawing.Size(323, 417);
			this.bibleView1.TabIndex = 5;
			this.bibleView1.Visible = false;
			// 
			// pnlLeftNavigation
			// 
			this.pnlLeftNavigation.Controls.Add(this.toolsLeftNavigation);
			this.pnlLeftNavigation.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlLeftNavigation.Location = new System.Drawing.Point(0, 0);
			this.pnlLeftNavigation.Name = "pnlLeftNavigation";
			this.pnlLeftNavigation.Size = new System.Drawing.Size(323, 26);
			this.pnlLeftNavigation.TabIndex = 4;
			// 
			// toolsLeftNavigation
			// 
			this.toolsLeftNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolsLeftNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFont,
            this.tsSearch,
            this.tsFullName});
			this.toolsLeftNavigation.Location = new System.Drawing.Point(0, 0);
			this.toolsLeftNavigation.Name = "toolsLeftNavigation";
			this.toolsLeftNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsLeftNavigation.ShowItemToolTips = false;
			this.toolsLeftNavigation.Size = new System.Drawing.Size(323, 25);
			this.toolsLeftNavigation.TabIndex = 4;
			this.toolsLeftNavigation.Text = "toolsLeftNavigation";
			// 
			// tsFont
			// 
			this.tsFont.Image = global::VerseFlow.Properties.Resources._font;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(53, 22);
			this.tsFont.Text = "Font";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// tsSearch
			// 
			this.tsSearch.CheckOnClick = true;
			this.tsSearch.Image = global::VerseFlow.Properties.Resources._magnifier;
			this.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSearch.Name = "tsSearch";
			this.tsSearch.Size = new System.Drawing.Size(68, 22);
			this.tsSearch.Text = "Search";
			// 
			// tsFullName
			// 
			this.tsFullName.Image = global::VerseFlow.Properties.Resources._book_open;
			this.tsFullName.Name = "tsFullName";
			this.tsFullName.Size = new System.Drawing.Size(95, 22);
			this.tsFullName.Text = "<FullName>";
			// 
			// toolsRight
			// 
			this.toolsRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGoLive,
            this.tsFreeze,
            this.tsBlack});
			this.toolsRight.Location = new System.Drawing.Point(0, 0);
			this.toolsRight.Name = "toolsRight";
			this.toolsRight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolsRight.Size = new System.Drawing.Size(377, 25);
			this.toolsRight.TabIndex = 4;
			this.toolsRight.Text = "toolsRight";
			// 
			// tsGoLive
			// 
			this.tsGoLive.CheckOnClick = true;
			this.tsGoLive.Image = global::VerseFlow.Properties.Resources._cctv_camera;
			this.tsGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGoLive.Name = "tsGoLive";
			this.tsGoLive.Size = new System.Drawing.Size(69, 22);
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
			this.tsFreeze.Size = new System.Drawing.Size(51, 22);
			this.tsFreeze.Text = "&Freeze";
			// 
			// tsBlack
			// 
			this.tsBlack.CheckOnClick = true;
			this.tsBlack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBlack.Image = ((System.Drawing.Image)(resources.GetObject("tsBlack.Image")));
			this.tsBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBlack.Name = "tsBlack";
			this.tsBlack.Size = new System.Drawing.Size(61, 22);
			this.tsBlack.Text = "Fill &Black";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.editToolStripMenuItem,
            this.miOpen,
            this.miImport,
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(706, 24);
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.resentToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(40, 20);
			this.miFile.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
			// 
			// resentToolStripMenuItem
			// 
			this.resentToolStripMenuItem.Name = "resentToolStripMenuItem";
			this.resentToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.resentToolStripMenuItem.Text = "Recent opened";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// miOpen
			// 
			this.miOpen.Name = "miOpen";
			this.miOpen.Size = new System.Drawing.Size(50, 20);
			this.miOpen.Text = "Open";
			this.miOpen.DropDownOpening += new System.EventHandler(this.tsOpen_DropDownOpening);
			this.miOpen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsOpen_DropDownItemClicked);
			// 
			// miImport
			// 
			this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportBibleQuote});
			this.miImport.Name = "miImport";
			this.miImport.Size = new System.Drawing.Size(58, 20);
			this.miImport.Text = "Import";
			// 
			// miImportBibleQuote
			// 
			this.miImportBibleQuote.Name = "miImportBibleQuote";
			this.miImportBibleQuote.Size = new System.Drawing.Size(199, 22);
			this.miImportBibleQuote.Text = "Bible from BibleQuote";
			this.miImportBibleQuote.Click += new System.EventHandler(this.bibleFromBibleQuoteToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.settingsToolStripMenuItem.Text = "Options";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.searchToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Image = global::VerseFlow.Properties.Resources._font;
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.fontToolStripMenuItem.Text = "Font";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Image = global::VerseFlow.Properties.Resources._magnifier;
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 489);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
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
			this.toolsRight.ResumeLayout(false);
			this.toolsRight.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.ToolStrip toolsRight;
		private System.Windows.Forms.ToolStripButton tsGoLive;
		private System.Windows.Forms.ToolStripButton tsBlack;
		private System.Windows.Forms.ToolStripButton tsFreeze;
		private System.Windows.Forms.ToolStripStatusLabel tsAbout;
		private System.Windows.Forms.Panel pnlLeftNavigation;
		private System.Windows.Forms.ToolStrip toolsLeftNavigation;
		private System.Windows.Forms.ToolStripButton tsSearch;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem miOpen;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miImportBibleQuote;
		private BibleView bibleView1;
		private System.Windows.Forms.ToolStripLabel tsFullName;
		private System.Windows.Forms.ToolStripMenuItem miFile;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem resentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;

	}
}

