namespace VerseFlow.UI.Controls
{
	partial class DisplayView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;


		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.preview = new VerseFlow.UI.Controls.FakeDisplay();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.preview);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.splitContainer1.Size = new System.Drawing.Size(285, 414);
			this.splitContainer1.SplitterDistance = 223;
			this.splitContainer1.TabIndex = 7;
			// 
			// displaySmall
			// 
			this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.preview.ProportionSize = new System.Drawing.Size(4, 3);
			this.preview.Location = new System.Drawing.Point(2, 2);
			this.preview.Margin = new System.Windows.Forms.Padding(0);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(281, 219);
			this.preview.TabIndex = 0;
			this.preview.Text = "displaySmall";
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.BackColor = System.Drawing.Color.SteelBlue;
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(279, 17);
			this.panel1.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(2, 2);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(43, 13);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Options";
			// 
			// DisplayView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DisplayView";
			this.Size = new System.Drawing.Size(285, 414);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private FakeDisplay preview;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTitle;

	}
}
