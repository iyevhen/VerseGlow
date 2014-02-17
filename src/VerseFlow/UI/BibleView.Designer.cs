namespace VerseFlow.UI
{
	partial class BibleView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsColors = new System.Windows.Forms.ToolStripButton();
			this.cmbNavigate = new System.Windows.Forms.ComboBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonGoLive = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPreview = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButtonTie = new System.Windows.Forms.ToolStripSplitButton();
			this.lblBibleName = new System.Windows.Forms.Label();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.toolBar.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFont,
            this.tsColors});
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolBar.ShowItemToolTips = false;
			this.toolBar.Size = new System.Drawing.Size(422, 29);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "toolStrip1";
			this.toolBar.Visible = false;
			// 
			// tsFont
			// 
			this.tsFont.Image = global::VerseFlow.Properties.Resources.edit;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(51, 26);
			this.tsFont.Text = "Font";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// tsColors
			// 
			this.tsColors.Image = global::VerseFlow.Properties.Resources.palette;
			this.tsColors.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsColors.Name = "tsColors";
			this.tsColors.Size = new System.Drawing.Size(61, 26);
			this.tsColors.Text = "Colors";
			this.tsColors.Visible = false;
			this.tsColors.Click += new System.EventHandler(this.tsColors_Click);
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbNavigate.FormattingEnabled = true;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 42);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(326, 22);
			this.cmbNavigate.TabIndex = 0;
			this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
			this.cmbNavigate.TextChanged += new System.EventHandler(this.cmbNavigate_TextChanged);
			this.cmbNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNavigate_KeyDown);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose,
            this.toolStripButtonGoLive,
            this.toolStripButtonPreview,
            this.toolStripSplitButtonTie});
			this.toolStrip1.Location = new System.Drawing.Point(0, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(326, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonClose
			// 
			this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonClose.Image = global::VerseFlow.Properties.Resources.fileclose;
			this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClose.Name = "toolStripButtonClose";
			this.toolStripButtonClose.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonClose.Text = "Close";
			this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
			// 
			// toolStripButtonGoLive
			// 
			this.toolStripButtonGoLive.Image = global::VerseFlow.Properties.Resources.surveillance_camera;
			this.toolStripButtonGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonGoLive.Name = "toolStripButtonGoLive";
			this.toolStripButtonGoLive.Size = new System.Drawing.Size(66, 22);
			this.toolStripButtonGoLive.Text = "Go Live";
			// 
			// toolStripButtonPreview
			// 
			this.toolStripButtonPreview.Image = global::VerseFlow.Properties.Resources.monitor_wallpaper;
			this.toolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPreview.Name = "toolStripButtonPreview";
			this.toolStripButtonPreview.Size = new System.Drawing.Size(68, 22);
			this.toolStripButtonPreview.Text = "Preview";
			// 
			// toolStripSplitButtonTie
			// 
			this.toolStripSplitButtonTie.Image = global::VerseFlow.Properties.Resources.chain;
			this.toolStripSplitButtonTie.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButtonTie.Name = "toolStripSplitButtonTie";
			this.toolStripSplitButtonTie.Size = new System.Drawing.Size(55, 22);
			this.toolStripSplitButtonTie.Text = "Tie";
			// 
			// lblBibleName
			// 
			this.lblBibleName.AutoSize = true;
			this.lblBibleName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblBibleName.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblBibleName.ForeColor = System.Drawing.Color.Gray;
			this.lblBibleName.Location = new System.Drawing.Point(0, 0);
			this.lblBibleName.Name = "lblBibleName";
			this.lblBibleName.Padding = new System.Windows.Forms.Padding(1);
			this.lblBibleName.Size = new System.Drawing.Size(68, 17);
			this.lblBibleName.TabIndex = 3;
			this.lblBibleName.Text = "Bible name";
			// 
			// verseView
			// 
			this.verseView.AutoScroll = true;
			this.verseView.AutoScrollMinSize = new System.Drawing.Size(320, 0);
			this.verseView.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.verseView.HighlightText = null;
			this.verseView.Location = new System.Drawing.Point(0, 64);
			this.verseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(326, 298);
			this.verseView.TabIndex = 1;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.cmbNavigate);
			this.Controls.Add(this.toolBar);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.lblBibleName);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(326, 362);
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsColors;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonClose;
		private System.Windows.Forms.ToolStripButton toolStripButtonGoLive;
		private System.Windows.Forms.ToolStripButton toolStripButtonPreview;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonTie;
		private System.Windows.Forms.Label lblBibleName;
	}
}
