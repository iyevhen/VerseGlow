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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.bibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibleToolStripMenuItem,
            this.songToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(781, 24);
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
			this.splitContainer1.Panel1.Controls.Add(this.verseView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxPath);
			this.splitContainer1.Panel2.Controls.Add(this.textBox2);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.textBox1);
			this.splitContainer1.Panel2.Controls.Add(this.button2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
			this.splitContainer1.Size = new System.Drawing.Size(781, 411);
			this.splitContainer1.SplitterDistance = 312;
			this.splitContainer1.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(110, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "from path:";
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(170, 113);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(255, 20);
			this.textBoxPath.TabIndex = 7;
			this.textBoxPath.Text = "e:\\Biblerus.txt";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(300, 79);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(57, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "300";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(34, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Painted in :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(176, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Verses with max length = ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(113, 77);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(57, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "10000";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(32, 187);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Clear";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(110, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "<time>";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 77);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Populate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 435);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(781, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(311, 1);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.LightGray;
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.verseView1.Location = new System.Drawing.Point(0, 0);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(312, 411);
			this.verseView1.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(781, 457);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VerseFlow";
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
		private System.Windows.Forms.ToolStripMenuItem importFromToolStripMenuItem;
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

	}
}

