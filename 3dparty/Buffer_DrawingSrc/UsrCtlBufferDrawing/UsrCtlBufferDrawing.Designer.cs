namespace BufferDrawing
{
    partial class UsrCtlBufferDrawing
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
            this.SuspendLayout();
            // 
            // UsrCtlBufferDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Name = "UsrCtlBufferDrawing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsrCtlBufferDrawing_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UsrCtlBufferDrawing_Move);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UsrCtlBufferDrawing_MouseDown);
            this.Resize += new System.EventHandler(this.UsrCtlBufferDrawing_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UsrCtlBufferDrawing_MouseUp);
            this.HandleDestroyed += new System.EventHandler(this.UsrCtlBufferDrawingDestroy);

            this.ResumeLayout(false);

        }

        #endregion
    }
}
