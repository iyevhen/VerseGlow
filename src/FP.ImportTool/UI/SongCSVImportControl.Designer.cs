using System.Windows.Forms;
using FreePresenter.UI.Controls;

namespace FreePresenter.UI.ImportTool
{
	partial class SongCSVImportControl
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
			this.btnImport = new System.Windows.Forms.Button();
			this.txtBoxDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
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
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Enabled = false;
			this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btnImport.Location = new System.Drawing.Point(282, 244);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(105, 25);
			this.btnImport.TabIndex = 16;
			this.btnImport.Text = "&Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txtBoxDescription
			// 
			this.txtBoxDescription.AcceptsReturn = true;
			this.txtBoxDescription.AcceptsTab = true;
			this.txtBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBoxDescription.Location = new System.Drawing.Point(12, 160);
			this.txtBoxDescription.Multiline = true;
			this.txtBoxDescription.Name = "txtBoxDescription";
			this.txtBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtBoxDescription.Size = new System.Drawing.Size(371, 75);
			this.txtBoxDescription.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(9, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Описание";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
			this.label3.Location = new System.Drawing.Point(9, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(142, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Исходная кодировка файла";
			// 
			// comboBoxEncoding
			// 
			this.comboBoxEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEncoding.DropDownHeight = 250;
			this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEncoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.comboBoxEncoding.FormattingEnabled = true;
			this.comboBoxEncoding.IntegralHeight = false;
			this.comboBoxEncoding.ItemHeight = 13;
			this.comboBoxEncoding.Location = new System.Drawing.Point(12, 116);
			this.comboBoxEncoding.Name = "comboBoxEncoding";
			this.comboBoxEncoding.Size = new System.Drawing.Size(371, 21);
			this.comboBoxEncoding.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
			this.label1.Location = new System.Drawing.Point(9, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Путь к исходному файлу";
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btnSelectFile.Location = new System.Drawing.Point(358, 73);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(25, 25);
			this.btnSelectFile.TabIndex = 12;
			this.btnSelectFile.Text = "...";
			this.btnSelectFile.UseVisualStyleBackColor = true;
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// txtBoxInputFile
			// 
			this.txtBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxInputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBoxInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.txtBoxInputFile.Location = new System.Drawing.Point(12, 77);
			this.txtBoxInputFile.MaxLength = 1000;
			this.txtBoxInputFile.Name = "txtBoxInputFile";
			this.txtBoxInputFile.Size = new System.Drawing.Size(340, 20);
			this.txtBoxInputFile.TabIndex = 11;
			this.txtBoxInputFile.WordWrap = false;
			this.txtBoxInputFile.TextChanged += new System.EventHandler(this.EnableImport_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Margin = new System.Windows.Forms.Padding(10);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(10);
			this.label4.Size = new System.Drawing.Size(226, 44);
			this.label4.TabIndex = 23;
			this.label4.Text = "Import Songs from CSV";
			// 
			// SongCSVImportControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBoxDescription);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxEncoding);
			this.Controls.Add(this.txtBoxInputFile);
			this.Controls.Add(this.btnSelectFile);
			this.Name = "SongCSVImportControl";
			this.Size = new System.Drawing.Size(399, 284);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtBoxDescription;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxEncoding;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.TextBox txtBoxInputFile;
		private Label label4;
	}
}