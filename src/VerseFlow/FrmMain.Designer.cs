using VerseFlow.Controls;

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
			this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.гимныХвалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bibleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verseView1 = new VerseFlow.Controls.VerseView();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleToolStripMenuItem,
            this.songToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// bibleToolStripMenuItem
			// 
			resources.ApplyResources(this.bibleToolStripMenuItem, "bibleToolStripMenuItem");
			this.bibleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem});
			this.bibleToolStripMenuItem.Name = "bibleToolStripMenuItem";
			// 
			// songToolStripMenuItem
			// 
			resources.ApplyResources(this.songToolStripMenuItem, "songToolStripMenuItem");
			this.songToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.гимныХвалыToolStripMenuItem});
			this.songToolStripMenuItem.Name = "songToolStripMenuItem";
			// 
			// toolsToolStripMenuItem
			// 
			resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			// 
			// exportToToolStripMenuItem
			// 
			resources.ApplyResources(this.exportToToolStripMenuItem, "exportToToolStripMenuItem");
			this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
			// 
			// settingsToolStripMenuItem
			// 
			resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			// 
			// splitContainer1
			// 
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
			this.splitContainer1.Panel1.Controls.Add(this.verseView1);
			// 
			// splitContainer1.Panel2
			// 
			resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxPath);
			this.splitContainer1.Panel2.Controls.Add(this.textBox2);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.textBox1);
			this.splitContainer1.Panel2.Controls.Add(this.button2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// textBoxPath
			// 
			resources.ApplyResources(this.textBoxPath, "textBoxPath");
			this.textBoxPath.Name = "textBoxPath";
			// 
			// textBox2
			// 
			resources.ApplyResources(this.textBox2, "textBox2");
			this.textBox2.Name = "textBox2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// textBox1
			// 
			resources.ApplyResources(this.textBox1, "textBox1");
			this.textBox1.Name = "textBox1";
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusStrip1
			// 
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			// 
			// гимныХвалыToolStripMenuItem
			// 
			resources.ApplyResources(this.гимныХвалыToolStripMenuItem, "гимныХвалыToolStripMenuItem");
			this.гимныХвалыToolStripMenuItem.Name = "гимныХвалыToolStripMenuItem";
			// 
			// импортToolStripMenuItem
			// 
			resources.ApplyResources(this.импортToolStripMenuItem, "импортToolStripMenuItem");
			this.импортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleQuoteToolStripMenuItem});
			this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
			// 
			// bibleQuoteToolStripMenuItem
			// 
			resources.ApplyResources(this.bibleQuoteToolStripMenuItem, "bibleQuoteToolStripMenuItem");
			this.bibleQuoteToolStripMenuItem.Name = "bibleQuoteToolStripMenuItem";
			// 
			// verseView1
			// 
			resources.ApplyResources(this.verseView1, "verseView1");
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.LightGray;
			this.verseView1.Name = "verseView1";
			// 
			// FrmMain
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem bibleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private VerseView verseView1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bibleQuoteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem гимныХвалыToolStripMenuItem;

	}
}

