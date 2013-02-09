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
			this.gbFolder = new System.Windows.Forms.GroupBox();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.gbEnc = new System.Windows.Forms.GroupBox();
			this.txtPreview = new System.Windows.Forms.TextBox();
			this.cmbEnc = new System.Windows.Forms.ComboBox();
			this.cboxDefault = new System.Windows.Forms.CheckBox();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbFolder.SuspendLayout();
			this.gbEnc.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbFolder
			// 
			this.gbFolder.Controls.Add(this.txtFolder);
			this.gbFolder.Controls.Add(this.btnBrowse);
			this.gbFolder.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbFolder.Location = new System.Drawing.Point(0, 0);
			this.gbFolder.Margin = new System.Windows.Forms.Padding(10);
			this.gbFolder.Name = "gbFolder";
			this.gbFolder.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
			this.gbFolder.Size = new System.Drawing.Size(538, 48);
			this.gbFolder.TabIndex = 3;
			this.gbFolder.TabStop = false;
			this.gbFolder.Text = "Path to BibleQuote module";
			// 
			// txtFolder
			// 
			this.txtFolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFolder.Location = new System.Drawing.Point(10, 16);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(496, 20);
			this.txtFolder.TabIndex = 0;
			this.txtFolder.WordWrap = false;
			this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnBrowse.Location = new System.Drawing.Point(506, 16);
			this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(22, 22);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// gbEnc
			// 
			this.gbEnc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEnc.Controls.Add(this.txtPreview);
			this.gbEnc.Controls.Add(this.cmbEnc);
			this.gbEnc.Controls.Add(this.cboxDefault);
			this.gbEnc.Location = new System.Drawing.Point(0, 52);
			this.gbEnc.Name = "gbEnc";
			this.gbEnc.Padding = new System.Windows.Forms.Padding(10);
			this.gbEnc.Size = new System.Drawing.Size(538, 201);
			this.gbEnc.TabIndex = 4;
			this.gbEnc.TabStop = false;
			this.gbEnc.Text = "Encoding";
			// 
			// txtPreview
			// 
			this.txtPreview.AcceptsReturn = true;
			this.txtPreview.AcceptsTab = true;
			this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPreview.Location = new System.Drawing.Point(10, 67);
			this.txtPreview.Multiline = true;
			this.txtPreview.Name = "txtPreview";
			this.txtPreview.ReadOnly = true;
			this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtPreview.Size = new System.Drawing.Size(518, 124);
			this.txtPreview.TabIndex = 1;
			this.txtPreview.Text = "You can download modules from:\r\n\r\n1. http://bqt.ru/Katalog\r\n2. http://www.ph4.ru/" +
    "b4_index.ph4";
			// 
			// cmbEnc
			// 
			this.cmbEnc.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnc.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.cmbEnc.FormattingEnabled = true;
			this.cmbEnc.Location = new System.Drawing.Point(10, 45);
			this.cmbEnc.Name = "cmbEnc";
			this.cmbEnc.Size = new System.Drawing.Size(518, 22);
			this.cmbEnc.Sorted = true;
			this.cmbEnc.TabIndex = 0;
			this.cmbEnc.SelectedIndexChanged += new System.EventHandler(this.cmbEnc_SelectedIndexChanged);
			// 
			// cboxDefault
			// 
			this.cboxDefault.AutoSize = true;
			this.cboxDefault.Checked = true;
			this.cboxDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cboxDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboxDefault.Location = new System.Drawing.Point(10, 23);
			this.cboxDefault.Name = "cboxDefault";
			this.cboxDefault.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.cboxDefault.Size = new System.Drawing.Size(518, 22);
			this.cboxDefault.TabIndex = 10;
			this.cboxDefault.Text = "Use Default Encoding";
			this.cboxDefault.UseVisualStyleBackColor = true;
			this.cboxDefault.CheckedChanged += new System.EventHandler(this.cboxDefault_CheckedChanged);
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(372, 259);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "&Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(453, 259);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmImportBibleQuote
			// 
			this.AcceptButton = this.btnImport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(538, 293);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbEnc);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.gbFolder);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmImportBibleQuote";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import from BibleQuote";
			this.Load += new System.EventHandler(this.ImportBibleQuote_Load);
			this.gbFolder.ResumeLayout(false);
			this.gbFolder.PerformLayout();
			this.gbEnc.ResumeLayout(false);
			this.gbEnc.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbFolder;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.GroupBox gbEnc;
		private System.Windows.Forms.TextBox txtPreview;
		private System.Windows.Forms.ComboBox cmbEnc;
		private System.Windows.Forms.CheckBox cboxDefault;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button btnCancel;


	}
}