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
			this.cmbChapters = new System.Windows.Forms.ComboBox();
			this.cmbContents = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbChapters
			// 
			this.cmbChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChapters.FormattingEnabled = true;
			this.cmbChapters.Location = new System.Drawing.Point(239, 0);
			this.cmbChapters.Name = "cmbChapters";
			this.cmbChapters.Size = new System.Drawing.Size(58, 21);
			this.cmbChapters.TabIndex = 8;
			this.cmbChapters.SelectedIndexChanged += new System.EventHandler(this.cmbChapters_SelectedIndexChanged);
			// 
			// cmbContents
			// 
			this.cmbContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbContents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbContents.FormattingEnabled = true;
			this.cmbContents.Location = new System.Drawing.Point(0, 0);
			this.cmbContents.Name = "cmbContents";
			this.cmbContents.Size = new System.Drawing.Size(233, 21);
			this.cmbContents.TabIndex = 7;
			this.cmbContents.SelectedIndexChanged += new System.EventHandler(this.cmbContents_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.cmbChapters);
			this.panel1.Controls.Add(this.cmbContents);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(301, 24);
			this.panel1.TabIndex = 9;
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(275, 0);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.DrawSeparatorLine = false;
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 24);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(301, 385);
			this.verseView1.TabIndex = 10;
			// 
			// BibleView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.verseView1);
			this.Controls.Add(this.panel1);
			this.Name = "BibleView";
			this.Size = new System.Drawing.Size(301, 409);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbChapters;
		private System.Windows.Forms.ComboBox cmbContents;
		private System.Windows.Forms.Panel panel1;
		private Controls.VerseView verseView1;
	}
}
