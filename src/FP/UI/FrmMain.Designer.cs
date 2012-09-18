using System.Drawing;
using System.Windows.Forms;
using FreePresenter.UI.Controls;

namespace FreePresenter.UI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.body = new System.Windows.Forms.SplitContainer();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.btnOpen = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.display1 = new FreePresenter.UI.Controls.Display();
			this.display2 = new FreePresenter.UI.Controls.Display();
			this.body.Panel1.SuspendLayout();
			this.body.Panel2.SuspendLayout();
			this.body.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// body
			// 
			resources.ApplyResources(this.body, "body");
			this.body.Name = "body";
			// 
			// body.Panel1
			// 
			this.body.Panel1.Controls.Add(this.toolStripMain);
			// 
			// body.Panel2
			// 
			this.body.Panel2.Controls.Add(this.display2);
			this.body.Panel2.Controls.Add(this.display1);
			this.body.Panel2.Controls.Add(this.toolStrip1);
			// 
			// toolStripMain
			// 
			resources.ApplyResources(this.toolStripMain, "toolStripMain");
			this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen});
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// btnOpen
			// 
			this.btnOpen.Image = global::FreePresenter.Properties.Resources.book16;
			resources.ApplyResources(this.btnOpen, "btnOpen");
			this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpen.Name = "btnOpen";
			// 
			// toolStrip1
			// 
			resources.ApplyResources(this.toolStrip1, "toolStrip1");
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
			this.toolStripButton1.Name = "toolStripButton1";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
			this.toolStripButton3.Margin = new System.Windows.Forms.Padding(2);
			this.toolStripButton3.Name = "toolStripButton3";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
			this.toolStripButton4.Margin = new System.Windows.Forms.Padding(2);
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Padding = new System.Windows.Forms.Padding(1);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
			this.toolStripButton5.Margin = new System.Windows.Forms.Padding(2);
			this.toolStripButton5.Name = "toolStripButton5";
			// 
			// display1
			// 
			this.display1.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.display1, "display1");
			this.display1.Name = "display1";
			// 
			// display2
			// 
			this.display2.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.display2, "display2");
			this.display2.Name = "display2";
			// 
			// FrmMain
			// 
			this.AllowDrop = true;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.body);
			this.Name = "FrmMain";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.body.Panel1.ResumeLayout(false);
			this.body.Panel2.ResumeLayout(false);
			this.body.ResumeLayout(false);
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private SplitContainer body;
		private ToolStrip toolStripMain;
		private ToolStripDropDownButton btnOpen;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton3;
		private ToolStripButton toolStripButton4;
		private ToolStripButton toolStripButton5;
		private Display display2;
		private Display display1;

	}
}
