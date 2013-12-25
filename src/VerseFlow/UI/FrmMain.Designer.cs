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
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
			this.miImport = new System.Windows.Forms.ToolStripMenuItem();
			this.miBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSongs = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsSettings = new System.Windows.Forms.ToolStripButton();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.splitContainerRight = new System.Windows.Forms.SplitContainer();
			this.toolsRight = new System.Windows.Forms.ToolStrip();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.tsFreeze = new System.Windows.Forms.ToolStripButton();
			this.tsBlack = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
			this.splitContainerRight.Panel1.SuspendLayout();
			this.splitContainerRight.Panel2.SuspendLayout();
			this.splitContainerRight.SuspendLayout();
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
			this.toolStrip2.Size = new System.Drawing.Size(724, 25);
			this.toolStrip2.TabIndex = 14;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsBibles
			// 
			this.tsBibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImport});
			this.tsBibles.Image = global::VerseFlow.Properties.Resources.book;
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
			this.tsSongs.Image = global::VerseFlow.Properties.Resources.book_brown;
			this.tsSongs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSongs.Name = "tsSongs";
			this.tsSongs.Size = new System.Drawing.Size(68, 22);
			this.tsSongs.Text = "&Songs";
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
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.tabControl);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRight);
			this.splitContainerMain.Size = new System.Drawing.Size(724, 434);
			this.splitContainerMain.SplitterDistance = 301;
			this.splitContainerMain.SplitterWidth = 6;
			this.splitContainerMain.TabIndex = 13;
			this.splitContainerMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerMain_SplitterMoved);
			// 
			// tabControl
			// 
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(301, 434);
			this.tabControl.TabIndex = 0;
			this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
			// 
			// splitContainerRight
			// 
			this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
			this.splitContainerRight.Name = "splitContainerRight";
			this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerRight.Panel1
			// 
			this.splitContainerRight.Panel1.Controls.Add(this.toolsRight);
			// 
			// splitContainerRight.Panel2
			// 
			this.splitContainerRight.Panel2.Controls.Add(this.toolStrip1);
			this.splitContainerRight.Size = new System.Drawing.Size(417, 434);
			this.splitContainerRight.SplitterDistance = 180;
			this.splitContainerRight.TabIndex = 5;
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
			this.toolsRight.Size = new System.Drawing.Size(417, 25);
			this.toolsRight.TabIndex = 5;
			this.toolsRight.Text = "toolsRight";
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
			this.tsBlack.Size = new System.Drawing.Size(57, 22);
			this.tsBlack.Text = "Fill &Black";
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(417, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.CheckOnClick = true;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(75, 22);
			this.toolStripButton1.Text = "&Background";
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
			this.ClientSize = new System.Drawing.Size(724, 459);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.toolStrip2);
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
			this.splitContainerRight.Panel1.ResumeLayout(false);
			this.splitContainerRight.Panel1.PerformLayout();
			this.splitContainerRight.Panel2.ResumeLayout(false);
			this.splitContainerRight.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
			this.splitContainerRight.ResumeLayout(false);
			this.toolsRight.ResumeLayout(false);
			this.toolsRight.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.ToolStrip toolsRight;
        private System.Windows.Forms.ToolStripButton tsGoLive;
        private System.Windows.Forms.ToolStripButton tsFreeze;
        private System.Windows.Forms.ToolStripButton tsBlack;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripDropDownButton tsSongs;
		private System.Windows.Forms.ToolStripButton tsSettings;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miBibleQuote;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ToolStripButton tsAbout;

	}
}

