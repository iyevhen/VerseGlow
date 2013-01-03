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
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statBugLnk = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBoxHighlight = new System.Windows.Forms.TextBox();
			this.buttonHightlihght = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsPsalms = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsText = new System.Windows.Forms.ToolStripSplitButton();
			this.tsSplit = new System.Windows.Forms.ToolStripSeparator();
			this.tsSettings = new System.Windows.Forms.ToolStripButton();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBoxSQL = new System.Windows.Forms.TextBox();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(501, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "from path:";
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(561, 128);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(138, 20);
			this.textBoxPath.TabIndex = 7;
			this.textBoxPath.Text = "e:\\biblerus.txt";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(728, 99);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(57, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(604, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Verses with max length = ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(541, 97);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(57, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "10000";
			// 
			// button2
			// 
			this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button2.Location = new System.Drawing.Point(420, 126);
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
			this.button1.Location = new System.Drawing.Point(420, 97);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Populate TextView";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statBugLnk});
			this.statusStrip1.Location = new System.Drawing.Point(0, 445);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(812, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statBugLnk
			// 
			this.statBugLnk.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
			this.statBugLnk.IsLink = true;
			this.statBugLnk.LinkColor = System.Drawing.Color.DimGray;
			this.statBugLnk.Name = "statBugLnk";
			this.statBugLnk.Size = new System.Drawing.Size(84, 17);
			this.statBugLnk.Text = "I found a bug...";
			// 
			// textBoxHighlight
			// 
			this.textBoxHighlight.Location = new System.Drawing.Point(504, 181);
			this.textBoxHighlight.Name = "textBoxHighlight";
			this.textBoxHighlight.Size = new System.Drawing.Size(141, 20);
			this.textBoxHighlight.TabIndex = 10;
			// 
			// buttonHightlihght
			// 
			this.buttonHightlihght.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHightlihght.Location = new System.Drawing.Point(420, 181);
			this.buttonHightlihght.Name = "buttonHightlihght";
			this.buttonHightlihght.Size = new System.Drawing.Size(75, 23);
			this.buttonHightlihght.TabIndex = 11;
			this.buttonHightlihght.Text = "Highlight";
			this.buttonHightlihght.UseVisualStyleBackColor = true;
			this.buttonHightlihght.Click += new System.EventHandler(this.buttonHightlihght_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsPsalms,
            this.tsText,
            this.tsSplit,
            this.tsSettings,
            this.tsAbout});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(812, 52);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsBibles
			// 
			this.tsBibles.AutoToolTip = false;
			this.tsBibles.Image = ((System.Drawing.Image)(resources.GetObject("tsBibles.Image")));
			this.tsBibles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBibles.Name = "tsBibles";
			this.tsBibles.Size = new System.Drawing.Size(47, 49);
			this.tsBibles.Text = "Bibles";
			this.tsBibles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsBibles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsBibles.DropDownOpening += new System.EventHandler(this.tsBibles_DropDownOpening);
			// 
			// tsPsalms
			// 
			this.tsPsalms.AutoToolTip = false;
			this.tsPsalms.Image = ((System.Drawing.Image)(resources.GetObject("tsPsalms.Image")));
			this.tsPsalms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsPsalms.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPsalms.Name = "tsPsalms";
			this.tsPsalms.Size = new System.Drawing.Size(52, 49);
			this.tsPsalms.Text = "Psalms";
			this.tsPsalms.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsPsalms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// tsText
			// 
			this.tsText.AutoToolTip = false;
			this.tsText.Image = ((System.Drawing.Image)(resources.GetObject("tsText.Image")));
			this.tsText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsText.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsText.Name = "tsText";
			this.tsText.Size = new System.Drawing.Size(48, 49);
			this.tsText.Text = "Text";
			this.tsText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// tsSplit
			// 
			this.tsSplit.Name = "tsSplit";
			this.tsSplit.Size = new System.Drawing.Size(6, 52);
			// 
			// tsSettings
			// 
			this.tsSettings.AutoToolTip = false;
			this.tsSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsSettings.Image")));
			this.tsSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSettings.Name = "tsSettings";
			this.tsSettings.Size = new System.Drawing.Size(50, 49);
			this.tsSettings.Text = "Settings";
			this.tsSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsSettings.Click += new System.EventHandler(this.tsSettings_Click);
			// 
			// tsAbout
			// 
			this.tsAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsAbout.AutoToolTip = false;
			this.tsAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsAbout.Image")));
			this.tsAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Size = new System.Drawing.Size(40, 49);
			this.tsAbout.Text = "About";
			this.tsAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// button3
			// 
			this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button3.Location = new System.Drawing.Point(420, 227);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "Show";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button4.Location = new System.Drawing.Point(504, 227);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "Hide";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button5.Location = new System.Drawing.Point(420, 279);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 15;
			this.button5.Text = "Select";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBoxSQL
			// 
			this.textBoxSQL.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxSQL.Location = new System.Drawing.Point(504, 282);
			this.textBoxSQL.Multiline = true;
			this.textBoxSQL.Name = "textBoxSQL";
			this.textBoxSQL.Size = new System.Drawing.Size(281, 84);
			this.textBoxSQL.TabIndex = 16;
			this.textBoxSQL.Text = "SELECT versetext FROM BibleContent WHERE versetext LIKE \'%ибо%\'\r\n";
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(390, 0);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.verseView1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 52);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(391, 393);
			this.verseView1.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 467);
			this.Controls.Add(this.textBoxSQL);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.verseView1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.buttonHightlihght);
			this.Controls.Add(this.textBoxHighlight);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private VerseView verseView1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxHighlight;
		private System.Windows.Forms.Button buttonHightlihght;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripDropDownButton tsPsalms;
		private System.Windows.Forms.ToolStripButton tsSettings;
		private System.Windows.Forms.ToolStripSplitButton tsText;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.ToolStripSeparator tsSplit;
		private System.Windows.Forms.ToolStripStatusLabel statBugLnk;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBoxSQL;

	}
}

