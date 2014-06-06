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
			this.cmbNavigate = new System.Windows.Forms.ComboBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonGoLive = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPreview = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButtonTie = new System.Windows.Forms.ToolStripSplitButton();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.panelTitle = new System.Windows.Forms.Panel();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.toolStrip1.SuspendLayout();
			this.panelTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbNavigate.FormattingEnabled = true;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 42);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(225, 22);
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
            this.toolStripButtonGoLive,
            this.toolStripButtonPreview,
            this.toolStripSplitButtonTie});
			this.toolStrip1.Location = new System.Drawing.Point(0, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(225, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
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
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.Location = new System.Drawing.Point(2, 2);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(65, 13);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Text = "Bible name";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.Click += new System.EventHandler(this.lblBibleName_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Font = new System.Drawing.Font("Verdana", 4F);
			this.btnClose.Image = global::VerseFlow.Properties.Resources.fileclose;
			this.btnClose.Location = new System.Drawing.Point(206, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(14, 13);
			this.btnClose.TabIndex = 4;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panelTitle
			// 
			this.panelTitle.AutoSize = true;
			this.panelTitle.BackColor = System.Drawing.Color.SteelBlue;
			this.panelTitle.Controls.Add(this.btnClose);
			this.panelTitle.Controls.Add(this.lblTitle);
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Location = new System.Drawing.Point(0, 0);
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Padding = new System.Windows.Forms.Padding(2);
			this.panelTitle.Size = new System.Drawing.Size(225, 17);
			this.panelTitle.TabIndex = 4;
			// 
			// verseView
			// 
			this.verseView.AutoScroll = true;
			this.verseView.AutoScrollMinSize = new System.Drawing.Size(219, 10);
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
			this.verseView.Size = new System.Drawing.Size(225, 302);
			this.verseView.TabIndex = 1;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.cmbNavigate);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panelTitle);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(225, 366);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panelTitle.ResumeLayout(false);
			this.panelTitle.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonGoLive;
		private System.Windows.Forms.ToolStripButton toolStripButtonPreview;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonTie;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panelTitle;
	}
}
