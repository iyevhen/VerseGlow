using VerseFlow.UI.Controls;

namespace VerseFlow.UI
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;



		#region Windows Form Designer generated code


		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{


			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.toolStripBibles = new System.Windows.Forms.ToolStrip();
			this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.tblBibles = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tblDisplay = new System.Windows.Forms.TableLayoutPanel();
			this.displayView = new VerseFlow.UI.Controls.DisplayView();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.tsDisplay = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsGoLive = new System.Windows.Forms.ToolStripButton();
			this.tsPause = new System.Windows.Forms.ToolStripButton();
			this.tsStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonFillBlack = new System.Windows.Forms.ToolStripButton();
			this.toolStripBibles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tblDisplay.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripBibles
			// 
			this.toolStripBibles.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStripBibles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripBibles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsAbout});
			this.toolStripBibles.Location = new System.Drawing.Point(0, 0);
			this.toolStripBibles.Name = "toolStripBibles";
			this.toolStripBibles.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.toolStripBibles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripBibles.ShowItemToolTips = false;
			this.toolStripBibles.Size = new System.Drawing.Size(513, 25);
			this.toolStripBibles.TabIndex = 0;
			this.toolStripBibles.Text = "toolStrip2";
			// 
			// tsBibles
			// 
			this.tsBibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsBibleQuote});
			this.tsBibles.Image = global::VerseFlow.Properties.Resources.book;
			this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBibles.Name = "tsBibles";
			this.tsBibles.Size = new System.Drawing.Size(67, 22);
			this.tsBibles.Text = "&Bibles";
			this.tsBibles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBibles_DropDownItemClicked);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
			// 
			// tsBibleQuote
			// 
			this.tsBibleQuote.Image = global::VerseFlow.Properties.Resources._1402077846_inbox_download;
			this.tsBibleQuote.Name = "tsBibleQuote";
			this.tsBibleQuote.Size = new System.Drawing.Size(133, 22);
			this.tsBibleQuote.Text = "BibleQuote";
			this.tsBibleQuote.Click += new System.EventHandler(this.miBibleQuote_Click);
			// 
			// tsAbout
			// 
			this.tsAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsAbout.Image = global::VerseFlow.Properties.Resources.information;
			this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Size = new System.Drawing.Size(23, 22);
			this.tsAbout.Text = "About";
			this.tsAbout.Visible = false;
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// tblBibles
			// 
			this.tblBibles.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tblBibles.ColumnCount = 1;
			this.tblBibles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 746F));
			this.tblBibles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblBibles.Location = new System.Drawing.Point(0, 25);
			this.tblBibles.Margin = new System.Windows.Forms.Padding(0);
			this.tblBibles.Name = "tblBibles";
			this.tblBibles.RowCount = 1;
			this.tblBibles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblBibles.Size = new System.Drawing.Size(513, 537);
			this.tblBibles.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tblDisplay);
			this.splitContainer1.Panel1.Controls.Add(this.toolStripMain);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tblBibles);
			this.splitContainer1.Panel2.Controls.Add(this.toolStripBibles);
			this.splitContainer1.Size = new System.Drawing.Size(910, 566);
			this.splitContainer1.SplitterDistance = 391;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 3;
			// 
			// tblDisplay
			// 
			this.tblDisplay.AutoSize = true;
			this.tblDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tblDisplay.ColumnCount = 1;
			this.tblDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Controls.Add(this.displayView, 0, 0);
			this.tblDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblDisplay.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tblDisplay.Location = new System.Drawing.Point(0, 25);
			this.tblDisplay.Margin = new System.Windows.Forms.Padding(0);
			this.tblDisplay.Name = "tblDisplay";
			this.tblDisplay.RowCount = 1;
			this.tblDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblDisplay.Size = new System.Drawing.Size(387, 537);
			this.tblDisplay.TabIndex = 4;
			// 
			// displayView
			// 
			this.displayView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.displayView.LiveDisplaySize = new System.Drawing.Size(4, 3);
			this.displayView.Location = new System.Drawing.Point(2, 2);
			this.displayView.Margin = new System.Windows.Forms.Padding(0);
			this.displayView.Name = "displayView";
			this.displayView.Size = new System.Drawing.Size(383, 533);
			this.displayView.TabIndex = 2;
			// 
			// toolStripMain
			// 
			this.toolStripMain.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDisplay,
            this.toolStripSeparator2,
            this.tsGoLive,
            this.tsPause,
            this.tsStop,
            this.toolStripSeparator1,
            this.toolStripButtonFillBlack});
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripMain.Size = new System.Drawing.Size(387, 25);
			this.toolStripMain.TabIndex = 7;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// tsDisplay
			// 
			this.tsDisplay.Image = global::VerseFlow.Properties.Resources.monitor;
			this.tsDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDisplay.Name = "tsDisplay";
			this.tsDisplay.Size = new System.Drawing.Size(90, 22);
			this.tsDisplay.Text = "<Display>";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsGoLive
			// 
			this.tsGoLive.CheckOnClick = true;
			this.tsGoLive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGoLive.Image = global::VerseFlow.Properties.Resources.control;
			this.tsGoLive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGoLive.Name = "tsGoLive";
			this.tsGoLive.Size = new System.Drawing.Size(23, 22);
			this.tsGoLive.Text = "Play";
			this.tsGoLive.Click += new System.EventHandler(this.tsGoLive_Click);
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
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(910, 566);
			this.Controls.Add(this.splitContainer1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.toolStripBibles.ResumeLayout(false);
			this.toolStripBibles.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tblDisplay.ResumeLayout(false);
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripBibles;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tblBibles;
		private DisplayView displayView;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tblDisplay;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripDropDownButton tsDisplay;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsGoLive;
		private System.Windows.Forms.ToolStripButton tsPause;
		private System.Windows.Forms.ToolStripButton tsStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonFillBlack;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsBibleQuote;

	}
}

