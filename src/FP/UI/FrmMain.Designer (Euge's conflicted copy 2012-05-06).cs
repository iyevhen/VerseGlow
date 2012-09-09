using System.Drawing;
using System.Windows.Forms;
using www.obolonchurch.org.freepresenter.ui.Controls;

namespace www.obolonchurch.org.freepresenter.ui
{
	partial class FrmMain
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.toolStripShow = new System.Windows.Forms.ToolStrip();
			this.seppo = new System.Windows.Forms.ToolStripSeparator();
			this.body = new System.Windows.Forms.SplitContainer();
			this.html = new System.Windows.Forms.HtmlPanel();
			this.toolStripNavigate = new System.Windows.Forms.ToolStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnOpen = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.btnPlay = new System.Windows.Forms.ToolStripButton();
			this.btnPause = new System.Windows.Forms.ToolStripButton();
			this.btnStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.lblAbout = new System.Windows.Forms.ToolStripStatusLabel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolStripShow.SuspendLayout();
			this.body.Panel1.SuspendLayout();
			this.body.Panel2.SuspendLayout();
			this.body.SuspendLayout();
			this.toolStripNavigate.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripShow
			// 
			this.toolStripShow.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripShow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlay,
            this.btnPause,
            this.btnStop,
            this.seppo,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
			resources.ApplyResources(this.toolStripShow, "toolStripShow");
			this.toolStripShow.Name = "toolStripShow";
			// 
			// seppo
			// 
			this.seppo.Name = "seppo";
			resources.ApplyResources(this.seppo, "seppo");
			// 
			// body
			// 
			resources.ApplyResources(this.body, "body");
			this.body.Name = "body";
			// 
			// body.Panel1
			// 
			this.body.Panel1.Controls.Add(this.tabControl1);
			// 
			// body.Panel2
			// 
			this.body.Panel2.Controls.Add(this.toolStripShow);
			// 
			// html
			// 
			resources.ApplyResources(this.html, "html");
			this.html.BackColor = System.Drawing.SystemColors.Window;
			this.html.Name = "html";
			// 
			// toolStripNavigate
			// 
			this.toolStripNavigate.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripNavigate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSearch,
            this.toolStripButton4,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButton5});
			resources.ApplyResources(this.toolStripNavigate, "toolStripNavigate");
			this.toolStripNavigate.Name = "toolStripNavigate";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAbout});
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.html);
			this.tabPage1.Controls.Add(this.toolStripNavigate);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnOpen
			// 
			resources.ApplyResources(this.btnOpen, "btnOpen");
			this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBtnOpen_DropDownItemClicked);
			// 
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.btnSearch, "btnSearch");
			this.btnSearch.Name = "btnSearch";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
			this.toolStripButton4.Name = "toolStripButton4";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			// 
			// toolStripMenuItem2
			// 
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			// 
			// toolStripDropDownButton2
			// 
			resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
			this.toolStripButton5.Name = "toolStripButton5";
			// 
			// btnPlay
			// 
			this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.btnPlay, "btnPlay");
			this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// btnPause
			// 
			this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.btnPause, "btnPause");
			this.btnPause.Margin = new System.Windows.Forms.Padding(2);
			this.btnPause.Name = "btnPause";
			this.btnPause.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// btnStop
			// 
			this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.btnStop, "btnStop");
			this.btnStop.Margin = new System.Windows.Forms.Padding(2);
			this.btnStop.Name = "btnStop";
			this.btnStop.Padding = new System.Windows.Forms.Padding(1);
			this.btnStop.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
			this.toolStripButton1.Name = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
			this.toolStripButton2.Name = "toolStripButton2";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
			this.toolStripButton3.Name = "toolStripButton3";
			// 
			// lblAbout
			// 
			this.lblAbout.ActiveLinkColor = System.Drawing.Color.DimGray;
			this.lblAbout.Image = global::www.obolonchurch.org.freepresenter.Properties.Resources.question;
			this.lblAbout.IsLink = true;
			this.lblAbout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblAbout.LinkColor = System.Drawing.Color.DimGray;
			this.lblAbout.Name = "lblAbout";
			resources.ApplyResources(this.lblAbout, "lblAbout");
			this.lblAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "bible");
			this.imageList1.Images.SetKeyName(1, "songs");
			this.imageList1.Images.SetKeyName(2, "new");
			// 
			// FrmMain
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.body);
			this.Controls.Add(this.statusStrip1);
			this.Name = "FrmMain";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.toolStripShow.ResumeLayout(false);
			this.toolStripShow.PerformLayout();
			this.body.Panel1.ResumeLayout(false);
			this.body.Panel2.ResumeLayout(false);
			this.body.Panel2.PerformLayout();
			this.body.ResumeLayout(false);
			this.toolStripNavigate.ResumeLayout(false);
			this.toolStripNavigate.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripShow;
		private ToolStripButton btnPlay;
		private ToolStripButton btnPause;
		private ToolStripButton btnStop;
		private ToolStripSeparator seppo;
		private SplitContainer body;
		private HtmlPanel html;
		private ToolStrip toolStripNavigate;
		private ToolStripDropDownButton btnOpen;
		private ToolStripButton btnSearch;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton3;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel lblAbout;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private ToolStripButton toolStripButton4;
		private ToolStripDropDownButton toolStripDropDownButton1;
		private ToolStripMenuItem toolStripMenuItem2;
		private ToolStripMenuItem toolStripMenuItem3;
		private ToolStripDropDownButton toolStripDropDownButton2;
		private TabPage tabPage3;
		private ToolStripButton toolStripButton5;
		private ImageList imageList1;

	}
}
