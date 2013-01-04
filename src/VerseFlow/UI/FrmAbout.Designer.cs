namespace VerseFlow.UI
{
	partial class FrmAbout
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
			this.btnOK = new System.Windows.Forms.Button();
			this.lnkCheckNewVersion = new System.Windows.Forms.LinkLabel();
			this.txtAbout = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(325, 196);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// lnkCheckNewVersion
			// 
			this.lnkCheckNewVersion.AutoSize = true;
			this.lnkCheckNewVersion.Location = new System.Drawing.Point(12, 196);
			this.lnkCheckNewVersion.Name = "lnkCheckNewVersion";
			this.lnkCheckNewVersion.Size = new System.Drawing.Size(122, 13);
			this.lnkCheckNewVersion.TabIndex = 2;
			this.lnkCheckNewVersion.TabStop = true;
			this.lnkCheckNewVersion.Text = "Check for new version...";
			// 
			// txtAbout
			// 
			this.txtAbout.AcceptsReturn = true;
			this.txtAbout.AcceptsTab = true;
			this.txtAbout.Location = new System.Drawing.Point(15, 34);
			this.txtAbout.Multiline = true;
			this.txtAbout.Name = "txtAbout";
			this.txtAbout.ReadOnly = true;
			this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtAbout.Size = new System.Drawing.Size(385, 108);
			this.txtAbout.TabIndex = 3;
			this.txtAbout.Text = "This is a free software.\r\n\r\nIcons are taken from - http://www.fatcow.com/free-ico" +
    "ns\r\n\r\nIf you some suggestions on how to make this app better please contact via " +
    "verseflow@gmail.com\r\n";
			// 
			// FrmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(412, 231);
			this.Controls.Add(this.txtAbout);
			this.Controls.Add(this.lnkCheckNewVersion);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmAbout";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.LinkLabel lnkCheckNewVersion;
		private System.Windows.Forms.TextBox txtAbout;
	}
}