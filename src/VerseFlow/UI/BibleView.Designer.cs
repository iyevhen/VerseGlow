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
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.toolBar.SuspendLayout();
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
			this.toolBar.Size = new System.Drawing.Size(323, 35);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "toolStrip1";
			this.toolBar.Visible = false;
			// 
			// tsFont
			// 
			this.tsFont.Image = global::VerseFlow.Properties.Resources.edit;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(51, 32);
			this.tsFont.Text = "Font";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// tsColors
			// 
			this.tsColors.Image = global::VerseFlow.Properties.Resources.palette;
			this.tsColors.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsColors.Name = "tsColors";
			this.tsColors.Size = new System.Drawing.Size(61, 32);
			this.tsColors.Text = "Colors";
			this.tsColors.Visible = false;
			this.tsColors.Click += new System.EventHandler(this.tsColors_Click);
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbNavigate.FormattingEnabled = true;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 0);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(346, 26);
			this.cmbNavigate.TabIndex = 0;
			this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
			this.cmbNavigate.TextChanged += new System.EventHandler(this.cmbNavigate_TextChanged);
			this.cmbNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNavigate_KeyDown);
			// 
			// verseView
			// 
			this.verseView.AutoScroll = true;
			this.verseView.AutoScrollMinSize = new System.Drawing.Size(340, 0);
			this.verseView.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView.DrawSeparatorLine = false;
			this.verseView.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
			this.verseView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.verseView.HighlightText = null;
			this.verseView.Location = new System.Drawing.Point(0, 26);
			this.verseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(346, 406);
			this.verseView.TabIndex = 1;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.cmbNavigate);
			this.Controls.Add(this.toolBar);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(346, 432);
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsColors;
		private System.Windows.Forms.ComboBox cmbNavigate;
	}
}
