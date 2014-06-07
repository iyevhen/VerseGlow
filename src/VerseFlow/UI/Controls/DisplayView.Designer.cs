namespace VerseFlow.UI.Controls
{
	partial class DisplayView
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
			this.splitContainerDots1 = new System.Windows.Forms.SplitContainer();
			this.display1 = new VerseFlow.UI.Controls.Display();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).BeginInit();
			this.splitContainerDots1.Panel1.SuspendLayout();
			this.splitContainerDots1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainerDots1
			// 
			this.splitContainerDots1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerDots1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerDots1.Name = "splitContainerDots1";
			this.splitContainerDots1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerDots1.Panel1
			// 
			this.splitContainerDots1.Panel1.Controls.Add(this.display1);
			this.splitContainerDots1.Panel1.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainerDots1.Size = new System.Drawing.Size(285, 414);
			this.splitContainerDots1.SplitterDistance = 223;
			this.splitContainerDots1.TabIndex = 7;
			// 
			// display1
			// 
			this.display1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display1.Etalon = new System.Drawing.Size(4, 3);
			this.display1.Location = new System.Drawing.Point(2, 2);
			this.display1.Name = "display1";
			this.display1.Size = new System.Drawing.Size(281, 219);
			this.display1.TabIndex = 0;
			this.display1.Text = "display1";
			// 
			// DisplayView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerDots1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DisplayView";
			this.Size = new System.Drawing.Size(285, 414);
			this.splitContainerDots1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).EndInit();
			this.splitContainerDots1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerDots1;
		private Display display1;

	}
}
