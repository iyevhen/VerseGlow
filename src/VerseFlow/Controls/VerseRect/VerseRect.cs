using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace VerseFlow.Controls.VerseRect
{
	public enum ButtonStatus
	{
		Normal = 1,
		Hot,
		Pressed,
		Disabled,
		Focused
	}

	public class VerseRect : Control, IButtonControl, IHaveRoundCorners
	{
		private const string categoryAppearance = "Appearance";
		private const string categoryBehavior = "Behavior";

		private readonly Blend blend = new Blend
			{
//				Positions = new[] { .1f, .2f, .4f, .8f, .8f, .4f, .2f , .1f},
//				Factors = new[] { .0f, .1f, .2f, .4f, .6f, .8f, .9f, 1.0f }
				Positions = new[] { 0, 0.45F, 0.55F, 1 },
				Factors = new float[] { 0, 1, 1, 0 }

			};

		private Rectangle contentRect;
		private int cornerRadius = 8;
		private ButtonStatus currentStatus;
		private DialogResult dialogResult;
		private ContentAlignment imageAlign = ContentAlignment.MiddleCenter;
		private int imageIndex = -1;
		private int imageIndexHot = -1;
		private ImageList imageList;
		private bool isDefault;
		private bool keyPressed;

		private Corners roundCorners;
		private ButtonStatus status = ButtonStatus.Normal;

		private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
		private Color textShadowColor = Color.Transparent;

		public VerseRect()
		{
			SetStyle(
				ControlStyles.Selectable
				| ControlStyles.StandardClick
				| ControlStyles.ResizeRedraw
				| ControlStyles.AllPaintingInWmPaint
				| ControlStyles.DoubleBuffer
				| ControlStyles.UserPaint
				| ControlStyles.SupportsTransparentBackColor, true);
		}

		#region IButtonControl Implementation

		[Category(categoryBehavior), DefaultValue(typeof(DialogResult), "None")]
		[Description("The dialog result produced in a modal form by clicking the button.")]
		public DialogResult DialogResult
		{
			get { return dialogResult; }
			set
			{
				if (Enum.IsDefined(typeof(DialogResult), value))
					dialogResult = value;
			}
		}

		public void NotifyDefault(bool value)
		{
			if (isDefault != value)
				isDefault = value;

			Invalidate();
		}

		public void PerformClick()
		{
			if (CanSelect)
				base.OnClick(EventArgs.Empty);
		}

		#endregion

		#region Properties

		[Browsable(false)]
		public ButtonStatus Status
		{
			get { return status; }
		}

		protected override Size DefaultSize
		{
			get { return new Size(75, 23); }
		}

		[Browsable(false)]
		public bool IsDefault
		{
			get { return isDefault; }
		}

		[Category(categoryAppearance), DefaultValue(typeof(ImageList), null)]
		[Description("The image list to get the image to display in the face of the control.")]
		public ImageList ImageList
		{
			get { return imageList; }
			set
			{
				imageList = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance), DefaultValue(-1)]
		[Description("The index of the image in the image list to display in the face of the control.")]
		[TypeConverter(typeof(ImageIndexConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
		public int ImageIndex
		{
			get { return imageIndex; }
			set
			{
				imageIndex = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance), DefaultValue(-1)]
		[Description("The index of the image in the image list to display in the face of the control when it's active.")]
		[TypeConverter(typeof(ImageIndexConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
		public int ImageIndexHot
		{
			get { return imageIndexHot; }
			set
			{
				imageIndexHot = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
		[Description("The alignment of the image that will be displayed in the face of the control.")]
		public ContentAlignment ImageAlign
		{
			get { return imageAlign; }
			set
			{
				if (!Enum.IsDefined(typeof(ContentAlignment), value))
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));

				if (imageAlign == value)
					return;

				imageAlign = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
		[Description("The alignment of the text that will be displayed in the face of the button.")]
		public ContentAlignment TextAlign
		{
			get { return textAlign; }
			set
			{
				if (!Enum.IsDefined(typeof(ContentAlignment), value))
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));

				if (textAlign == value)
					return;

				textAlign = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance), DefaultValue(typeof(Color), "Transparent")]
		[Description("Use shadow for text on button.")]
		public Color TextShadowColor
		{
			get { return textShadowColor; }
			set
			{
				if (textShadowColor == value)
					return;

				textShadowColor = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance)]
		[DefaultValue(8)]
		[Description("Defines the radius of the controls RoundedCorners.")]
		public int CornerRadius
		{
			get { return cornerRadius; }
			set
			{
				if (cornerRadius == value)
					return;
				cornerRadius = value;
				Invalidate();
			}
		}

		[Category(categoryAppearance)]
		[DefaultValue(typeof(Corners), "None")]
		[Description("Gets/sets the corners of the control to round.")]
		[Editor(typeof(RoundCornersEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Corners RoundCorners
		{
			get { return roundCorners; }
			set
			{
				if (roundCorners == value)
					return;

				roundCorners = value;
				Invalidate();
			}
		}

		#endregion

		#region Overriden Methods

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == Keys.Space)
			{
				keyPressed = true;
				status = ButtonStatus.Pressed;
			}

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			if (e.KeyCode == Keys.Space)
			{
				if (Status == ButtonStatus.Pressed)
					PerformClick();

				keyPressed = false;
				status = ButtonStatus.Focused;
			}

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);

			if (!keyPressed)
				status = ButtonStatus.Hot;

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			if (!keyPressed)
			{
				status = IsDefault ? ButtonStatus.Focused : ButtonStatus.Normal;
			}

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button == MouseButtons.Left)
			{
				Focus();
				status = ButtonStatus.Pressed;
			}

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			status = ButtonStatus.Focused;
			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (new Rectangle(Point.Empty, Size).Contains(e.X, e.Y)
				&& e.Button == MouseButtons.Left)
			{
				status = ButtonStatus.Pressed;
			}
			else
			{
				if (keyPressed)
					return;

				status = ButtonStatus.Hot;
			}

			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			status = ButtonStatus.Focused;
			NotifyDefault(true);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);

			Form findForm = FindForm();

			if (findForm != null && findForm.Focused)
				NotifyDefault(false);

			status = ButtonStatus.Normal;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			status = Enabled ? ButtonStatus.Normal : ButtonStatus.Disabled;
			OnStatusChange(EventArgs.Empty);
		}

		protected override void OnClick(EventArgs e)
		{
			//Click gets fired before MouseUp which is handy
			if (Status == ButtonStatus.Pressed)
			{
				Focus();
				PerformClick();
				SetDialogResult();
			}
		}

		private void SetDialogResult()
		{
			Form findForm = FindForm();

			if (findForm != null && dialogResult != DialogResult.None)
				findForm.DialogResult = dialogResult;
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			if (Status == ButtonStatus.Pressed)
			{
				Focus();
				PerformClick();
			}
		}

		protected override bool ProcessMnemonic(char charCode)
		{
			if (IsMnemonic(charCode, Text))
			{
				base.OnClick(EventArgs.Empty);
				return true;
			}

			return base.ProcessMnemonic(charCode);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//Simulate Transparency
			GraphicsContainer g = pevent.Graphics.BeginContainer();
			Rectangle translateRect = Bounds;
			pevent.Graphics.TranslateTransform(-Left, -Top);
			var pe = new PaintEventArgs(pevent.Graphics, translateRect);
			InvokePaintBackground(Parent, pe);
			InvokePaint(Parent, pe);
			pevent.Graphics.ResetTransform();
			pevent.Graphics.EndContainer(g);

			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			Color shadeColor, fillColor;
			//			Color darkColor = DarkenColor(BackColor, 5);
			Color darkDarkColor = DarkenColor(BackColor, 10);
			Color lightColor = LightenColor(BackColor, 10);
			//			Color lightLightColor = LightenColor(BackColor, 60);

			if (Status == ButtonStatus.Hot)
			{
				fillColor = lightColor;
				shadeColor = darkDarkColor;
			}
			else if (Status == ButtonStatus.Pressed)
			{
				fillColor = BackColor;
				shadeColor = BackColor;
			}
			else
			{
				fillColor = BackColor;
				shadeColor = darkDarkColor;
//								shadeColor = lightColor;
			}

			Rectangle r = ClientRectangle;

			using (GraphicsPath path = RoundRectangle(r, CornerRadius, RoundCorners))
			{
				using (var paintBrush = new LinearGradientBrush(r, fillColor, shadeColor, LinearGradientMode.Vertical))
				{
					//We want a sharp change in the colors so define a Blend for the brush
//					paintBrush.Blend = blend;

					//Draw the Button Background
					pevent.Graphics.FillPath(paintBrush, path);
				}

				//...and border
//				using (var drawingPen = new Pen(darkDarkColor))
//					pevent.Graphics.DrawPath(drawingPen, path);


				//Get the Rectangle to be used for Content
				bool inBounds = false;
				//We could use some Math to get this from the radius but I'm 
				//not great at Math so for the example this hack will suffice.
				while (!inBounds && r.Width >= 1 && r.Height >= 1)
				{
					inBounds = path.IsVisible(r.Left, r.Top) &&
							   path.IsVisible(r.Right, r.Top) &&
							   path.IsVisible(r.Left, r.Bottom) &&
							   path.IsVisible(r.Right, r.Bottom);
					r.Inflate(-1, -1);
				}
			}

			contentRect = r;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DrawImage(e.Graphics);
			DrawText(e.Graphics);
			DrawFocus(e.Graphics);
			//base.OnPaint(e);
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			Invalidate();
		}

		protected override void OnParentBackgroundImageChanged(EventArgs e)
		{
			base.OnParentBackgroundImageChanged(e);
			Invalidate();
		}

		#endregion

		#region Internal Draw Methods

		internal void DrawImage(Graphics g)
		{
			int currentImageIndex;

			if (Status == ButtonStatus.Hot || Status == ButtonStatus.Pressed)
				currentImageIndex = (ImageIndexHot != -1) ? ImageIndexHot : ImageIndex;
			else
				currentImageIndex = ImageIndex;


			if (ImageList == null || currentImageIndex == -1)
				return;
			if (currentImageIndex < 0 || currentImageIndex >= ImageList.Images.Count)
				return;

			Image _Image = ImageList.Images[currentImageIndex];

			Point pt = Point.Empty;

			switch (ImageAlign)
			{
				case ContentAlignment.TopLeft:
					pt.X = contentRect.Left;
					pt.Y = contentRect.Top;
					break;

				case ContentAlignment.TopCenter:
					pt.X = (Width - _Image.Width) / 2;
					pt.Y = contentRect.Top;
					break;

				case ContentAlignment.TopRight:
					pt.X = contentRect.Right - _Image.Width;
					pt.Y = contentRect.Top;
					break;

				case ContentAlignment.MiddleLeft:
					pt.X = contentRect.Left;
					pt.Y = (Height - _Image.Height) / 2;
					break;

				case ContentAlignment.MiddleCenter:
					pt.X = (Width - _Image.Width) / 2;
					pt.Y = (Height - _Image.Height) / 2;
					break;

				case ContentAlignment.MiddleRight:
					pt.X = contentRect.Right - _Image.Width;
					pt.Y = (Height - _Image.Height) / 2;
					break;

				case ContentAlignment.BottomLeft:
					pt.X = contentRect.Left;
					pt.Y = contentRect.Bottom - _Image.Height;
					break;

				case ContentAlignment.BottomCenter:
					pt.X = (Width - _Image.Width) / 2;
					pt.Y = contentRect.Bottom - _Image.Height;
					break;

				case ContentAlignment.BottomRight:
					pt.X = contentRect.Right - _Image.Width;
					pt.Y = contentRect.Bottom - _Image.Height;
					break;
			}

			if (Status == ButtonStatus.Pressed)
				pt.Offset(1, 1);

			if (Enabled)
				ImageList.Draw(g, pt, currentImageIndex);
			else
				ControlPaint.DrawImageDisabled(g, _Image, pt.X, pt.Y, BackColor);
		}

		private void DrawText(Graphics g)
		{
			using (var textBrush = new SolidBrush(ForeColor))
			{
				RectangleF R = contentRect;

				if (!Enabled)
					textBrush.Color = SystemColors.GrayText;

				var sf = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);

				if (ShowKeyboardCues)
					sf.HotkeyPrefix = HotkeyPrefix.Show;
				else
					sf.HotkeyPrefix = HotkeyPrefix.Hide;

				switch (TextAlign)
				{
					case ContentAlignment.TopLeft:
						sf.Alignment = StringAlignment.Near;
						sf.LineAlignment = StringAlignment.Near;
						break;

					case ContentAlignment.TopCenter:
						sf.Alignment = StringAlignment.Center;
						sf.LineAlignment = StringAlignment.Near;
						break;

					case ContentAlignment.TopRight:
						sf.Alignment = StringAlignment.Far;
						sf.LineAlignment = StringAlignment.Near;
						break;

					case ContentAlignment.MiddleLeft:
						sf.Alignment = StringAlignment.Near;
						sf.LineAlignment = StringAlignment.Center;
						break;

					case ContentAlignment.MiddleCenter:
						sf.Alignment = StringAlignment.Center;
						sf.LineAlignment = StringAlignment.Center;
						break;

					case ContentAlignment.MiddleRight:
						sf.Alignment = StringAlignment.Far;
						sf.LineAlignment = StringAlignment.Center;
						break;

					case ContentAlignment.BottomLeft:
						sf.Alignment = StringAlignment.Near;
						sf.LineAlignment = StringAlignment.Far;
						break;

					case ContentAlignment.BottomCenter:
						sf.Alignment = StringAlignment.Center;
						sf.LineAlignment = StringAlignment.Far;
						break;

					case ContentAlignment.BottomRight:
						sf.Alignment = StringAlignment.Far;
						sf.LineAlignment = StringAlignment.Far;
						break;
				}

				if (Status == ButtonStatus.Pressed)
					R.Offset(1, 1);

				if (Enabled)
				{
					if (TextShadowColor != Color.Transparent)
					{
						g.DrawString(Text, Font, new SolidBrush(TextShadowColor),
									 new RectangleF(R.X + 1, R.Y + 1, R.Width, R.Height), sf);
					}

					g.DrawString(Text, Font, textBrush, R, sf);
				}
				else
				{
					ControlPaint.DrawStringDisabled(g, Text, Font, BackColor, R, sf);
				}
			}
		}

		private void DrawFocus(Graphics g)
		{
			Rectangle rect = contentRect;
			rect.Inflate(1, 1);

			if (Focused && ShowFocusCues && TabStop)
				ControlPaint.DrawFocusRectangle(g, rect, ForeColor, BackColor);
		}

		#endregion

		#region Helper Methods

		private GraphicsPath RoundRectangle(Rectangle r, int radius, Corners corners)
		{
			//Make sure the Path fits inside the rectangle
			r.Width -= 1;
			r.Height -= 1;

			//Scale the radius if it's too large to fit.
			if (radius > (r.Width))
				radius = r.Width;
			if (radius > (r.Height))
				radius = r.Height;

			var path = new GraphicsPath();

			if (radius <= 0)
				path.AddRectangle(r);
			else if ((corners & Corners.TopLeft) == Corners.TopLeft)
				path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
			else
				path.AddLine(r.Left, r.Top, r.Left, r.Top);

			if ((corners & Corners.TopRight) == Corners.TopRight)
				path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
			else
				path.AddLine(r.Right, r.Top, r.Right, r.Top);

			if ((corners & Corners.BottomRight) == Corners.BottomRight)
				path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
			else
				path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);

			if ((corners & Corners.BottomLeft) == Corners.BottomLeft)
				path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
			else
				path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);

			path.CloseFigure();

			return path;
		}

		//The ControlPaint Class has methods to Lighten and Darken Colors, but they return a Solid Color.
		//The Following 2 methods return a modified color with original Alpha.
		private Color DarkenColor(Color colorIn, int percent)
		{
			//This method returns Black if you Darken by 100%

			if (percent < 0 || percent > 100)
				throw new ArgumentOutOfRangeException("percent");

			int a, r, g, b;

			a = colorIn.A;
			r = colorIn.R - (int)((colorIn.R / 100f) * percent);
			g = colorIn.G - (int)((colorIn.G / 100f) * percent);
			b = colorIn.B - (int)((colorIn.B / 100f) * percent);

			return Color.FromArgb(a, r, g, b);
		}


		private Color LightenColor(Color colorIn, int percent)
		{
			//This method returns White if you lighten by 100%

			if (percent < 0 || percent > 100)
				throw new ArgumentOutOfRangeException("percent");

			int a, r, g, b;

			a = colorIn.A;
			r = colorIn.R + (int)(((255f - colorIn.R) / 100f) * percent);
			g = colorIn.G + (int)(((255f - colorIn.G) / 100f) * percent);
			b = colorIn.B + (int)(((255f - colorIn.B) / 100f) * percent);

			return Color.FromArgb(a, r, g, b);
		}

		#endregion

		private void OnStatusChange(EventArgs e)
		{
			//Repaint the button only if the status has actually changed
			if (Status == currentStatus)
				return;

			currentStatus = Status;
			Invalidate();
		}
	}
}