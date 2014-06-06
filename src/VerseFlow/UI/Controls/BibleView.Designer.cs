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
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsColors = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsLblInfo = new System.Windows.Forms.ToolStripLabel();
			this.tsPrev = new System.Windows.Forms.ToolStripButton();
			this.tsNext = new System.Windows.Forms.ToolStripButton();
			this.lblTitle = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panelTitle = new System.Windows.Forms.Panel();
			this.btnClose = new VerseFlow.UI.Controls.dotnetrix.co.uk.Button();
			this.tblCombos = new System.Windows.Forms.TableLayoutPanel();
			this.cmbChapter = new System.Windows.Forms.ComboBox();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.toolStrip1.SuspendLayout();
			this.panelTitle.SuspendLayout();
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
			this.cmbNavigate.Size = new System.Drawing.Size(293, 22);
			this.cmbNavigate.TabIndex = 0;
			this.cmbNavigate.SelectedIndexChanged += new System.EventHandler(this.cmbNavigate_SelectedIndexChanged);
			this.cmbNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNavigate_KeyDown);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFont,
            this.tsColors,
            this.toolStripSeparator1,
            this.tsLblInfo,
            this.tsPrev,
            this.tsNext});
			this.toolStrip1.Location = new System.Drawing.Point(0, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(347, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
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
			this.tsColors.Click += new System.EventHandler(this.tsColors_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsLblInfo
			// 
			this.tsLblInfo.Name = "tsLblInfo";
			this.tsLblInfo.Size = new System.Drawing.Size(44, 22);
			this.tsLblInfo.Text = "<info>";
			// 
			// tsPrev
			// 
			this.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPrev.Image = global::VerseFlow.Properties.Resources._1402049221_arrow_180_medium;
			this.tsPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPrev.Name = "tsPrev";
			this.tsPrev.Size = new System.Drawing.Size(23, 22);
			this.tsPrev.Text = "Prev";
			// 
			// tsNext
			// 
			this.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNext.Image = global::VerseFlow.Properties.Resources._1402049392_arrow_000_medium;
			this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNext.Name = "tsNext";
			this.tsNext.Size = new System.Drawing.Size(23, 22);
			this.tsNext.Text = "Next";
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
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "1402049221_arrow-180-medium.png");
			this.imageList1.Images.SetKeyName(1, "1402049392_arrow-000-medium.png");
			this.imageList1.Images.SetKeyName(2, "fileclose.png");
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
			this.panelTitle.Size = new System.Drawing.Size(347, 17);
			this.panelTitle.TabIndex = 4;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.BackColor = System.Drawing.SystemColors.Control;
			this.btnClose.CornerRadius = 4;
			this.btnClose.ImageIndex = 2;
			this.btnClose.ImageList = this.imageList1;
			this.btnClose.Location = new System.Drawing.Point(328, 2);
			this.btnClose.Margin = new System.Windows.Forms.Padding(1);
			this.btnClose.Name = "btnClose";
			this.btnClose.RoundCorners = ((VerseFlow.UI.Controls.dotnetrix.co.uk.Corners)((((VerseFlow.UI.Controls.dotnetrix.co.uk.Corners.TopLeft | VerseFlow.UI.Controls.dotnetrix.co.uk.Corners.TopRight) 
            | VerseFlow.UI.Controls.dotnetrix.co.uk.Corners.BottomLeft) 
            | VerseFlow.UI.Controls.dotnetrix.co.uk.Corners.BottomRight)));
			this.btnClose.Size = new System.Drawing.Size(14, 13);
			this.btnClose.TabIndex = 4;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// tblCombos
			// 
			this.tblCombos.AutoSize = true;
			this.tblCombos.ColumnCount = 2;
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblCombos.Controls.Add(this.cmbNavigate, 0, 0);
			this.tblCombos.Controls.Add(this.cmbChapter, 1, 0);
			this.tblCombos.Dock = System.Windows.Forms.DockStyle.Top;
			this.tblCombos.Location = new System.Drawing.Point(0, 42);
			this.tblCombos.Margin = new System.Windows.Forms.Padding(0);
			this.tblCombos.Name = "tblCombos";
			this.tblCombos.RowCount = 1;
			this.tblCombos.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblCombos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.tblCombos.Size = new System.Drawing.Size(347, 22);
			this.tblCombos.TabIndex = 5;
			// 
			// cmbChapter
			// 
			this.cmbChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChapter.FormattingEnabled = true;
			this.cmbChapter.Location = new System.Drawing.Point(293, 0);
			this.cmbChapter.Margin = new System.Windows.Forms.Padding(0);
			this.cmbChapter.Name = "cmbChapter";
			this.cmbChapter.Size = new System.Drawing.Size(54, 22);
			this.cmbChapter.TabIndex = 0;
			this.cmbChapter.TextChanged += new System.EventHandler(this.cmbChapter_TextChanged);
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
			this.verseView.Location = new System.Drawing.Point(0, 64);
			this.verseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(347, 356);
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
			this.Controls.Add(this.panelTitle);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(347, 420);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panelTitle.ResumeLayout(false);
			this.panelTitle.PerformLayout();
			this.tblCombos.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Label lblTitle;
		private VerseFlow.UI.Controls.dotnetrix.co.uk.Button btnClose;
		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsColors;
		private System.Windows.Forms.TableLayoutPanel tblCombos;
		private System.Windows.Forms.ComboBox cmbChapter;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tsLblInfo;
		private System.Windows.Forms.ToolStripButton tsPrev;
		private System.Windows.Forms.ToolStripButton tsNext;
	}
}
