namespace VerseFlow.UI
{
	partial class FrmBibleViewColors
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
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(449, 0);
			this.verseView1.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.verseView1.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(5, 5);
			this.verseView1.Name = "verseView1";
			this.verseView1.ReadOnly = false;
			this.verseView1.Size = new System.Drawing.Size(449, 283);
			this.verseView1.TabIndex = 0;
			this.verseView1.Text = "verseViewSample";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 288);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(449, 33);
			this.panel1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(359, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 25);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(266, 5);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(87, 25);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// FrmBibleViewColors
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(459, 326);
			this.Controls.Add(this.verseView1);
			this.Controls.Add(this.panel1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmBibleViewColors";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bible View Colors";
			this.Load += new System.EventHandler(this.FrmBibleViewColors_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.VerseView verseView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}