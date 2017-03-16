using VerseGlow.UI.Controls.dotnetrix.co.uk;

namespace VerseGlow.UI.Controls
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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsBook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLblChapter = new System.Windows.Forms.ToolStripLabel();
            this.tsPrevChapter = new System.Windows.Forms.ToolStripButton();
            this.tsNextChapter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrevBook = new System.Windows.Forms.ToolStripButton();
            this.tsNextBook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.tsFont = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tblCombos = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.verseView = new VerseView();
            this.toolStripMain.SuspendLayout();
            this.tblCombos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNavigate
            // 
            this.cmbNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNavigate.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseGlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbNavigate.Font = global::VerseGlow.Properties.Settings.Default.BibleFont;
            this.cmbNavigate.FormattingEnabled = true;
            this.cmbNavigate.Location = new System.Drawing.Point(0, 0);
            this.cmbNavigate.Margin = new System.Windows.Forms.Padding(0);
            this.cmbNavigate.Name = "cmbNavigate";
            this.cmbNavigate.Size = new System.Drawing.Size(260, 24);
            this.cmbNavigate.TabIndex = 0;
            this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
            this.cmbNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNavigate_KeyDown);
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripMargin = new System.Windows.Forms.Padding(1);
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBook,
            this.toolStripSeparator1,
            this.tsLblChapter,
            this.tsPrevChapter,
            this.tsNextChapter,
            this.toolStripSeparator2,
            this.tsPrevBook,
            this.tsNextBook,
            this.toolStripSeparator3,
            this.tsFind,
            this.tsFont});
            this.toolStripMain.Location = new System.Drawing.Point(0, 17);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(260, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tsBook
            // 
            this.tsBook.CheckOnClick = true;
            this.tsBook.Image = global::VerseGlow.Properties.Resources.book_open;
            this.tsBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBook.Name = "tsBook";
            this.tsBook.Size = new System.Drawing.Size(70, 22);
            this.tsBook.Text = "<Book>";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLblChapter
            // 
            this.tsLblChapter.Name = "tsLblChapter";
            this.tsLblChapter.Size = new System.Drawing.Size(14, 22);
            this.tsLblChapter.Text = "#";
            // 
            // tsPrevChapter
            // 
            this.tsPrevChapter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrevChapter.Image = global::VerseGlow.Properties.Resources._1402049221_arrow_180_medium;
            this.tsPrevChapter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrevChapter.Name = "tsPrevChapter";
            this.tsPrevChapter.Size = new System.Drawing.Size(23, 22);
            this.tsPrevChapter.Text = "Previous Chapter";
            // 
            // tsNextChapter
            // 
            this.tsNextChapter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNextChapter.Image = global::VerseGlow.Properties.Resources._1402049392_arrow_000_medium;
            this.tsNextChapter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNextChapter.Name = "tsNextChapter";
            this.tsNextChapter.Size = new System.Drawing.Size(23, 22);
            this.tsNextChapter.Text = "Next Chapter";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPrevBook
            // 
            this.tsPrevBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrevBook.Image = global::VerseGlow.Properties.Resources.book_open_previous;
            this.tsPrevBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrevBook.Name = "tsPrevBook";
            this.tsPrevBook.Size = new System.Drawing.Size(23, 22);
            this.tsPrevBook.Text = "Previous Book";
            // 
            // tsNextBook
            // 
            this.tsNextBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNextBook.Image = global::VerseGlow.Properties.Resources.book_open_next;
            this.tsNextBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNextBook.Name = "tsNextBook";
            this.tsNextBook.Size = new System.Drawing.Size(23, 22);
            this.tsNextBook.Text = "Next Book";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsFind
            // 
            this.tsFind.Checked = true;
            this.tsFind.CheckOnClick = true;
            this.tsFind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFind.Image = global::VerseGlow.Properties.Resources.binocular;
            this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(23, 22);
            this.tsFind.Text = "toolStripButton1";
            this.tsFind.Click += new System.EventHandler(this.tsFind_Click);
            // 
            // tsFont
            // 
            this.tsFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFont.Image = global::VerseGlow.Properties.Resources.edit;
            this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFont.Name = "tsFont";
            this.tsFont.Size = new System.Drawing.Size(23, 22);
            this.tsFont.Text = "Font";
            this.tsFont.Click += new System.EventHandler(this.tsFont_Click);
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
            this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblCombos.Controls.Add(this.cmbNavigate, 0, 0);
            this.tblCombos.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblCombos.Location = new System.Drawing.Point(0, 42);
            this.tblCombos.Margin = new System.Windows.Forms.Padding(0);
            this.tblCombos.Name = "tblCombos";
            this.tblCombos.RowCount = 1;
            this.tblCombos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCombos.Size = new System.Drawing.Size(260, 24);
            this.tblCombos.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(260, 17);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ImageIndex = 2;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(248, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(10, 13);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(23, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "title";
            // 
            // verseView
            // 
            this.verseView.AutoScroll = true;
            this.verseView.AutoScrollMinSize = new System.Drawing.Size(256, 10);
            this.verseView.AutoScrollOffset = new System.Drawing.Point(500, 500);
            this.verseView.BackColor = global::VerseGlow.Properties.Settings.Default.BibleBackColor;
            this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseGlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.verseView.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseGlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.verseView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verseView.Font = global::VerseGlow.Properties.Settings.Default.BibleFont;
            this.verseView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.verseView.HighlightText = null;
            this.verseView.Location = new System.Drawing.Point(0, 66);
            this.verseView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.verseView.Name = "verseView";
            this.verseView.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.verseView.ReadOnly = false;
            this.verseView.Size = new System.Drawing.Size(260, 324);
            this.verseView.TabIndex = 1;
            // 
            // BibleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.verseView);
            this.Controls.Add(this.tblCombos);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseGlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = global::VerseGlow.Properties.Settings.Default.BibleForeColor;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BibleView";
            this.Size = new System.Drawing.Size(260, 390);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tblCombos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.TableLayoutPanel tblCombos;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tsLblChapter;
		private System.Windows.Forms.ToolStripButton tsPrevBook;
		private System.Windows.Forms.ToolStripButton tsNextBook;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsPrevChapter;
		private System.Windows.Forms.ToolStripButton tsNextChapter;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTitle;
		private dotnetrix.co.uk.Button btnClose;
		private System.Windows.Forms.ToolStripButton tsBook;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsFind;
	}
}
