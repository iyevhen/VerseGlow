namespace VerseFlow.UI
{
	partial class FrmBibleViewColors
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.verseView1 = new VerseFlow.UI.Controls.VerseView();
			this.colorButton2 = new VerseFlow.UI.Controls.ColorButton();
			this.colorButton1 = new VerseFlow.UI.Controls.ColorButton();
			this.colorButton3 = new VerseFlow.UI.Controls.ColorButton();
			this.colorButton4 = new VerseFlow.UI.Controls.ColorButton();
			this.colorButton5 = new VerseFlow.UI.Controls.ColorButton();
			this.colorButton6 = new VerseFlow.UI.Controls.ColorButton();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.verseView1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
			this.groupBox1.Size = new System.Drawing.Size(244, 201);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Preview";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.colorButton2);
			this.flowLayoutPanel1.Controls.Add(this.colorButton1);
			this.flowLayoutPanel1.Controls.Add(this.colorButton3);
			this.flowLayoutPanel1.Controls.Add(this.colorButton4);
			this.flowLayoutPanel1.Controls.Add(this.colorButton5);
			this.flowLayoutPanel1.Controls.Add(this.colorButton6);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(244, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 8, 8);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 201);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 201);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(401, 36);
			this.panel1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(314, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(236, 6);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// verseView1
			// 
			this.verseView1.AutoScroll = true;
			this.verseView1.AutoScrollMinSize = new System.Drawing.Size(228, 0);
			this.verseView1.BackColor = global::VerseFlow.Properties.Settings.Default.BibleBackColor;
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::VerseFlow.Properties.Settings.Default, "BibleFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::VerseFlow.Properties.Settings.Default, "BibleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::VerseFlow.Properties.Settings.Default, "BibleForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.verseView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.verseView1.DrawSeparatorLine = false;
			this.verseView1.Font = global::VerseFlow.Properties.Settings.Default.BibleFont;
			this.verseView1.ForeColor = global::VerseFlow.Properties.Settings.Default.BibleForeColor;
			this.verseView1.HighlightText = null;
			this.verseView1.Location = new System.Drawing.Point(8, 21);
			this.verseView1.Name = "verseView1";
			this.verseView1.ReadOnly = false;
			this.verseView1.Size = new System.Drawing.Size(228, 172);
			this.verseView1.TabIndex = 0;
			this.verseView1.Text = "verseViewSample";
			// 
			// colorButton2
			// 
			this.colorButton2.Automatic = "Automatic";
			this.colorButton2.Color = System.Drawing.Color.Transparent;
			this.colorButton2.HintText = "BackColor";
			this.colorButton2.Location = new System.Drawing.Point(3, 11);
			this.colorButton2.MoreColors = "More Colors...";
			this.colorButton2.Name = "colorButton2";
			this.colorButton2.Size = new System.Drawing.Size(143, 23);
			this.colorButton2.TabIndex = 0;
			this.colorButton2.UseVisualStyleBackColor = true;
			this.colorButton2.SelectedColorChanged += new System.EventHandler(this.colorButton2_SelectedColorChanged);
			// 
			// colorButton1
			// 
			this.colorButton1.Automatic = "Automatic";
			this.colorButton1.Color = System.Drawing.Color.Transparent;
			this.colorButton1.HintText = "ForeColor";
			this.colorButton1.Location = new System.Drawing.Point(3, 40);
			this.colorButton1.MoreColors = "More Colors...";
			this.colorButton1.Name = "colorButton1";
			this.colorButton1.Size = new System.Drawing.Size(143, 23);
			this.colorButton1.TabIndex = 0;
			this.colorButton1.UseVisualStyleBackColor = true;
			// 
			// colorButton3
			// 
			this.colorButton3.Automatic = "Automatic";
			this.colorButton3.Color = System.Drawing.Color.Transparent;
			this.colorButton3.HintText = "Highlight BackColor";
			this.colorButton3.Location = new System.Drawing.Point(3, 69);
			this.colorButton3.MoreColors = "More Colors...";
			this.colorButton3.Name = "colorButton3";
			this.colorButton3.Size = new System.Drawing.Size(143, 23);
			this.colorButton3.TabIndex = 0;
			this.colorButton3.UseVisualStyleBackColor = true;
			// 
			// colorButton4
			// 
			this.colorButton4.Automatic = "Automatic";
			this.colorButton4.Color = System.Drawing.Color.Transparent;
			this.colorButton4.HintText = "Highlight ForeColor";
			this.colorButton4.Location = new System.Drawing.Point(3, 98);
			this.colorButton4.MoreColors = "More Colors...";
			this.colorButton4.Name = "colorButton4";
			this.colorButton4.Size = new System.Drawing.Size(143, 23);
			this.colorButton4.TabIndex = 1;
			this.colorButton4.UseVisualStyleBackColor = true;
			// 
			// colorButton5
			// 
			this.colorButton5.Automatic = "Automatic";
			this.colorButton5.Color = System.Drawing.Color.Transparent;
			this.colorButton5.HintText = "Selection BackColor";
			this.colorButton5.Location = new System.Drawing.Point(3, 127);
			this.colorButton5.MoreColors = "More Colors...";
			this.colorButton5.Name = "colorButton5";
			this.colorButton5.Size = new System.Drawing.Size(143, 23);
			this.colorButton5.TabIndex = 2;
			this.colorButton5.UseVisualStyleBackColor = true;
			// 
			// colorButton6
			// 
			this.colorButton6.Automatic = "Automatic";
			this.colorButton6.Color = System.Drawing.Color.Transparent;
			this.colorButton6.HintText = "Selection ForeColor";
			this.colorButton6.Location = new System.Drawing.Point(3, 156);
			this.colorButton6.MoreColors = "More Colors...";
			this.colorButton6.Name = "colorButton6";
			this.colorButton6.Size = new System.Drawing.Size(143, 23);
			this.colorButton6.TabIndex = 3;
			this.colorButton6.UseVisualStyleBackColor = true;
			// 
			// FrmBibleViewColors
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(401, 237);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmBibleViewColors";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bible View Colors";
			this.Load += new System.EventHandler(this.FrmBibleViewColors_Load);
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private Controls.ColorButton colorButton1;
		private Controls.VerseView verseView1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private Controls.ColorButton colorButton2;
		private Controls.ColorButton colorButton3;
		private Controls.ColorButton colorButton4;
		private Controls.ColorButton colorButton5;
		private Controls.ColorButton colorButton6;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}