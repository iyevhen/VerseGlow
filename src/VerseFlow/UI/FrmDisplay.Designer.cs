namespace VerseFlow.UI
{
	partial class FrmDisplay
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
			this.SuspendLayout();
			// 
			// FrmDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 317);
			this.MinimizeBox = false;
			this.Name = "FrmDisplay";
			this.Text = "Double click to fullscreen";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDisplay_FormClosing);
			this.Load += new System.EventHandler(this.FrmDisplay_Load);
			this.DoubleClick += new System.EventHandler(this.FrmDisplay_DoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmDisplay_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion

	}
}