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
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
			this.pnlSource = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.tsLive = new System.Windows.Forms.ToolStripButton();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.pnlSource.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(324, 75);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(57, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(200, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "blocks with max length = ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(137, 73);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(57, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "10000";
			// 
			// button2
			// 
			this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button2.Location = new System.Drawing.Point(16, 102);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(141, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Other Languages";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button1.Location = new System.Drawing.Point(16, 73);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Populate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statBugLnk});
			this.statusStrip1.Location = new System.Drawing.Point(0, 567);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(841, 22);
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
			this.textBoxHighlight.Location = new System.Drawing.Point(100, 157);
			this.textBoxHighlight.Name = "textBoxHighlight";
			this.textBoxHighlight.Size = new System.Drawing.Size(141, 20);
			this.textBoxHighlight.TabIndex = 10;
			// 
			// buttonHightlihght
			// 
			this.buttonHightlihght.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHightlihght.Location = new System.Drawing.Point(16, 157);
			this.buttonHightlihght.Name = "buttonHightlihght";
			this.buttonHightlihght.Size = new System.Drawing.Size(75, 23);
			this.buttonHightlihght.TabIndex = 11;
			this.buttonHightlihght.Text = "Highlight";
			this.buttonHightlihght.UseVisualStyleBackColor = true;
			this.buttonHightlihght.Click += new System.EventHandler(this.buttonHightlihght_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
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
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(841, 52);
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
			this.button3.Location = new System.Drawing.Point(16, 203);
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
			this.button4.Location = new System.Drawing.Point(100, 203);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "Hide";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripSplitButton2});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip2.Size = new System.Drawing.Size(379, 25);
			this.toolStrip2.TabIndex = 18;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = global::VerseFlow.Properties.Resources._1357332601_find;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(47, 22);
			this.toolStripButton2.Text = "Find";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::VerseFlow.Properties.Resources._1357332047_text_list_bullets;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(71, 22);
			this.toolStripButton1.Text = "Contents";
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton1.Image = global::VerseFlow.Properties.Resources._1357332164_resultset_previous;
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
			this.toolStripSplitButton1.Text = "toolStripSplitButton1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(127, 22);
			this.toolStripDropDownButton1.Text = "CURRENT BOOK HERE";
			// 
			// toolStripSplitButton2
			// 
			this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton2.Image = global::VerseFlow.Properties.Resources._1357332308_resultset_next;
			this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton2.Name = "toolStripSplitButton2";
			this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
			this.toolStripSplitButton2.Text = "toolStripSplitButton2";
			// 
			// pnlSource
			// 
			this.pnlSource.Controls.Add(this.verseView1);
			this.pnlSource.Controls.Add(this.toolStrip2);
			this.pnlSource.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSource.Location = new System.Drawing.Point(0, 52);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(379, 515);
			this.pnlSource.TabIndex = 19;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(379, 52);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 515);
			this.splitter1.TabIndex = 20;
			this.splitter1.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(382, 52);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip3);
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.button2);
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			this.splitContainer1.Panel1.Controls.Add(this.button4);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.button3);
			this.splitContainer1.Panel1.Controls.Add(this.textBox2);
			this.splitContainer1.Panel1.Controls.Add(this.buttonHightlihght);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxHighlight);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip4);
			this.splitContainer1.Size = new System.Drawing.Size(459, 515);
			this.splitContainer1.SplitterDistance = 327;
			this.splitContainer1.TabIndex = 21;
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip3.Size = new System.Drawing.Size(327, 25);
			this.toolStrip3.TabIndex = 15;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStrip4
			// 
			this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLive});
			this.toolStrip4.Location = new System.Drawing.Point(0, 0);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip4.Size = new System.Drawing.Size(128, 25);
			this.toolStrip4.TabIndex = 16;
			this.toolStrip4.Text = "toolStrip4";
			// 
			// tsLive
			// 
			this.tsLive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsLive.CheckOnClick = true;
			this.tsLive.Image = global::VerseFlow.Properties.Resources._1357332757_cctv_camera;
			this.tsLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsLive.Name = "tsLive";
			this.tsLive.Size = new System.Drawing.Size(48, 22);
			this.tsLive.Text = "LIVE";
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(347, 0);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.Font = new System.Drawing.Font("Segoe UI", 13F);
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 25);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(379, 490);
			this.verseView1.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(841, 589);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlSource);
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
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.pnlSource.ResumeLayout(false);
			this.pnlSource.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
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
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.Panel pnlSource;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStrip toolStrip4;
		private System.Windows.Forms.ToolStripButton tsLive;

	}
}

