namespace TestBufferDrawing
{
    partial class FrmTest
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
            this.TmrBackground = new System.Windows.Forms.Timer(this.components);
            this.TmrRectangles = new System.Windows.Forms.Timer(this.components);
            this.TmrCircles = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LblTimePaint = new System.Windows.Forms.Label();
            this.usrcontrol = new BufferDrawing.UsrCtlBufferDrawing();
            this.ChkMultipleLayers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TmrBackground
            // 
            this.TmrBackground.Interval = 15000;
            this.TmrBackground.Tick += new System.EventHandler(this.TmrBackground_Tick);
            // 
            // TmrRectangles
            // 
            this.TmrRectangles.Interval = 5000;
            this.TmrRectangles.Tick += new System.EventHandler(this.TmrRectangles_Tick);
            // 
            // TmrCircles
            // 
            this.TmrCircles.Interval = 1500;
            this.TmrCircles.Tick += new System.EventHandler(this.TmrCircles_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time / Paint iterations:";
            // 
            // LblTimePaint
            // 
            this.LblTimePaint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTimePaint.Location = new System.Drawing.Point(131, 16);
            this.LblTimePaint.Name = "LblTimePaint";
            this.LblTimePaint.Size = new System.Drawing.Size(142, 21);
            this.LblTimePaint.TabIndex = 2;
            this.LblTimePaint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrcontrol
            // 
            this.usrcontrol.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.usrcontrol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrcontrol.ColorBackGround = System.Drawing.Color.Black;
            this.usrcontrol.ColorRectangle = System.Drawing.Color.Green;
            this.usrcontrol.dotwidth = 3;
            this.usrcontrol.Location = new System.Drawing.Point(12, 48);
            this.usrcontrol.Name = "usrcontrol";
            this.usrcontrol.Size = new System.Drawing.Size(485, 294);
            this.usrcontrol.TabIndex = 0;
            // 
            // ChkMultipleLayers
            // 
            this.ChkMultipleLayers.AutoSize = true;
            this.ChkMultipleLayers.Location = new System.Drawing.Point(280, 18);
            this.ChkMultipleLayers.Name = "ChkMultipleLayers";
            this.ChkMultipleLayers.Size = new System.Drawing.Size(96, 17);
            this.ChkMultipleLayers.TabIndex = 3;
            this.ChkMultipleLayers.Text = "Multiple Layers";
            this.ChkMultipleLayers.UseVisualStyleBackColor = true;
            this.ChkMultipleLayers.CheckedChanged += new System.EventHandler(this.ChkMultipleLayers_CheckedChanged);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 372);
            this.Controls.Add(this.ChkMultipleLayers);
            this.Controls.Add(this.LblTimePaint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usrcontrol);
            this.Name = "FrmTest";
            this.Text = "Drawing Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.Resize += new System.EventHandler(this.FrmTest_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferDrawing.UsrCtlBufferDrawing usrcontrol;
        private System.Windows.Forms.Timer TmrBackground;
        private System.Windows.Forms.Timer TmrRectangles;
        private System.Windows.Forms.Timer TmrCircles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTimePaint;
        private System.Windows.Forms.CheckBox ChkMultipleLayers;
    }
}

