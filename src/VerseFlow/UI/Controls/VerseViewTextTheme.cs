using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	class VerseViewTextTheme
	{
		private readonly Font font;
		private readonly Dictionary<char, int> symbols = new Dictionary<char, int>();
		private int lineHeight = -1;
		private const TextFormatFlags TextFormat = TextFormatFlags.NoClipping | TextFormatFlags.NoFullWidthCharacterBreak | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;

		public VerseViewTextTheme(Font font)
		{
			this.font = font;
		}

		public int LineHeight
		{
			get { return lineHeight; }
		}

		public Font Font
		{
			get { return font; }
		}

		public int MeasureTextWidth(Graphics graphics, string text)
		{
			if (string.IsNullOrEmpty(text))
				throw new ArgumentNullException("text");

			return text.Sum(c => MeasureSymbolWidth(graphics, c));
		}

		public int MeasureSymbolWidth(Graphics graphics, char symbol)
		{
			int width;
			if (symbols.TryGetValue(symbol, out width))
				return width;

			Size measured = TextRenderer.MeasureText(graphics, new string(symbol, 1), font, new Size(), TextFormat);
			symbols[symbol] = measured.Width;

			if (lineHeight == -1)
				lineHeight = measured.Height;

			return measured.Width;
		}
	}
}