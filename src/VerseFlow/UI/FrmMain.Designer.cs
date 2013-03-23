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
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.toolsLeftNavigation = new System.Windows.Forms.ToolStrip();
			this.txtHighlight = new System.Windows.Forms.ToolStripTextBox();
			this.tsSearch = new System.Windows.Forms.ToolStripButton();
			this.tsHighlight = new System.Windows.Forms.ToolStripButton();
			this.toolsRight = new System.Windows.Forms.ToolStrip();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.tsFreeze = new System.Windows.Forms.ToolStripButton();
			this.tsBlack = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.miFile = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bibleQuoteModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.resentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.bibleView1 = new VerseFlow.UI.BibleView();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.toolsLeftNavigation.SuspendLayout();
			this.toolsRight.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 366);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(749, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
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
			this.splitContainerMain.Panel1.Controls.Add(this.toolsLeftNavigation);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.toolsRight);
			this.splitContainerMain.Size = new System.Drawing.Size(749, 342);
			this.splitContainerMain.SplitterDistance = 341;
			this.splitContainerMain.SplitterWidth = 6;
			this.splitContainerMain.TabIndex = 13;
			// 
			// toolsLeftNavigation
			// 
			this.toolsLeftNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolsLeftNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtHighlight,
            this.tsSearch,
            this.tsHighlight});
			this.toolsLeftNavigation.Location = new System.Drawing.Point(0, 0);
			this.toolsLeftNavigation.Name = "toolsLeftNavigation";
			this.toolsLeftNavigation.ShowItemToolTips = false;
			this.toolsLeftNavigation.Size = new System.Drawing.Size(341, 25);
			this.toolsLeftNavigation.TabIndex = 4;
			this.toolsLeftNavigation.Text = "toolsLeftNavigation";
			// 
			// txtHighlight
			// 
			this.txtHighlight.Name = "txtHighlight";
			this.txtHighlight.Size = new System.Drawing.Size(150, 25);
			// 
			// tsSearch
			// 
			this.tsSearch.CheckOnClick = true;
			this.tsSearch.Image = global::VerseFlow.Properties.Resources._magnifier;
			this.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSearch.Name = "tsSearch";
			this.tsSearch.Size = new System.Drawing.Size(85, 22);
			this.tsSearch.Text = "OpenVerses";
			// 
			// tsHighlight
			// 
			this.tsHighlight.Image = global::VerseFlow.Properties.Resources._billiard_marker;
			this.tsHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsHighlight.Name = "tsHighlight";
			this.tsHighlight.Size = new System.Drawing.Size(68, 22);
			this.tsHighlight.Text = "Highlight";
			this.tsHighlight.Click += new System.EventHandler(this.tsHighlight_Click);
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
			this.toolsRight.Size = new System.Drawing.Size(402, 25);
			this.toolsRight.TabIndex = 4;
			this.toolsRight.Text = "toolsRight";
			// 
			// tsGoLive
			// 
			this.tsGoLive.CheckOnClick = true;
			this.tsGoLive.Image = global::VerseFlow.Properties.Resources._cctv_camera;
			this.tsGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGoLive.Name = "tsGoLive";
			this.tsGoLive.Size = new System.Drawing.Size(62, 22);
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
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.miOpen,
            this.toolStripMenuItem2});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(749, 24);
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripMenuItem1,
            this.resentToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(35, 20);
			this.miFile.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleQuoteModuleToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.importToolStripMenuItem.Text = "Import";
			// 
			// bibleQuoteModuleToolStripMenuItem
			// 
			this.bibleQuoteModuleToolStripMenuItem.Name = "bibleQuoteModuleToolStripMenuItem";
			this.bibleQuoteModuleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.bibleQuoteModuleToolStripMenuItem.Text = "BibleQuote Module";
			this.bibleQuoteModuleToolStripMenuItem.Click += new System.EventHandler(this.bibleFromBibleQuoteToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
			// 
			// resentToolStripMenuItem
			// 
			this.resentToolStripMenuItem.Name = "resentToolStripMenuItem";
			this.resentToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.resentToolStripMenuItem.Text = "Recent";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.searchToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Image = global::VerseFlow.Properties.Resources._font;
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.fontToolStripMenuItem.Text = "Font";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Image = global::VerseFlow.Properties.Resources._magnifier;
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.searchToolStripMenuItem.Text = "OpenVerses";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.settingsToolStripMenuItem.Text = "Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// miOpen
			// 
			this.miOpen.Name = "miOpen";
			this.miOpen.Size = new System.Drawing.Size(45, 20);
			this.miOpen.Text = "Open";
			this.miOpen.DropDownOpening += new System.EventHandler(this.tsOpen_DropDownOpening);
			this.miOpen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsOpen_DropDownItemClicked);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem2.Text = "?";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// bibleView1
			// 
			this.bibleView1.AutoSize = true;
			this.bibleView1.CurrentBible = null;
			this.bibleView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bibleView1.Location = new System.Drawing.Point(0, 25);
			this.bibleView1.Name = "bibleView1";
			this.bibleView1.Size = new System.Drawing.Size(341, 317);
			this.bibleView1.TabIndex = 5;
			this.bibleView1.Visible = false;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 388);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel1.PerformLayout();
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.Panel2.PerformLayout();
			this.splitContainerMain.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStrip toolsLeftNavigation;
		private System.Windows.Forms.ToolStripButton tsSearch;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem miOpen;
		private BibleView bibleView1;
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
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripTextBox txtHighlight;
		private System.Windows.Forms.ToolStripButton tsHighlight;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bibleQuoteModuleToolStripMenuItem;

	}
}

