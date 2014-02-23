using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VerseFlow.UI.Controls
{
	class VerseViewColorTheme : IDisposable
	{
		private SolidBrush backColorBrush;
		private SolidBrush backColorDarkerBrush;
		private Color backColor;
		private Blend blend = new Blend
		{
			Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
			Factors = new[] { 1, .8f, .3f, .3f, 0.8f, 1 }
		};

		public VerseViewColorTheme(Color backColor)
		{
			this.backColor = backColor;
		}

		public void Dispose()
		{
			DisposeBrushes();
		}

		private void DisposeBrushes()
		{
			if (backColorBrush != null)
				backColorBrush.Dispose();

			if (backColorDarkerBrush != null)
				backColorDarkerBrush.Dispose();
		}

		public SolidBrush BackColorDarkerBrush
		{
			get { return backColorDarkerBrush; }
		}

		public SolidBrush BackColorBrush
		{
			get { return backColorBrush; }
		}

		public Color BackColor
		{
			get { return backColor; }
			set
			{
				backColor = value;
				DisposeBrushes();

				backColorBrush = new SolidBrush(backColor);
				backColorDarkerBrush = new SolidBrush(GraphicsTools.DarkenColor(backColor, 7));
			}
		}
	}
}