namespace FreePresenter.UI.ImportTool
{
	partial class BibleCSVImportControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibleCSVImportControl));
			this.btnImport = new System.Windows.Forms.Button();
			this.txtBoxDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxSeparator = new System.Windows.Forms.ComboBox();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.txtBoxInputFile = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnImport
			// 
			resources.ApplyResources(this.btnImport, "btnImport");
			this.btnImport.Name = "btnImport";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// txtBoxDescription
			// 
			this.txtBoxDescription.AcceptsReturn = true;
			this.txtBoxDescription.AcceptsTab = true;
			this.txtBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtBoxDescription, "txtBoxDescription");
			this.txtBoxDescription.Name = "txtBoxDescription";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Name = "label2";
			// 
			// comboBoxSeparator
			// 
			resources.ApplyResources(this.comboBoxSeparator, "comboBoxSeparator");
			this.comboBoxSeparator.FormattingEnabled = true;
			this.comboBoxSeparator.Name = "comboBoxSeparator";
			this.comboBoxSeparator.TextChanged += new System.EventHandler(this.EnableBtnConvert_Handler);
			// 
			// lblSeparator
			// 
			resources.ApplyResources(this.lblSeparator, "lblSeparator");
			this.lblSeparator.BackColor = System.Drawing.Color.Transparent;
			this.lblSeparator.Name = "lblSeparator";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Name = "label3";
			// 
			// comboBoxEncoding
			// 
			this.comboBoxEncoding.DropDownHeight = 250;
			this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.comboBoxEncoding, "comboBoxEncoding");
			this.comboBoxEncoding.FormattingEnabled = true;
			this.comboBoxEncoding.Name = "comboBoxEncoding";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Name = "label1";
			// 
			// btnSelectFile
			// 
			resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.UseVisualStyleBackColor = true;
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// txtBoxInputFile
			// 
			this.txtBoxInputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.txtBoxInputFile, "txtBoxInputFile");
			this.txtBoxInputFile.Name = "txtBoxInputFile";
			this.txtBoxInputFile.TextChanged += new System.EventHandler(this.EnableBtnConvert_Handler);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// BibleCSVImportControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtBoxInputFile);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBoxDescription);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.comboBoxEncoding);
			this.Controls.Add(this.lblSeparator);
			this.Controls.Add(this.comboBoxSeparator);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnSelectFile);
			this.Name = "BibleCSVImportControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtBoxDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxSeparator;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxEncoding;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.TextBox txtBoxInputFile;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Label label4;

	}
}

