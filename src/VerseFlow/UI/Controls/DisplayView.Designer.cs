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
			this.liveSpy = new VerseFlow.UI.Controls.DisplayControl();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.tsPlay = new System.Windows.Forms.ToolStripButton();
			this.tsPause = new System.Windows.Forms.ToolStripButton();
			this.tsStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonFillBlack = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblDispName = new System.Windows.Forms.Label();
			this.previewSpy = new VerseFlow.UI.Controls.DisplayControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblOptions = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.panel2.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.liveSpy);
			this.splitContainer1.Panel1.Controls.Add(this.toolStripMain);
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.previewSpy);
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Size = new System.Drawing.Size(468, 717);
			this.splitContainer1.SplitterDistance = 370;
			this.splitContainer1.TabIndex = 7;
			// 
			// liveSpy
			// 
			this.liveSpy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.liveSpy.Location = new System.Drawing.Point(0, 42);
			this.liveSpy.Margin = new System.Windows.Forms.Padding(0);
			this.liveSpy.Name = "liveSpy";
			this.liveSpy.ProportionSize = new System.Drawing.Size(4, 3);
			this.liveSpy.Size = new System.Drawing.Size(468, 328);
			this.liveSpy.TabIndex = 0;
			this.liveSpy.Text = "displaySmall";
			// 
			// toolStripMain
			// 
			this.toolStripMain.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPlay,
            this.tsPause,
            this.tsStop,
            this.toolStripSeparator1,
            this.toolStripButtonFillBlack});
			this.toolStripMain.Location = new System.Drawing.Point(0, 17);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripMain.Size = new System.Drawing.Size(468, 25);
			this.toolStripMain.TabIndex = 8;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// tsPlay
			// 
			this.tsPlay.CheckOnClick = true;
			this.tsPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPlay.Image = global::VerseFlow.Properties.Resources._1402417413_player_play;
			this.tsPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPlay.Name = "tsPlay";
			this.tsPlay.Size = new System.Drawing.Size(23, 22);
			this.tsPlay.Text = "Play";
			this.tsPlay.Click += new System.EventHandler(this.tsPlay_Click);
			// 
			// tsPause
			// 
			this.tsPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsPause.Image = global::VerseFlow.Properties.Resources._1402417487_tool_pause;
			this.tsPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPause.Name = "tsPause";
			this.tsPause.Size = new System.Drawing.Size(23, 22);
			this.tsPause.Text = "Pause";
			// 
			// tsStop
			// 
			this.tsStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsStop.Image = global::VerseFlow.Properties.Resources._1402417465_player_stop;
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
			this.toolStripButtonFillBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonFillBlack.Name = "toolStripButtonFillBlack";
			this.toolStripButtonFillBlack.Size = new System.Drawing.Size(57, 22);
			this.toolStripButtonFillBlack.Text = "Fill Black";
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel2.Controls.Add(this.lblDispName);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(468, 17);
			this.panel2.TabIndex = 2;
			// 
			// lblDispName
			// 
			this.lblDispName.AutoSize = true;
			this.lblDispName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDispName.ForeColor = System.Drawing.Color.White;
			this.lblDispName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDispName.Location = new System.Drawing.Point(2, 2);
			this.lblDispName.Name = "lblDispName";
			this.lblDispName.Size = new System.Drawing.Size(72, 13);
			this.lblDispName.TabIndex = 0;
			this.lblDispName.Text = "Display Name";
			this.lblDispName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// previewSpy
			// 
			this.previewSpy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.previewSpy.Location = new System.Drawing.Point(0, 17);
			this.previewSpy.Margin = new System.Windows.Forms.Padding(0);
			this.previewSpy.Name = "previewSpy";
			this.previewSpy.ProportionSize = new System.Drawing.Size(4, 3);
			this.previewSpy.Size = new System.Drawing.Size(468, 326);
			this.previewSpy.TabIndex = 2;
			this.previewSpy.Text = "displaySmall";
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.lblOptions);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(468, 17);
			this.panel1.TabIndex = 1;
			// 
			// lblOptions
			// 
			this.lblOptions.AutoSize = true;
			this.lblOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblOptions.ForeColor = System.Drawing.Color.White;
			this.lblOptions.Location = new System.Drawing.Point(2, 2);
			this.lblOptions.Name = "lblOptions";
			this.lblOptions.Size = new System.Drawing.Size(45, 13);
			this.lblOptions.TabIndex = 0;
			this.lblOptions.Text = "Preview";
			// 
			// DisplayView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DisplayView";
			this.Size = new System.Drawing.Size(468, 717);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private DisplayControl liveSpy;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblOptions;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblDispName;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripButton tsPlay;
		private System.Windows.Forms.ToolStripButton tsPause;
		private System.Windows.Forms.ToolStripButton tsStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonFillBlack;
		private DisplayControl previewSpy;

	}
}
