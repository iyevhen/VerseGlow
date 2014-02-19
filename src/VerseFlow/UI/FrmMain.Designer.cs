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
			this.tsSongs = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsSettings = new System.Windows.Forms.ToolStripButton();
			this.tsAbout = new System.Windows.Forms.ToolStripButton();
			this.tsPreviews = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.tsLive = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBibles,
            this.tsSongs,
            this.tsSettings,
            this.tsAbout,
            this.tsPreviews});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.ShowItemToolTips = false;
			this.toolStrip2.Size = new System.Drawing.Size(552, 25);
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
			// tsSongs
			// 
			this.tsSongs.Image = global::VerseFlow.Properties.Resources.music_beam;
			this.tsSongs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSongs.Name = "tsSongs";
			this.tsSongs.Size = new System.Drawing.Size(68, 22);
			this.tsSongs.Text = "&Songs";
			this.tsSongs.Visible = false;
			// 
			// tsSettings
			// 
			this.tsSettings.Image = global::VerseFlow.Properties.Resources.wrench_screwdriver;
			this.tsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSettings.Name = "tsSettings";
			this.tsSettings.Size = new System.Drawing.Size(69, 22);
			this.tsSettings.Text = "S&ettings";
			this.tsSettings.Visible = false;
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
			// tsPreviews
			// 
			this.tsPreviews.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPreview,
            this.tsLive});
			this.tsPreviews.Image = global::VerseFlow.Properties.Resources.monitor;
			this.tsPreviews.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsPreviews.Name = "tsPreviews";
			this.tsPreviews.Size = new System.Drawing.Size(61, 22);
			this.tsPreviews.Text = "View";
			// 
			// tsPreview
			// 
			this.tsPreview.Name = "tsPreview";
			this.tsPreview.Size = new System.Drawing.Size(152, 22);
			this.tsPreview.Text = "Preview";
			this.tsPreview.Click += new System.EventHandler(this.tsPreview_Click);
			// 
			// tsLive
			// 
			this.tsLive.Name = "tsLive";
			this.tsLive.Size = new System.Drawing.Size(152, 22);
			this.tsLive.Text = "Live";
			this.tsLive.Click += new System.EventHandler(this.tsLive_Click);
			// 
			// tableLayoutTop
			// 
			this.tableLayoutTop.ColumnCount = 1;
			this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 552F));
			this.tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutTop.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutTop.Name = "tableLayoutTop";
			this.tableLayoutTop.RowCount = 1;
			this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutTop.Size = new System.Drawing.Size(552, 335);
			this.tableLayoutTop.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 360);
			this.Controls.Add(this.tableLayoutTop);
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
		private System.Windows.Forms.ToolStripDropDownButton tsSongs;
		private System.Windows.Forms.ToolStripButton tsSettings;
		private System.Windows.Forms.ToolStripMenuItem miImport;
		private System.Windows.Forms.ToolStripMenuItem miBibleQuote;
		private System.Windows.Forms.ToolStripButton tsAbout;
		private System.Windows.Forms.TableLayoutPanel tableLayoutTop;
		private System.Windows.Forms.ToolStripDropDownButton tsPreviews;
		private System.Windows.Forms.ToolStripMenuItem tsPreview;
		private System.Windows.Forms.ToolStripMenuItem tsLive;

	}
}

