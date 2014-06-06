namespace VerseFlow.UI.Controls
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibleView));
			this.cmbNavigate = new System.Windows.Forms.ComboBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsBible = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLblInfo = new System.Windows.Forms.ToolStripLabel();
			this.tsClose = new System.Windows.Forms.ToolStripButton();
			this.tsPrevBook = new System.Windows.Forms.ToolStripButton();
			this.tsNextBook = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsPrevChapter = new System.Windows.Forms.ToolStripButton();
			this.tsNextChapter = new System.Windows.Forms.ToolStripButton();
			this.tsAddView = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tblCombos = new System.Windows.Forms.TableLayoutPanel();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.toolStrip1.SuspendLayout();
			this.tblCombos.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbNavigate.FormattingEnabled = true;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 0);
			this.cmbNavigate.Margin = new System.Windows.Forms.Padding(0);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(347, 22);
			this.cmbNavigate.TabIndex = 0;
			this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
			this.cmbNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNavigate_KeyDown);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBible,
            this.tsAddView,
            this.toolStripSeparator1,
            this.tsLblInfo,
            this.tsClose,
            this.tsPrevBook,
            this.tsNextBook,
            this.toolStripSeparator2,
            this.tsPrevChapter,
            this.tsNextChapter,
            this.tsFont});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(347, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsBible
			// 
			this.tsBible.Image = global::VerseFlow.Properties.Resources.book_open;
			this.tsBible.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBible.Name = "tsBible";
			this.tsBible.Size = new System.Drawing.Size(94, 22);
			this.tsBible.Text = "BibleName";
			// 
			// tsFont
			// 
			this.tsFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFont.Image = global::VerseFlow.Properties.Resources.edit;
			this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFont.Name = "tsFont";
			this.tsFont.Size = new System.Drawing.Size(23, 22);
			this.tsFont.Text = "Font";
			this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsLblInfo
			// 
			this.tsLblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.tsLblInfo.Name = "tsLblInfo";
			this.tsLblInfo.Size = new System.Drawing.Size(45, 22);
			this.tsLblInfo.Text = "<info>";
			// 
			// tsClose
			// 
			this.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsClose.Image = global::VerseFlow.Properties.Resources._1402072563_cross;
			this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsClose.Name = "tsClose";
			this.tsClose.Size = new System.Drawing.Size(23, 22);
			this.tsClose.Text = "Close";
			this.tsClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// tsPrevBook
			// 
			this.tsPrevBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPrevBook.Image = global::VerseFlow.Properties.Resources.book_open_previous;
			this.tsPrevBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPrevBook.Name = "tsPrevBook";
			this.tsPrevBook.Size = new System.Drawing.Size(23, 22);
			this.tsPrevBook.Text = "Previous Book";
			// 
			// tsNextBook
			// 
			this.tsNextBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNextBook.Image = global::VerseFlow.Properties.Resources.book_open_next;
			this.tsNextBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNextBook.Name = "tsNextBook";
			this.tsNextBook.Size = new System.Drawing.Size(23, 22);
			this.tsNextBook.Text = "Next Book";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsPrevChapter
			// 
			this.tsPrevChapter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPrevChapter.Image = global::VerseFlow.Properties.Resources._1402049221_arrow_180_medium;
			this.tsPrevChapter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPrevChapter.Name = "tsPrevChapter";
			this.tsPrevChapter.Size = new System.Drawing.Size(23, 22);
			this.tsPrevChapter.Text = "Previous Chapter";
			// 
			// tsNextChapter
			// 
			this.tsNextChapter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNextChapter.Image = global::VerseFlow.Properties.Resources._1402049392_arrow_000_medium;
			this.tsNextChapter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNextChapter.Name = "tsNextChapter";
			this.tsNextChapter.Size = new System.Drawing.Size(23, 22);
			this.tsNextChapter.Text = "Next Chapter";
			// 
			// tsAddView
			// 
			this.tsAddView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsAddView.Image = global::VerseFlow.Properties.Resources._1402078190_plus;
			this.tsAddView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAddView.Name = "tsAddView";
			this.tsAddView.Size = new System.Drawing.Size(23, 22);
			this.tsAddView.Text = "New View";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "1402049221_arrow-180-medium.png");
			this.imageList1.Images.SetKeyName(1, "1402049392_arrow-000-medium.png");
			this.imageList1.Images.SetKeyName(2, "fileclose.png");
			this.imageList1.Images.SetKeyName(3, "book-open-previous.png");
			this.imageList1.Images.SetKeyName(4, "book-open-next.png");
			// 
			// tblCombos
			// 
			this.tblCombos.AutoSize = true;
			this.tblCombos.ColumnCount = 1;
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tblCombos.Controls.Add(this.cmbNavigate, 0, 0);
			this.tblCombos.Dock = System.Windows.Forms.DockStyle.Top;
			this.tblCombos.Location = new System.Drawing.Point(0, 25);
			this.tblCombos.Margin = new System.Windows.Forms.Padding(0);
			this.tblCombos.Name = "tblCombos";
			this.tblCombos.RowCount = 1;
			this.tblCombos.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblCombos.Size = new System.Drawing.Size(347, 22);
			this.tblCombos.TabIndex = 5;
			// 
			// verseView
			// 
			this.verseView.AutoScroll = true;
			this.verseView.AutoScrollMinSize = new System.Drawing.Size(341, 0);
			this.verseView.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.verseView.HighlightText = null;
			this.verseView.Location = new System.Drawing.Point(0, 47);
			this.verseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(347, 373);
			this.verseView.TabIndex = 1;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.tblCombos);
			this.Controls.Add(this.toolStrip1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(347, 420);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tblCombos.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.TableLayoutPanel tblCombos;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tsLblInfo;
		private System.Windows.Forms.ToolStripButton tsClose;
		private System.Windows.Forms.ToolStripDropDownButton tsBible;
		private System.Windows.Forms.ToolStripButton tsPrevBook;
		private System.Windows.Forms.ToolStripButton tsNextBook;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsPrevChapter;
		private System.Windows.Forms.ToolStripButton tsNextChapter;
		private System.Windows.Forms.ToolStripButton tsAddView;
	}
}
