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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsPlay = new System.Windows.Forms.ToolStripButton();
			this.tsPause = new System.Windows.Forms.ToolStripButton();
			this.tsStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonFillBlack = new System.Windows.Forms.ToolStripButton();
			this.splitContainerDots1 = new System.Windows.Forms.SplitContainer();
			this.tsDisplay = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.display1 = new VerseFlow.UI.Controls.Display();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).BeginInit();
			this.splitContainerDots1.Panel1.SuspendLayout();
			this.splitContainerDots1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDisplay,
            this.toolStripSeparator2,
            this.tsPlay,
            this.tsPause,
            this.tsStop,
            this.toolStripSeparator1,
            this.toolStripButtonFillBlack});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(285, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsPlay
			// 
			this.tsPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPlay.Image = global::VerseFlow.Properties.Resources.control;
			this.tsPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPlay.Name = "tsPlay";
			this.tsPlay.Size = new System.Drawing.Size(23, 22);
			this.tsPlay.Text = "Play";
			// 
			// tsPause
			// 
			this.tsPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPause.Enabled = false;
			this.tsPause.Image = global::VerseFlow.Properties.Resources.control_pause;
			this.tsPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPause.Name = "tsPause";
			this.tsPause.Size = new System.Drawing.Size(23, 22);
			this.tsPause.Text = "Pause";
			// 
			// tsStop
			// 
			this.tsStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsStop.Enabled = false;
			this.tsStop.Image = global::VerseFlow.Properties.Resources.control_stop_square;
			this.tsStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsStop.Name = "tsStop";
			this.tsStop.Size = new System.Drawing.Size(23, 22);
			this.tsStop.Text = "Stop";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonFillBlack
			// 
			this.toolStripButtonFillBlack.Enabled = false;
			this.toolStripButtonFillBlack.Image = global::VerseFlow.Properties.Resources.paint_can;
			this.toolStripButtonFillBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFillBlack.Name = "toolStripButtonFillBlack";
			this.toolStripButtonFillBlack.Size = new System.Drawing.Size(73, 22);
			this.toolStripButtonFillBlack.Text = "Fill Black";
			// 
			// splitContainerDots1
			// 
			this.splitContainerDots1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerDots1.Location = new System.Drawing.Point(0, 25);
			this.splitContainerDots1.Name = "splitContainerDots1";
			this.splitContainerDots1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerDots1.Panel1
			// 
			this.splitContainerDots1.Panel1.Controls.Add(this.display1);
			this.splitContainerDots1.Panel1.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainerDots1.Size = new System.Drawing.Size(285, 389);
			this.splitContainerDots1.SplitterDistance = 210;
			this.splitContainerDots1.TabIndex = 7;
			// 
			// tsDisplay
			// 
			this.tsDisplay.Image = global::VerseFlow.Properties.Resources.monitor;
			this.tsDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDisplay.Name = "tsDisplay";
			this.tsDisplay.Size = new System.Drawing.Size(90, 22);
			this.tsDisplay.Text = "<Display>";
			this.tsDisplay.DropDownOpening += new System.EventHandler(this.tsDisplay_DropDownOpening);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// display1
			// 
			this.display1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display1.Etalon = new System.Drawing.Size(4, 3);
			this.display1.Location = new System.Drawing.Point(2, 2);
			this.display1.Name = "display1";
			this.display1.Size = new System.Drawing.Size(281, 206);
			this.display1.TabIndex = 0;
			this.display1.Text = "display1";
			// 
			// DisplayView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerDots1);
			this.Controls.Add(this.toolStrip1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "DisplayView";
			this.Size = new System.Drawing.Size(285, 414);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainerDots1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).EndInit();
			this.splitContainerDots1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonFillBlack;
		private System.Windows.Forms.SplitContainer splitContainerDots1;
		private Display display1;
		private System.Windows.Forms.ToolStripButton tsPlay;
		private System.Windows.Forms.ToolStripButton tsPause;
		private System.Windows.Forms.ToolStripButton tsStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton tsDisplay;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

	}
}
