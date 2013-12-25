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
			this.cmbBooks = new System.Windows.Forms.ComboBox();
			this.pnlReadTop = new System.Windows.Forms.Panel();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.cmbChapters = new System.Windows.Forms.ComboBox();
			this.tools = new System.Windows.Forms.ToolStrip();
			this.tsRead = new System.Windows.Forms.ToolStripButton();
			this.tsFind = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.pnlRead = new System.Windows.Forms.Panel();
			this.pnlFind = new System.Windows.Forms.Panel();
			this.pnlFindTop = new System.Windows.Forms.Panel();
			this.cmbFind = new System.Windows.Forms.ComboBox();
			this.btnFind = new System.Windows.Forms.Button();
			this.verseViewRead = new VerseFlow.UI.Controls.VerseView();
			this.verseViewFind = new VerseFlow.UI.Controls.VerseView();
			this.pnlReadTop.SuspendLayout();
			this.tools.SuspendLayout();
			this.pnlRead.SuspendLayout();
			this.pnlFind.SuspendLayout();
			this.pnlFindTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbBooks
			// 
			this.cmbBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBooks.FormattingEnabled = true;
			this.cmbBooks.Location = new System.Drawing.Point(2, 2);
			this.cmbBooks.Name = "cmbBooks";
			this.cmbBooks.Size = new System.Drawing.Size(167, 21);
			this.cmbBooks.TabIndex = 7;
			this.cmbBooks.SelectedIndexChanged += new System.EventHandler(this.cmbBooks_SelectedIndexChanged);
			// 
			// pnlReadTop
			// 
			this.pnlReadTop.Controls.Add(this.btnNext);
			this.pnlReadTop.Controls.Add(this.btnPrevious);
			this.pnlReadTop.Controls.Add(this.cmbBooks);
			this.pnlReadTop.Controls.Add(this.cmbChapters);
			this.pnlReadTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlReadTop.Location = new System.Drawing.Point(0, 0);
			this.pnlReadTop.Name = "pnlReadTop";
			this.pnlReadTop.Size = new System.Drawing.Size(265, 26);
			this.pnlReadTop.TabIndex = 11;
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(241, 1);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(23, 23);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = ">";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrevious.Location = new System.Drawing.Point(218, 1);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(23, 23);
			this.btnPrevious.TabIndex = 0;
			this.btnPrevious.Text = "<";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// cmbChapters
			// 
			this.cmbChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChapters.FormattingEnabled = true;
			this.cmbChapters.Location = new System.Drawing.Point(172, 2);
			this.cmbChapters.Name = "cmbChapters";
			this.cmbChapters.Size = new System.Drawing.Size(41, 21);
			this.cmbChapters.TabIndex = 7;
			this.cmbChapters.SelectedIndexChanged += new System.EventHandler(this.cmbChapters_SelectedIndexChanged);
			// 
			// tools
			// 
			this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRead,
            this.tsFind,
            this.toolStripSeparator1,
            this.tsFont});
			this.tools.Location = new System.Drawing.Point(0, 0);
			this.tools.Name = "tools";
			this.tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tools.ShowItemToolTips = false;
			this.tools.Size = new System.Drawing.Size(265, 25);
			this.tools.TabIndex = 12;
			this.tools.Text = "toolStrip1";
			// 
			// tsRead
			// 
			this.tsRead.Checked = true;
			this.tsRead.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsRead.Image = global::VerseFlow.Properties.Resources.book_open;
			this.tsRead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsRead.Name = "tsRead";
			this.tsRead.Size = new System.Drawing.Size(53, 22);
			this.tsRead.Text = "Read";
			this.tsRead.CheckedChanged += new System.EventHandler(this.tsRead_CheckedChanged);
			this.tsRead.Click += new System.EventHandler(this.tsRead_Click);
			// 
			// tsFind
			// 
			this.tsFind.CheckOnClick = true;
			this.tsFind.Image = global::VerseFlow.Properties.Resources.binocular;
			this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFind.Name = "tsFind";
			this.tsFind.Size = new System.Drawing.Size(50, 22);
			this.tsFind.Text = "Find";
			this.tsFind.Click += new System.EventHandler(this.tsFind_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			// pnlRead
			// 
			this.pnlRead.Controls.Add(this.verseViewRead);
			this.pnlRead.Controls.Add(this.pnlReadTop);
			this.pnlRead.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRead.Location = new System.Drawing.Point(0, 25);
			this.pnlRead.Name = "pnlRead";
			this.pnlRead.Size = new System.Drawing.Size(265, 271);
			this.pnlRead.TabIndex = 13;
			// 
			// pnlFind
			// 
			this.pnlFind.Controls.Add(this.verseViewFind);
			this.pnlFind.Controls.Add(this.pnlFindTop);
			this.pnlFind.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFind.Location = new System.Drawing.Point(0, 25);
			this.pnlFind.Name = "pnlFind";
			this.pnlFind.Size = new System.Drawing.Size(265, 271);
			this.pnlFind.TabIndex = 14;
			this.pnlFind.Visible = false;
			// 
			// pnlFindTop
			// 
			this.pnlFindTop.Controls.Add(this.cmbFind);
			this.pnlFindTop.Controls.Add(this.btnFind);
			this.pnlFindTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFindTop.Location = new System.Drawing.Point(0, 0);
			this.pnlFindTop.Name = "pnlFindTop";
			this.pnlFindTop.Size = new System.Drawing.Size(265, 26);
			this.pnlFindTop.TabIndex = 13;
			// 
			// cmbFind
			// 
			this.cmbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbFind.FormattingEnabled = true;
			this.cmbFind.Items.AddRange(new object[] {
            "aaaa",
            "bbbb",
            "cccc"});
			this.cmbFind.Location = new System.Drawing.Point(2, 2);
			this.cmbFind.Name = "cmbFind";
			this.cmbFind.Size = new System.Drawing.Size(207, 21);
			this.cmbFind.TabIndex = 0;
			this.cmbFind.TextChanged += new System.EventHandler(this.cmbFind_TextChanged);
			// 
			// btnFind
			// 
			this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFind.Enabled = false;
			this.btnFind.Location = new System.Drawing.Point(211, 1);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(53, 23);
			this.btnFind.TabIndex = 1;
			this.btnFind.Text = "Find";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// verseViewRead
			// 
			this.verseViewRead.AutoScroll = true;
			this.verseViewRead.AutoScrollMinSize = new System.Drawing.Size(259, 0);
			this.verseViewRead.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseViewRead.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseViewRead.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseViewRead.DrawSeparatorLine = true;
			this.verseViewRead.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.verseViewRead.HighlightText = null;
			this.verseViewRead.Location = new System.Drawing.Point(0, 26);
			this.verseViewRead.Name = "verseViewRead";
			this.verseViewRead.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseViewRead.Size = new System.Drawing.Size(265, 245);
			this.verseViewRead.TabIndex = 10;
			// 
			// verseViewFind
			// 
			this.verseViewFind.AutoScroll = true;
			this.verseViewFind.AutoScrollMinSize = new System.Drawing.Size(259, 0);
			this.verseViewFind.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseViewFind.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseViewFind.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseViewFind.DrawSeparatorLine = true;
			this.verseViewFind.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.verseViewFind.HighlightText = null;
			this.verseViewFind.Location = new System.Drawing.Point(0, 26);
			this.verseViewFind.Name = "verseViewFind";
			this.verseViewFind.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseViewFind.Size = new System.Drawing.Size(265, 245);
			this.verseViewFind.TabIndex = 12;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.pnlRead);
			this.Controls.Add(this.pnlFind);
			this.Controls.Add(this.tools);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(265, 296);
			this.pnlReadTop.ResumeLayout(false);
			this.tools.ResumeLayout(false);
			this.tools.PerformLayout();
			this.pnlRead.ResumeLayout(false);
			this.pnlFind.ResumeLayout(false);
			this.pnlFindTop.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ComboBox cmbBooks;
        private Controls.VerseView verseViewRead;
        private System.Windows.Forms.Panel pnlReadTop;
        private System.Windows.Forms.ComboBox cmbChapters;
		private System.Windows.Forms.ToolStrip tools;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsFind;
		private System.Windows.Forms.ToolStripButton tsRead;
		private System.Windows.Forms.Panel pnlRead;
		private System.Windows.Forms.Panel pnlFind;
		private Controls.VerseView verseViewFind;
		private System.Windows.Forms.Panel pnlFindTop;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.ComboBox cmbFind;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
	}
}
