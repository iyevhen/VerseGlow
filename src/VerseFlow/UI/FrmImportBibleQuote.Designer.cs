namespace VerseFlow.UI
{
	partial class FrmImportBibleQuote
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gbEnc = new System.Windows.Forms.GroupBox();
			this.txtPreview = new System.Windows.Forms.TextBox();
			this.cmbEnc = new System.Windows.Forms.ComboBox();
			this.cboxUtf8 = new System.Windows.Forms.CheckBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbEnc.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbEnc
			// 
			this.gbEnc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEnc.Controls.Add(this.txtPreview);
			this.gbEnc.Controls.Add(this.cmbEnc);
			this.gbEnc.Controls.Add(this.cboxUtf8);
			this.gbEnc.Location = new System.Drawing.Point(12, 12);
			this.gbEnc.Name = "gbEnc";
			this.gbEnc.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
			this.gbEnc.Size = new System.Drawing.Size(496, 167);
			this.gbEnc.TabIndex = 4;
			this.gbEnc.TabStop = false;
			this.gbEnc.Text = "Encoding";
			// 
			// txtPreview
			// 
			this.txtPreview.AcceptsReturn = true;
			this.txtPreview.AcceptsTab = true;
			this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPreview.Location = new System.Drawing.Point(12, 71);
			this.txtPreview.Multiline = true;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ReadOnly = true;
			this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtPreview.Size = new System.Drawing.Size(472, 85);
			this.txtPreview.TabIndex = 1;
			this.txtPreview.Text = "You can download modules from:\r\n\r\n  http://bqt.ru/Katalog\r\n  http://www.ph4.ru/b4" +
    "_index.ph4\r\n  http://eshatos-lib.ru/mod";
			// 
			// cmbEnc
			// 
			this.cmbEnc.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnc.FormattingEnabled = true;
			this.cmbEnc.Location = new System.Drawing.Point(12, 49);
			this.cmbEnc.Name = "cmbEnc";
			this.cmbEnc.Size = new System.Drawing.Size(472, 22);
			this.cmbEnc.TabIndex = 0;
			this.cmbEnc.SelectedIndexChanged += new System.EventHandler(this.cmbEnc_SelectedIndexChanged);
			// 
			// cboxUtf8
			// 
			this.cboxUtf8.AutoSize = true;
			this.cboxUtf8.Checked = true;
			this.cboxUtf8.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cboxUtf8.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboxUtf8.Location = new System.Drawing.Point(12, 26);
			this.cboxUtf8.Name = "cboxUtf8";
			this.cboxUtf8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.cboxUtf8.Size = new System.Drawing.Size(472, 23);
			this.cboxUtf8.TabIndex = 10;
			this.cboxUtf8.Text = "Use UTF-8 Encoding";
			this.cboxUtf8.UseVisualStyleBackColor = true;
			this.cboxUtf8.CheckedChanged += new System.EventHandler(this.cboxDefault_CheckedChanged);
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpen.Location = new System.Drawing.Point(327, 185);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(87, 25);
			this.btnOpen.TabIndex = 5;
			this.btnOpen.Text = "&Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(421, 185);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 25);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmImportBibleQuote
			// 
			this.AcceptButton = this.btnOpen;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(520, 222);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbEnc);
			this.Controls.Add(this.btnOpen);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmImportBibleQuote";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open BibleQuote Bible";
			this.Load += new System.EventHandler(this.ImportBibleQuote_Load);
			this.gbEnc.ResumeLayout(false);
			this.gbEnc.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEnc;
		private System.Windows.Forms.TextBox txtPreview;
		private System.Windows.Forms.ComboBox cmbEnc;
		private System.Windows.Forms.CheckBox cboxUtf8;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;


	}
}