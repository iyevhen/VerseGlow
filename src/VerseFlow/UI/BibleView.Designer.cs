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
            this.cmbContents = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbChapters = new System.Windows.Forms.ComboBox();
            this.verseView1 = new VerseFlow.UI.Controls.VerseView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbContents
            // 
            this.cmbContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbContents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContents.FormattingEnabled = true;
            this.cmbContents.Location = new System.Drawing.Point(0, 0);
            this.cmbContents.Name = "cmbContents";
            this.cmbContents.Size = new System.Drawing.Size(275, 21);
            this.cmbContents.TabIndex = 7;
            this.cmbContents.SelectedIndexChanged += new System.EventHandler(this.cmbContents_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbContents);
            this.panel1.Controls.Add(this.cmbChapters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 24);
            this.panel1.TabIndex = 11;
            // 
            // cmbChapters
            // 
            this.cmbChapters.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbChapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChapters.FormattingEnabled = true;
            this.cmbChapters.Location = new System.Drawing.Point(275, 0);
            this.cmbChapters.Name = "cmbChapters";
            this.cmbChapters.Size = new System.Drawing.Size(56, 21);
            this.cmbChapters.TabIndex = 7;
            this.cmbChapters.SelectedIndexChanged += new System.EventHandler(this.cmbChapters_SelectedIndexChanged);
            // 
            // verseView1
            // 
            this.verseView1.AutoScroll = true;
            this.verseView1.AutoScrollMinSize = new System.Drawing.Size(321, 0);
            this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
            this.verseView1.BackColor = System.Drawing.Color.Silver;
            this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verseView1.DrawSeparatorLine = true;
            this.verseView1.HighlightText = null;
            this.verseView1.Location = new System.Drawing.Point(0, 24);
            this.verseView1.Name = "verseView1";
            this.verseView1.Padding = new System.Windows.Forms.Padding(5);
            this.verseView1.Size = new System.Drawing.Size(331, 384);
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
            this.Size = new System.Drawing.Size(331, 408);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ComboBox cmbContents;
        private Controls.VerseView verseView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbChapters;
	}
}
