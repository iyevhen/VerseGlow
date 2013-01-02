namespace VerseFlow.UI
{
	partial class FrmImportBibleQuote
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtPreview = new System.Windows.Forms.TextBox();
			this.lblEnc = new System.Windows.Forms.Label();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cmbEnc = new System.Windows.Forms.ComboBox();
			this.lblPreview = new System.Windows.Forms.Label();
			this.gbEnc = new System.Windows.Forms.GroupBox();
			this.cboxDefault = new System.Windows.Forms.CheckBox();
			this.gbFolder = new System.Windows.Forms.GroupBox();
			this.gbEnc.SuspendLayout();
			this.gbFolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPreview
			// 
			this.txtPreview.AcceptsReturn = true;
			this.txtPreview.AcceptsTab = true;
			this.txtPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPreview.Font = new System.Drawing.Font("Courier New", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtPreview.Location = new System.Drawing.Point(9, 110);
			this.txtPreview.Multiline = true;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ReadOnly = true;
			this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtPreview.Size = new System.Drawing.Size(493, 104);
			this.txtPreview.TabIndex = 0;
			// 
			// lblEnc
			// 
			this.lblEnc.AutoSize = true;
			this.lblEnc.Location = new System.Drawing.Point(6, 44);
			this.lblEnc.Name = "lblEnc";
			this.lblEnc.Size = new System.Drawing.Size(52, 13);
			this.lblEnc.TabIndex = 1;
			this.lblEnc.Text = "Encoding";
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(364, 295);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 2;
			this.btnImport.Text = "&Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(445, 295);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtFolder
			// 
			this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFolder.Font = new System.Drawing.Font("Courier New", 9.25F);
			this.txtFolder.Location = new System.Drawing.Point(9, 19);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(462, 21);
			this.txtFolder.TabIndex = 4;
			this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(474, 17);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(28, 23);
			this.btnBrowse.TabIndex = 7;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// cmbEnc
			// 
			this.cmbEnc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnc.Font = new System.Drawing.Font("Courier New", 9.25F);
			this.cmbEnc.FormattingEnabled = true;
			this.cmbEnc.Location = new System.Drawing.Point(9, 60);
			this.cmbEnc.Name = "cmbEnc";
			this.cmbEnc.Size = new System.Drawing.Size(493, 23);
			this.cmbEnc.TabIndex = 8;
			this.cmbEnc.SelectedIndexChanged += new System.EventHandler(this.cmbEnc_SelectedIndexChanged);
			// 
			// lblPreview
			// 
			this.lblPreview.AutoSize = true;
			this.lblPreview.Location = new System.Drawing.Point(6, 94);
			this.lblPreview.Name = "lblPreview";
			this.lblPreview.Size = new System.Drawing.Size(162, 13);
			this.lblPreview.TabIndex = 9;
			this.lblPreview.Text = "bibleqt.ini Preview with Encoding";
			// 
			// gbEnc
			// 
			this.gbEnc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEnc.Controls.Add(this.cboxDefault);
			this.gbEnc.Controls.Add(this.cmbEnc);
			this.gbEnc.Controls.Add(this.lblPreview);
			this.gbEnc.Controls.Add(this.lblEnc);
			this.gbEnc.Controls.Add(this.txtPreview);
			this.gbEnc.Location = new System.Drawing.Point(12, 69);
			this.gbEnc.Name = "gbEnc";
			this.gbEnc.Size = new System.Drawing.Size(508, 220);
			this.gbEnc.TabIndex = 10;
			this.gbEnc.TabStop = false;
			this.gbEnc.Text = "Specify Encoding BibleQuote module is using";
			// 
			// cboxDefault
			// 
			this.cboxDefault.AutoSize = true;
			this.cboxDefault.Checked = true;
			this.cboxDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cboxDefault.Location = new System.Drawing.Point(7, 20);
			this.cboxDefault.Name = "cboxDefault";
			this.cboxDefault.Size = new System.Drawing.Size(130, 17);
			this.cboxDefault.TabIndex = 10;
			this.cboxDefault.Text = "Use Default Encoding";
			this.cboxDefault.UseVisualStyleBackColor = true;
			this.cboxDefault.CheckedChanged += new System.EventHandler(this.cboxDefault_CheckedChanged);
			// 
			// gbFolder
			// 
			this.gbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbFolder.Controls.Add(this.txtFolder);
			this.gbFolder.Controls.Add(this.btnBrowse);
			this.gbFolder.Location = new System.Drawing.Point(12, 11);
			this.gbFolder.Name = "gbFolder";
			this.gbFolder.Size = new System.Drawing.Size(508, 52);
			this.gbFolder.TabIndex = 11;
			this.gbFolder.TabStop = false;
			this.gbFolder.Text = "Please specify folder where BibleQuote module is located";
			// 
			// FrmImportBibleQuote
			// 
			this.AcceptButton = this.btnImport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(532, 330);
			this.Controls.Add(this.gbFolder);
			this.Controls.Add(this.gbEnc);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnImport);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmImportBibleQuote";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import from BibleQuote";
			this.Load += new System.EventHandler(this.FrmImportBibleQuote_Load);
			this.gbEnc.ResumeLayout(false);
			this.gbEnc.PerformLayout();
			this.gbFolder.ResumeLayout(false);
			this.gbFolder.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtPreview;
		private System.Windows.Forms.Label lblEnc;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ComboBox cmbEnc;
		private System.Windows.Forms.Label lblPreview;
		private System.Windows.Forms.GroupBox gbEnc;
		private System.Windows.Forms.GroupBox gbFolder;
		private System.Windows.Forms.CheckBox cboxDefault;
	}
}