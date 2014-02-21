namespace VerseFlow.UI.Controls
{
	partial class DisplayLiveView
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
			this.panelTitle = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsPlay = new System.Windows.Forms.ToolStripButton();
			this.tsPause = new System.Windows.Forms.ToolStripButton();
			this.tsStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonFillBlack = new System.Windows.Forms.ToolStripButton();
			this.splitContainerDots1 = new VerseFlow.UI.Controls.SplitContainerDots();
			this.display1 = new VerseFlow.UI.Controls.Display();
			this.panelTitle.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).BeginInit();
			this.splitContainerDots1.Panel1.SuspendLayout();
			this.splitContainerDots1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitle
			// 
			this.panelTitle.AutoSize = true;
			this.panelTitle.BackColor = System.Drawing.Color.SteelBlue;
			this.panelTitle.Controls.Add(this.lblTitle);
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Location = new System.Drawing.Point(0, 0);
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Padding = new System.Windows.Forms.Padding(2);
			this.panelTitle.Size = new System.Drawing.Size(354, 17);
			this.panelTitle.TabIndex = 5;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.Location = new System.Drawing.Point(2, 2);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(29, 13);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Text = "LIVE";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(1);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPlay,
            this.tsPause,
            this.tsStop,
            this.toolStripSeparator1,
            this.toolStripButtonFillBlack});
			this.toolStrip1.Location = new System.Drawing.Point(0, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(354, 25);
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
			this.tsPause.Image = global::VerseFlow.Properties.Resources.control_pause;
			this.tsPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPause.Name = "tsPause";
			this.tsPause.Size = new System.Drawing.Size(23, 22);
			this.tsPause.Text = "Pause";
			// 
			// tsStop
			// 
			this.tsStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
			this.toolStripButtonFillBlack.Image = global::VerseFlow.Properties.Resources.paint_can;
			this.toolStripButtonFillBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFillBlack.Name = "toolStripButtonFillBlack";
			this.toolStripButtonFillBlack.Size = new System.Drawing.Size(73, 22);
			this.toolStripButtonFillBlack.Text = "Fill Black";
			// 
			// splitContainerDots1
			// 
			this.splitContainerDots1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerDots1.Location = new System.Drawing.Point(0, 42);
			this.splitContainerDots1.Name = "splitContainerDots1";
			this.splitContainerDots1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerDots1.Panel1
			// 
			this.splitContainerDots1.Panel1.Controls.Add(this.display1);
			this.splitContainerDots1.Size = new System.Drawing.Size(354, 280);
			this.splitContainerDots1.SplitterDistance = 121;
			this.splitContainerDots1.TabIndex = 7;
			// 
			// display1
			// 
			this.display1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display1.Etalon = new System.Drawing.Size(4, 3);
			this.display1.Location = new System.Drawing.Point(0, 0);
			this.display1.Name = "display1";
			this.display1.Size = new System.Drawing.Size(354, 121);
			this.display1.TabIndex = 0;
			this.display1.Text = "display1";
			// 
			// DisplayLiveView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerDots1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panelTitle);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "DisplayLiveView";
			this.Size = new System.Drawing.Size(354, 322);
			this.panelTitle.ResumeLayout(false);
			this.panelTitle.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainerDots1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDots1)).EndInit();
			this.splitContainerDots1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonFillBlack;
		private SplitContainerDots splitContainerDots1;
		private Display display1;
		private System.Windows.Forms.ToolStripButton tsPlay;
		private System.Windows.Forms.ToolStripButton tsPause;
		private System.Windows.Forms.ToolStripButton tsStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

	}
}
