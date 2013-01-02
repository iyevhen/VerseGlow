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
			this.lblInfo = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.lnkCheckNewVersion = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.Location = new System.Drawing.Point(12, 22);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(388, 159);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.Text = "This is a free software.\r\n\r\nIcons are taken from - http://www.fatcow.com/free-ico" +
    "ns\r\n\r\nIf you some suggestions on how to make this app better please contact via " +
    "verseflow@gmail.com\r\n\r\n";
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
			// FrmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(412, 231);
			this.Controls.Add(this.lnkCheckNewVersion);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblInfo);
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

		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.LinkLabel lnkCheckNewVersion;
	}
}