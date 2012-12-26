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
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.bibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bibleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.гимныХвалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.verseView1 = new VerseFlow.Controls.VerseView();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(542, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "from path:";
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(602, 68);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(255, 20);
			this.textBoxPath.TabIndex = 7;
			this.textBoxPath.Text = "e:\\biblerus.txt";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(900, 37);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(57, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(776, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Verses with max length = ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(713, 35);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(57, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "10000";
			// 
			// button2
			// 
			this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button2.Location = new System.Drawing.Point(461, 66);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Clear";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button1.Location = new System.Drawing.Point(461, 37);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Populate TextView";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// bibleToolStripMenuItem
			// 
			this.bibleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem});
			this.bibleToolStripMenuItem.Name = "bibleToolStripMenuItem";
			this.bibleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.bibleToolStripMenuItem.Text = "Bibles";
			// 
			// импортToolStripMenuItem
			// 
			this.импортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleQuoteToolStripMenuItem});
			this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
			this.импортToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
			// 
			// bibleQuoteToolStripMenuItem
			// 
			this.bibleQuoteToolStripMenuItem.Name = "bibleQuoteToolStripMenuItem";
			this.bibleQuoteToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
			// 
			// songToolStripMenuItem
			// 
			this.songToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.гимныХвалыToolStripMenuItem});
			this.songToolStripMenuItem.Name = "songToolStripMenuItem";
			this.songToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.songToolStripMenuItem.Text = "Psalms";
			// 
			// гимныХвалыToolStripMenuItem
			// 
			this.гимныХвалыToolStripMenuItem.Name = "гимныХвалыToolStripMenuItem";
			this.гимныХвалыToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// exportToToolStripMenuItem
			// 
			this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
			this.exportToToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.exportToToolStripMenuItem.Text = "Export to";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 582);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// splitter1
			// 
			this.splitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.splitter1.Location = new System.Drawing.Point(381, 24);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 558);
			this.splitter1.TabIndex = 9;
			this.splitter1.TabStop = false;
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(380, 1);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.verseView1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.verseView1.Location = new System.Drawing.Point(0, 24);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(381, 558);
			this.verseView1.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 604);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.verseView1);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VerseFlow";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.Button button1;
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
		private System.Windows.Forms.Splitter splitter1;

	}
}

