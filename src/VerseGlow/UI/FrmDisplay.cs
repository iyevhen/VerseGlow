using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VerseGlow.UI
{
	public partial class FrmDisplay : Form, IDisplay
	{
		private string currentText;
		private readonly StringWrap wrap = new StringWrap();
		private bool fullScreen;
		private FormBorderStyle brdStyle;
		private FormWindowState winState;
		private bool topMost;
		private Rectangle bounds;
		private bool isPaused;
		private Point location;
		private bool isStoped;

		public bool IsStoped
		{
			get { return isStoped; }
		}

		public event EventHandler ActivationChanged;

		public FrmDisplay()
		{
			InitializeComponent();

			SetStyle(ControlStyles.UserPaint |
					 ControlStyles.AllPaintingInWmPaint |
					 ControlStyles.DoubleBuffer |
					 ControlStyles.ResizeRedraw, true);
		}

		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			var clientRect = ClientRectangle;

			if (BackgroundImage == null)
			{
				using (var brush = new SolidBrush(BackColor))
					e.Graphics.FillRectangle(brush, clientRect);
			}
			else
			{
				e.Graphics.DrawImage(BackgroundImage, clientRect);
			}

			if (!String.IsNullOrEmpty(currentText))
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				string wrapped = wrap.PerformWrap(currentText, 0.5f, 1);

				using (GraphicsPath path = wrap.GeneratePath(wrapped, clientRect))
				{
					var bounds = path.GetBounds();

					var x = (int)((clientRect.Width - bounds.Width) / 2);
					var y = (int)((clientRect.Height - bounds.Height) / 2);

					var r = new RectangleF(new PointF(x, y), bounds.Size);

					PointF[] target_pts =
					{
						new PointF(r.Left, r.Top),
						new PointF(r.Right, r.Top),
						new PointF(r.Left, r.Bottom)
					};

					e.Graphics.Transform = new Matrix(bounds, target_pts);

					e.Graphics.FillPath(Brushes.White, path);

					e.Graphics.ResetTransform();
				}
			}
		}

		private void OnActivationChanged()
		{
			EventHandler handler = ActivationChanged;

			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		public void DrawVerse(string content, string reference)
		{
			currentText = content;
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
					location = Location;

					WindowState = FormWindowState.Maximized;
					FormBorderStyle = FormBorderStyle.None;
					TopMost = true;
					WindowsAPI.SetFullScreen(this);
				}
				else
				{
					WindowState = winState;
					FormBorderStyle = brdStyle;
					TopMost = topMost;
					Bounds = bounds;
					Location = location;
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
			get { return isPaused; }
		}

		void IDisplay.Stop()
		{
			Hide();
			OnActivationChanged();
		}

		public void Pause()
		{
			isPaused = true;
		}

		void IDisplay.Play()
		{
			Show();
			OnActivationChanged();
		}

		private void FrmDisplay_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				((IDisplay)this).Stop();
			}
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

		private void FrmDisplay_Load(object sender, EventArgs e)
		{
		}

		private void FrmDisplay_MouseMove(object sender, MouseEventArgs e)
		{
		}
	}
}