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
			this.tsFont = new System.Windows.Forms.ToolStripButton();
			this.tsColors = new System.Windows.Forms.ToolStripButton();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.panelTitle = new System.Windows.Forms.Panel();
			this.tblCombos = new System.Windows.Forms.TableLayoutPanel();
			this.cmbChapter = new System.Windows.Forms.ComboBox();
			this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
			this.lblInfo = new System.Windows.Forms.Label();
			this.verseView = new VerseFlow.UI.Controls.VerseView();
			this.btnPrev = new VerseFlow.UI.Controls.dotnetrix.co.uk.Button();
			this.btnNext = new VerseFlow.UI.Controls.dotnetrix.co.uk.Button();
			this.toolStrip1.SuspendLayout();
			this.panelTitle.SuspendLayout();
			this.tblCombos.SuspendLayout();
			this.tblInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbNavigate
			// 
			this.cmbNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbNavigate.FormattingEnabled = true;
			this.cmbNavigate.Location = new System.Drawing.Point(0, 0);
			this.cmbNavigate.Margin = new System.Windows.Forms.Padding(0);
			this.cmbNavigate.Name = "cmbNavigate";
			this.cmbNavigate.Size = new System.Drawing.Size(236, 22);
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
            this.tsFont,
            this.tsColors});
			this.toolStrip1.Location = new System.Drawing.Point(0, 18);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
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
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Font = new System.Drawing.Font("Verdana", 4F);
			this.btnClose.Image = global::VerseFlow.Properties.Resources.fileclose;
			this.btnClose.Location = new System.Drawing.Point(328, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(14, 14);
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
			this.panelTitle.Size = new System.Drawing.Size(347, 18);
			this.panelTitle.TabIndex = 4;
			// 
			// tblCombos
			// 
			this.tblCombos.AutoSize = true;
			this.tblCombos.ColumnCount = 4;
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblCombos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblCombos.Controls.Add(this.cmbNavigate, 0, 0);
			this.tblCombos.Controls.Add(this.cmbChapter, 1, 0);
			this.tblCombos.Controls.Add(this.btnPrev, 2, 0);
			this.tblCombos.Controls.Add(this.btnNext, 3, 0);
			this.tblCombos.Dock = System.Windows.Forms.DockStyle.Top;
			this.tblCombos.Location = new System.Drawing.Point(0, 59);
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
			this.cmbChapter.Location = new System.Drawing.Point(236, 0);
			this.cmbChapter.Margin = new System.Windows.Forms.Padding(0);
			this.cmbChapter.Name = "cmbChapter";
			this.cmbChapter.Size = new System.Drawing.Size(67, 22);
			this.cmbChapter.TabIndex = 0;
			this.cmbChapter.TextChanged += new System.EventHandler(this.cmbNavigate_TextChanged);
			// 
			// tblInfo
			// 
			this.tblInfo.AutoSize = true;
			this.tblInfo.ColumnCount = 1;
			this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblInfo.Controls.Add(this.lblInfo, 0, 0);
			this.tblInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.tblInfo.Location = new System.Drawing.Point(0, 43);
			this.tblInfo.Margin = new System.Windows.Forms.Padding(0);
			this.tblInfo.Name = "tblInfo";
			this.tblInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.tblInfo.RowCount = 1;
			this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
			this.tblInfo.Size = new System.Drawing.Size(347, 16);
			this.tblInfo.TabIndex = 6;
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.AutoSize = true;
			this.lblInfo.ForeColor = System.Drawing.Color.Gray;
			this.lblInfo.Location = new System.Drawing.Point(0, 0);
			this.lblInfo.Margin = new System.Windows.Forms.Padding(0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(347, 14);
			this.lblInfo.TabIndex = 7;
			this.lblInfo.Text = "Select book from dropdown...";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.verseView.Location = new System.Drawing.Point(0, 81);
			this.verseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.verseView.Name = "verseView";
			this.verseView.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.verseView.ReadOnly = false;
			this.verseView.Size = new System.Drawing.Size(347, 339);
			this.verseView.TabIndex = 1;
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(303, 0);
			this.btnPrev.Margin = new System.Windows.Forms.Padding(0);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(22, 22);
			this.btnPrev.TabIndex = 1;
			this.btnPrev.Text = "<";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(325, 0);
			this.btnNext.Margin = new System.Windows.Forms.Padding(0);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(22, 22);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = ">";
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView);
			this.Controls.Add(this.tblCombos);
			this.Controls.Add(this.tblInfo);
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
			this.tblInfo.ResumeLayout(false);
			this.tblInfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.VerseView verseView;
		private System.Windows.Forms.ComboBox cmbNavigate;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.ToolStripButton tsFont;
		private System.Windows.Forms.ToolStripButton tsColors;
		private System.Windows.Forms.TableLayoutPanel tblCombos;
		private System.Windows.Forms.ComboBox cmbChapter;
		private VerseFlow.UI.Controls.dotnetrix.co.uk.Button btnPrev;
		private VerseFlow.UI.Controls.dotnetrix.co.uk.Button btnNext;
		private System.Windows.Forms.TableLayoutPanel tblInfo;
		private System.Windows.Forms.Label lblInfo;
	}
}
