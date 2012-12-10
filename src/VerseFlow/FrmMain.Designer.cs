namespace VerseFlow
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.bibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.verseRect8 = new VerseFlow.Controls.VerseRect.VerseRect();
			this.verseRect4 = new VerseFlow.Controls.VerseRect.VerseRect();
			this.verseRect2 = new VerseFlow.Controls.VerseRect.VerseRect();
			this.verseRect3 = new VerseFlow.Controls.VerseRect.VerseRect();
			this.verseRect1 = new VerseFlow.Controls.VerseRect.VerseRect();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleToolStripMenuItem,
            this.songToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(749, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// bibleToolStripMenuItem
			// 
			this.bibleToolStripMenuItem.Name = "bibleToolStripMenuItem";
			this.bibleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.bibleToolStripMenuItem.Text = "Bibles";
			// 
			// songToolStripMenuItem
			// 
			this.songToolStripMenuItem.Name = "songToolStripMenuItem";
			this.songToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.songToolStripMenuItem.Text = "Psalms";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromToolStripMenuItem,
            this.exportToToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// importFromToolStripMenuItem
			// 
			this.importFromToolStripMenuItem.Name = "importFromToolStripMenuItem";
			this.importFromToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.importFromToolStripMenuItem.Text = "Import from";
			// 
			// exportToToolStripMenuItem
			// 
			this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
			this.exportToToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.exportToToolStripMenuItem.Text = "Export to";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(749, 459);
			this.splitContainer1.SplitterDistance = 412;
			this.splitContainer1.TabIndex = 4;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(412, 459);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(404, 433);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.verseRect8);
			this.panel1.Controls.Add(this.verseRect4);
			this.panel1.Controls.Add(this.verseRect2);
			this.panel1.Controls.Add(this.verseRect3);
			this.panel1.Controls.Add(this.verseRect1);
			this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(398, 427);
			this.panel1.TabIndex = 3;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(277, 471);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// verseRect8
			// 
			this.verseRect8.CornerRadius = 12;
			this.verseRect8.Dock = System.Windows.Forms.DockStyle.Top;
			this.verseRect8.ForeColor = System.Drawing.Color.Black;
			this.verseRect8.Location = new System.Drawing.Point(0, 289);
			this.verseRect8.Name = "verseRect8";
			this.verseRect8.Size = new System.Drawing.Size(398, 102);
			this.verseRect8.TabIndex = 6;
			this.verseRect8.Text = resources.GetString("verseRect8.Text");
			// 
			// verseRect4
			// 
			this.verseRect4.CornerRadius = 12;
			this.verseRect4.Dock = System.Windows.Forms.DockStyle.Top;
			this.verseRect4.ForeColor = System.Drawing.Color.Black;
			this.verseRect4.Location = new System.Drawing.Point(0, 238);
			this.verseRect4.Name = "verseRect4";
			this.verseRect4.Size = new System.Drawing.Size(398, 51);
			this.verseRect4.TabIndex = 5;
			this.verseRect4.Text = "I think that this is really a minor problem, but you can always use the first met" +
    "hod, just don’t think that it is perfect, it has its own problems… What option w" +
    "ould you use?";
			// 
			// verseRect2
			// 
			this.verseRect2.CornerRadius = 12;
			this.verseRect2.Dock = System.Windows.Forms.DockStyle.Top;
			this.verseRect2.ForeColor = System.Drawing.Color.Black;
			this.verseRect2.Location = new System.Drawing.Point(0, 204);
			this.verseRect2.Name = "verseRect2";
			this.verseRect2.Size = new System.Drawing.Size(398, 34);
			this.verseRect2.TabIndex = 4;
			this.verseRect2.Text = "The MeasureText is a static method of the TextRenderer class so it looks perfect." +
    " ";
			// 
			// verseRect3
			// 
			this.verseRect3.CornerRadius = 12;
			this.verseRect3.Dock = System.Windows.Forms.DockStyle.Top;
			this.verseRect3.ForeColor = System.Drawing.Color.Black;
			this.verseRect3.Location = new System.Drawing.Point(0, 102);
			this.verseRect3.Name = "verseRect3";
			this.verseRect3.Size = new System.Drawing.Size(398, 102);
			this.verseRect3.TabIndex = 3;
			this.verseRect3.Text = resources.GetString("verseRect3.Text");
			// 
			// verseRect1
			// 
			this.verseRect1.CornerRadius = 1;
			this.verseRect1.Dock = System.Windows.Forms.DockStyle.Top;
			this.verseRect1.Enabled = false;
			this.verseRect1.ForeColor = System.Drawing.Color.Black;
			this.verseRect1.Location = new System.Drawing.Point(0, 0);
			this.verseRect1.Name = "verseRect1";
			this.verseRect1.Size = new System.Drawing.Size(398, 102);
			this.verseRect1.TabIndex = 1;
			this.verseRect1.Text = resources.GetString("verseRect1.Text");
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 483);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VerseFlow";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem bibleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importFromToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel1;
		private Controls.VerseRect.VerseRect verseRect4;
		private Controls.VerseRect.VerseRect verseRect2;
		private Controls.VerseRect.VerseRect verseRect3;
		private Controls.VerseRect.VerseRect verseRect1;
		private System.Windows.Forms.TabPage tabPage2;
		private Controls.VerseRect.VerseRect verseRect8;

	}
}

