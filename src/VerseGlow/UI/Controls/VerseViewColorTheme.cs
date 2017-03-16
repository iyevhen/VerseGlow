using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VerseGlow.UI.Controls
{
	internal class VerseViewColorTheme : IDisposable
	{
		private readonly Blend blend = new Blend
		{
			Positions = new[] {.0f, .2f, .4f, .6f, .8f, 1},
			Factors = new[] {1, .8f, .3f, .3f, 0.8f, 1}
		};

		private Color backColor;

		private SolidBrush backColorBrush;
		private SolidBrush backColorDarkerBrush;

		private Color highlightColor;
		private Color highlightColorLighten;
		private Pen highlightColorPen;
		private Color textColor;
		private Color textHighlightBackColor;
		private Color textHighlightColor;

		public VerseViewColorTheme()
		{
			BackColor = SystemColors.Control;
			HighlightColor = SystemColors.Highlight;
			TextColor = SystemColors.ControlText;
			TextHighlightColor = Color.Red;
			TextHighlightBackColor = Color.LightYellow;
		}

		#region IDisposable Members

		public void Dispose()
		{
			DisposeBackcolor();
			DisposeHighlight();
		}

		#endregion

		public Brush NewHighlightBrush(Rectangle rectangle)
		{
			return new LinearGradientBrush(rectangle,
				highlightColor,
				highlightColorLighten,
				LinearGradientMode.Vertical) {Blend = blend};
		}

		private void DisposeBackcolor()
		{
			if (backColorBrush != null)
				backColorBrush.Dispose();

			if (backColorDarkerBrush != null)
				backColorDarkerBrush.Dispose();
		}

		private void DisposeHighlight()
		{
			if (highlightColorPen != null)
				highlightColorPen.Dispose();
		}

		public SolidBrush BackColorDarkerBrush
		{
			get { return backColorDarkerBrush; }
		}

		public SolidBrush BackColorBrush
		{
			get { return backColorBrush; }
		}

		public Pen HighlightColorPen
		{
			get { return highlightColorPen; }
		}

		public Color BackColor
		{
			get { return backColor; }
			set
			{
				backColor = value;
				DisposeBackcolor();

				backColorBrush = new SolidBrush(backColor);
				backColorDarkerBrush = new SolidBrush(GraphicsTools.DarkenColor(backColor, 8));
			}
		}

		public Color HighlightColor
		{
			get { return highlightColor; }
			set
			{
				highlightColor = value;
				highlightColorLighten = GraphicsTools.LightenColor(highlightColor, 25);

				DisposeHighlight();
				highlightColorPen = new Pen(highlightColor);
			}
		}

		public Color TextColor
		{
			get { return textColor; }
			set { textColor = value; }
		}

		public Color TextHighlightColor
		{
			get { return textHighlightColor; }
			set { textHighlightColor = value; }
		}

		public Color TextHighlightBackColor
		{
			get { return textHighlightBackColor; }
			set { textHighlightBackColor = value; }
		}
	}
}