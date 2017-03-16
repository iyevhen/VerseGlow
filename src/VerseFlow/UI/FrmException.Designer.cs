namespace VerseGlow.UI
{
    partial class FrmException
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textException = new System.Windows.Forms.TextBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnSendCrashReport = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::VerseGlow.Properties.Resources.list_remove;
			this.pictureBox1.Location = new System.Drawing.Point(14, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// textException
			// 
			this.textException.AcceptsReturn = true;
			this.textException.AcceptsTab = true;
			this.textException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textException.BackColor = System.Drawing.SystemColors.Control;
			this.textException.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textException.Location = new System.Drawing.Point(14, 54);
			this.textException.Multiline = true;
			this.textException.Name = "textException";
			this.textException.ReadOnly = true;
			this.textException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textException.Size = new System.Drawing.Size(429, 63);
			this.textException.TabIndex = 1;
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.Location = new System.Drawing.Point(58, 13);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(385, 34);
			this.lblMessage.TabIndex = 2;
			this.lblMessage.Text = "<Message>";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSendCrashReport
			// 
			this.btnSendCrashReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSendCrashReport.Location = new System.Drawing.Point(220, 124);
			this.btnSendCrashReport.Name = "btnSendCrashReport";
			this.btnSendCrashReport.Size = new System.Drawing.Size(128, 25);
			this.btnSendCrashReport.TabIndex = 3;
			this.btnSendCrashReport.Text = "&Send crash report";
			this.btnSendCrashReport.UseVisualStyleBackColor = true;
			this.btnSendCrashReport.Click += new System.EventHandler(this.btnSendCrashReport_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(356, 124);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(87, 25);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// FrmException
			// 
			this.AcceptButton = this.btnSendCrashReport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(457, 158);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSendCrashReport);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.textException);
			this.Controls.Add(this.pictureBox1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseGlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseGlow.Properties.Settings.Default.ApplicationFont;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmException";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Error occured while running this application...";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textException;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSendCrashReport;
		private System.Windows.Forms.Button btnClose;
    }
}