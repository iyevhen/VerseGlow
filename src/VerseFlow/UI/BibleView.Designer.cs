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
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsColors = new System.Windows.Forms.ToolStripButton();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.button1 = new System.Windows.Forms.Button();
			this.toolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cmbNavigate.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.cmbNavigate.IntegralHeight = false;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 3);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(212, 26);
			this.cmbNavigate.TabIndex = 1;
			this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
			this.cmbNavigate.TextChanged += new System.EventHandler(this.cmbNavigate_TextChanged);
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
			this.toolBar.Size = new System.Drawing.Size(277, 25);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "toolStrip1";
			this.toolBar.Visible = false;
			// 
			// tsFont
			// 
			this.tsFont.Image = global::VerseFlow.Properties.Resources.edit;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(51, 22);
			this.tsFont.Text = "Font";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// tsColors
			// 
			this.tsColors.Image = global::VerseFlow.Properties.Resources.palette;
			this.tsColors.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsColors.Name = "tsColors";
			this.tsColors.Size = new System.Drawing.Size(61, 22);
			this.tsColors.Text = "Colors";
			this.tsColors.Visible = false;
			this.tsColors.Click += new System.EventHandler(this.tsColors_Click);
			// 
			// verseView
			// 
			this.verseView.AutoScroll = true;
			this.verseView.AutoScrollMinSize = new System.Drawing.Size(271, 0);
			this.verseView.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.DrawSeparatorLine = false;
			this.verseView.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.verseView.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.verseView.HighlightText = null;
			this.verseView.Location = new System.Drawing.Point(0, 97);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(277, 272);
			this.verseView.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.button1.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.button1.Image = global::VerseFlow.Properties.Resources.clock_history;
			this.button1.Location = new System.Drawing.Point(3, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(27, 26);
			this.button1.TabIndex = 7;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.cmbNavigate);
			this.Controls.Add(this.toolBar);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(280, 372);
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ComboBox cmbNavigate;
		private Controls.VerseView verseView;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsColors;
		private System.Windows.Forms.Button button1;
	}
}
