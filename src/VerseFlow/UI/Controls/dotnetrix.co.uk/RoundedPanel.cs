using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace VerseFlow.UI.Controls.dotnetrix.co.uk
{
	/// <summary>
	/// Summary description for RoundedPanel.
	/// </summary>
//	[Designer(typeof(ParentControlDesigner))]
	public class RoundedPanel : Control
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components;

		public RoundedPanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		private int borderRadius = 32;

		public int BorderRadius
		{
			get { return borderRadius; }
			set
			{
				borderRadius = value;
				this.Invalidate();
			}
		}

		protected override Size DefaultSize
		{
			get { return new Size(200, 100); }
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			this.Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//Draw the Parent onto our Control to give pseudo transparency.
			//The BeginContainer and EndContainer calls stop incorrect painting of 
			//child controls when both container and child have BackColor set to Transparent.
			//This only happens as a result of the TranslateTransform() call.
			System.Drawing.Drawing2D.GraphicsContainer g = pevent.Graphics.BeginContainer();
			Rectangle translateRect = this.Bounds;
			pevent.Graphics.TranslateTransform(-this.Left, -this.Top);
			PaintEventArgs pe = new PaintEventArgs(pevent.Graphics, translateRect);
			this.InvokePaintBackground(this.Parent, pe);
			this.InvokePaint(this.Parent, pe);
			pevent.Graphics.ResetTransform();
			pevent.Graphics.EndContainer(g);

			//Define the custom Border Region, Brush and Pen.
			System.Drawing.Drawing2D.GraphicsPath border;
			Brush paintBrush = new SolidBrush(this.BackColor);
			Pen borderPen = new Pen(this.ForeColor);
			Rectangle r = this.ClientRectangle;

			//Set the Region of the Control
			this.Region = new Region(RoundRegion(r));

			r.Inflate(-1, -1);
			border = RoundRegion(r);

			//Fill The Region with the Controls BackColor
			pevent.Graphics.FillPath(paintBrush, border);

			//Paint any BackgroundImage that might have been set
			if (this.BackgroundImage != null)
			{
				Brush br = new TextureBrush(this.BackgroundImage);
				pevent.Graphics.FillPath(br, border);
				br.Dispose();
			}

			//Draw the Region
			pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			pevent.Graphics.DrawPath(borderPen, border);

			//Clean Up
			borderPen.Dispose();
			paintBrush.Dispose();
			border.Dispose();

		}

		private System.Drawing.Drawing2D.GraphicsPath RoundRegion(Rectangle r)
		{
			//Scale the radius if it's too large to fit.
			int radius = borderRadius;
			if (radius > (r.Width))
				radius = r.Width;
			if (radius > (r.Height))
				radius = r.Height;

			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

			if (radius <= 0)
			{
				path.AddRectangle(r);
			}
			else
			{
				path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
				path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
				path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
				path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
				path.CloseFigure();
			}

			return path;
		}

	}

}
