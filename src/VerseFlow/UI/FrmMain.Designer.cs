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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsBibles = new System.Windows.Forms.ToolStripDropDownButton();
			this.miImport = new System.Windows.Forms.ToolStripMenuItem();
			this.miBibleQuote = new System.Windows.Forms.ToolStripMenuItem();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tsDisplay = new System.Windows.Forms.ToolStripButton();
			this.displayLiveView1 = new VerseFlow.UI.Controls.DisplayLiveView();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsAbout,
            this.tsDisplay});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.ShowItemToolTips = false;
			this.toolStrip2.Size = new System.Drawing.Size(913, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsBibles
			// 
			this.tsBibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImport});
			this.tsBibles.Image = global::VerseFlow.Properties.Resources.book_open;
			this.tsBibles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBibles.Name = "tsBibles";
			this.tsBibles.Size = new System.Drawing.Size(67, 22);
			this.tsBibles.Text = "&Bibles";
			this.tsBibles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBibles_DropDownItemClicked);
			// 
			// miImport
			// 
			this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBibleQuote});
			this.miImport.Name = "miImport";
			this.miImport.Size = new System.Drawing.Size(110, 22);
			this.miImport.Text = "Import";
			// 
			// miBibleQuote
			// 
			this.miBibleQuote.Name = "miBibleQuote";
			this.miBibleQuote.Size = new System.Drawing.Size(133, 22);
			this.miBibleQuote.Text = "BibleQuote";
			this.miBibleQuote.Click += new System.EventHandler(this.miBibleQuote_Click);
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
			this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
			// 
			// tableLayoutTop
			// 
			this.tableLayoutTop.ColumnCount = 1;
			this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 644F));
			this.tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutTop.Location = new System.Drawing.Point(335, 25);
			this.tableLayoutTop.Name = "tableLayoutTop";
			this.tableLayoutTop.RowCount = 1;
			this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutTop.Size = new System.Drawing.Size(578, 597);
			this.tableLayoutTop.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(332, 25);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 597);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// tsDisplay
			// 
			this.tsDisplay.Image = global::VerseFlow.Properties.Resources.monitor;
			this.tsDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDisplay.Name = "tsDisplay";
			this.tsDisplay.Size = new System.Drawing.Size(65, 22);
			this.tsDisplay.Text = "Display";
			// 
			// displayLiveView1
			// 
			this.displayLiveView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.displayLiveView1.Location = new System.Drawing.Point(0, 25);
			this.displayLiveView1.Margin = new System.Windows.Forms.Padding(2);
			this.displayLiveView1.Name = "displayLiveView1";
			this.displayLiveView1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.displayLiveView1.Size = new System.Drawing.Size(332, 597);
			this.displayLiveView1.TabIndex = 2;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(913, 622);
			this.Controls.Add(this.tableLayoutTop);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.displayLiveView1);
			this.Controls.Add(this.toolStrip2);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = global::VerseFlow.Properties.Settings.Default.ApplicationFont;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripDropDownButton tsBibles;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miBibleQuote;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tableLayoutTop;
		private DisplayLiveView displayLiveView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolStripButton tsDisplay;

	}
}

