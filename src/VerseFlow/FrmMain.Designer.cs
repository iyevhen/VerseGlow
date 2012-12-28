using VerseFlow.Controls;

namespace VerseFlow
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
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.textBoxHighlight = new System.Windows.Forms.TextBox();
			this.buttonHightlihght = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.verseView1 = new VerseFlow.Controls.VerseView();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(709, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "from path:";
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(769, 78);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(138, 20);
			this.textBoxPath.TabIndex = 7;
			this.textBoxPath.Text = "e:\\biblerus.txt";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(936, 49);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(57, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(812, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Verses with max length = ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(749, 47);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(57, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "10000";
			// 
			// button2
			// 
			this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button2.Location = new System.Drawing.Point(628, 76);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Clear";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button1.Location = new System.Drawing.Point(628, 47);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Populate TextView";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 508);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1009, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// splitter1
			// 
			this.splitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.splitter1.Location = new System.Drawing.Point(538, 52);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 456);
			this.splitter1.TabIndex = 9;
			this.splitter1.TabStop = false;
			// 
			// textBoxHighlight
			// 
			this.textBoxHighlight.Location = new System.Drawing.Point(712, 131);
			this.textBoxHighlight.Name = "textBoxHighlight";
			this.textBoxHighlight.Size = new System.Drawing.Size(141, 20);
			this.textBoxHighlight.TabIndex = 10;
			// 
			// buttonHightlihght
			// 
			this.buttonHightlihght.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHightlihght.Location = new System.Drawing.Point(628, 131);
			this.buttonHightlihght.Name = "buttonHightlihght";
			this.buttonHightlihght.Size = new System.Drawing.Size(75, 23);
			this.buttonHightlihght.TabIndex = 11;
			this.buttonHightlihght.Text = "Highlight";
			this.buttonHightlihght.UseVisualStyleBackColor = true;
			this.buttonHightlihght.Click += new System.EventHandler(this.buttonHightlihght_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1009, 52);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(47, 49);
			this.toolStripDropDownButton1.Text = "Bibles";
			this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(52, 49);
			this.toolStripDropDownButton2.Text = "Psalms";
			this.toolStripDropDownButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(537, 1);
			this.verseView1.AutoScrollOffset = new System.Drawing.Point(500, 500);
			this.verseView1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.verseView1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(0, 52);
			this.verseView1.Name = "verseView1";
			this.verseView1.Size = new System.Drawing.Size(538, 456);
			this.verseView1.TabIndex = 1;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(50, 49);
			this.toolStripButton1.Text = "Settings";
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1009, 530);
			this.Controls.Add(this.buttonHightlihght);
			this.Controls.Add(this.textBoxHighlight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.verseView1);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VerseFlow";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private VerseView verseView1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox textBoxHighlight;
		private System.Windows.Forms.Button buttonHightlihght;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;

	}
}

