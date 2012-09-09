using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FreePresenter.Render;
using FreePresenter.UI;

namespace FreePresenter.UI
{
	public partial class FrmDisplay : Form, IDisplay
	{
		private string currentText;
		private StringWrap wrap = new StringWrap();
		private Image image;
		private Color backgroundColor = Color.Black;
		private bool fullScreen;
		private FormBorderStyle brdStyle;
		private FormWindowState winState;
		private bool topMost;
		private Rectangle bounds;

		public bool IsStoped
		{
			get { throw new NotImplementedException(); }
		}

		public event EventHandler ActivationChanged;

		public FrmDisplay()
		{
			InitializeComponent();

			SetStyle(ControlStyles.UserPaint |
					 ControlStyles.AllPaintingInWmPaint |
					 ControlStyles.DoubleBuffer |
					 ControlStyles.ResizeRedraw, true);

			currentText = "Free Presenter";
		}

		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		protected override void OnPaintBackground(PaintEventArgs e) { }

		protected override void OnPaint(PaintEventArgs e)
		{
			var cr = ClientRectangle;

			if (image == null)
			{
				using (var brush = new SolidBrush(backgroundColor))
					e.Graphics.FillRectangle(brush, cr);
			}
			else
			{
				e.Graphics.DrawImage(image, cr);
			}

			if (!String.IsNullOrEmpty(currentText))
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				string s = wrap.PerformWrap(currentText, 0.5f, 1);

				using (GraphicsPath path = wrap.GeneratePath(s, cr))
				{
					var bounds = path.GetBounds();

					var x = (int)((cr.Width - bounds.Width) / 2);
					var y = (int)((cr.Height - bounds.Height) / 2);

					var r = new RectangleF(new PointF(x, y), bounds.Size);

					PointF[] target_pts = new[]
					                      	{
					                      		new PointF(r.Left, r.Top),
					                      		new PointF(r.Right, r.Top),
					                      		new PointF(r.Left, r.Bottom)
					                      	};

					e.Graphics.Transform = new Matrix(bounds, target_pts);

					using (var brush = new SolidBrush(Color.White))
					{
						e.Graphics.FillPath(brush, path);
						e.Graphics.DrawPath(Pens.Black, path);
					}

					e.Graphics.ResetTransform();
				}
			}
		}

		void OnActivationChanged()
		{
			EventHandler handler = ActivationChanged;

			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		void IDisplay.DrawText(string text)
		{
			currentText = text;
			Refresh();
		}

		void IDisplay.DrawBackground(Image image)
		{
			if (this.image != null)
				this.image.Dispose();

			this.image = image;
			Refresh();
		}

		void IDisplay.DrawBackground(Color color)
		{
			backgroundColor = color;
			Refresh();
		}

		public bool FullScreen
		{
			get { return fullScreen; }
			set
			{
				if (value == fullScreen)
					return;

				fullScreen = value;

				if (fullScreen)
				{
					winState = WindowState;
					brdStyle = FormBorderStyle;
					topMost = TopMost;
					bounds = Bounds;

					WindowState = FormWindowState.Maximized;
					FormBorderStyle = FormBorderStyle.None;
					TopMost = true;
					NativeInterop.SetWinFullScreen(Handle);
				}
				else
				{
					WindowState = winState;
					FormBorderStyle = brdStyle;
					TopMost = topMost;
					Bounds = bounds;
				}
			}
		}

		public bool IsActive
		{
			get { return Visible; }
		}

		public bool IsPlaying
		{
			get { return IsActive; }
		}

		public bool IsPaused
		{
			get { throw new NotImplementedException(); }
		}

		void IDisplay.Deactivate()
		{
			Hide();
			OnActivationChanged();
		}

		void IDisplay.Activate()
		{
			Show();
			OnActivationChanged();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			if (image != null)
				image.Dispose();

			base.Dispose(disposing);
		}

		private void FrmDisplay_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.UserClosing)
				return;

			e.Cancel = true;

			Hide();
			OnActivationChanged();
		}

		private void FrmDisplay_DoubleClick(object sender, EventArgs e)
		{
			FullScreen = !FullScreen;
		}

		private void FrmDisplay_MouseDown(object sender, MouseEventArgs e)
		{
			//			if (MouseButtons == MouseButtons.Left)
			//			{
			//				NativeInterop.HandlerMouseDown(Handle);
			//			}
		}
	}
}
