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
			this.pnlSource = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.tsLive = new System.Windows.Forms.ToolStripButton();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.toolStrip1.SuspendLayout();
			this.pnlSource.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 567);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(841, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
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
			// pnlSource
			// 
			this.pnlSource.Controls.Add(this.verseView1);
			this.pnlSource.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSource.Location = new System.Drawing.Point(0, 52);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(300, 515);
			this.pnlSource.TabIndex = 19;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(300, 52);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 515);
			this.splitter1.TabIndex = 20;
			this.splitter1.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(303, 52);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip3);
			this.splitContainer1.Panel1.Controls.Add(this.button4);
			this.splitContainer1.Panel1.Controls.Add(this.button3);
			this.splitContainer1.Panel1.Controls.Add(this.buttonHightlihght);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxHighlight);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip4);
			this.splitContainer1.Size = new System.Drawing.Size(538, 515);
			this.splitContainer1.SplitterDistance = 285;
			this.splitContainer1.TabIndex = 21;
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip3.Size = new System.Drawing.Size(285, 25);
			this.toolStrip3.TabIndex = 15;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton5.Image = global::VerseFlow.Properties.Resources._1358435985_arrow_right;
			this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(62, 22);
			this.toolStripButton5.Text = "Go Live";
			// 
			// toolStrip4
			// 
			this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLive});
			this.toolStrip4.Location = new System.Drawing.Point(0, 0);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip4.Size = new System.Drawing.Size(249, 25);
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
			this.tsLive.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.tsLive.Size = new System.Drawing.Size(56, 22);
			this.tsLive.Text = "Live";
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(213, 0);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.Font = new System.Drawing.Font("Ezra SIL SR", 14.25F);
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 0);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(300, 515);
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
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.pnlSource.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private VerseView verseView1;
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
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Panel pnlSource;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStrip toolStrip4;
		private System.Windows.Forms.ToolStripButton tsLive;
		private System.Windows.Forms.ToolStripButton toolStripButton5;

	}
}

