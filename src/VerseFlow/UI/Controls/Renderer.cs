using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class Renderer
	{
		private readonly Font font;
		private readonly Dictionary<char, int> symbols = new Dictionary<char, int>();
		private int lineHeight = -1;
		private const TextFormatFlags textFormat = TextFormatFlags.NoClipping | TextFormatFlags.NoFullWidthCharacterBreak | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;

		public Renderer(Font font)
		{
			this.font = font;
		}

		public int LineHeight
		{
			get { return lineHeight; }
		}

		public void DrawText(IDeviceContext device, string text, Point position, Color foreColor)
		{
			TextRenderer.DrawText(device, text, font, position, foreColor, textFormat);
		}

		public void DrawText(IDeviceContext device, string text, Point position, Color foreColor, Color backColor)
		{
			TextRenderer.DrawText(device, text, font, position, foreColor, backColor, textFormat);
		}

		public int MeasureTextWidth(IDeviceContext device, string text)
		{
			return string.IsNullOrEmpty(text) 
				? 0 
				: text.Sum(c => MeasureSymbolWidth(device, c));
		}

		public int MeasureSymbolWidth(IDeviceContext device, char symbol)
		{
			int width;
			if (symbols.TryGetValue(symbol, out width))
				return width;

			Size measured = TextRenderer.MeasureText(device, new string(symbol, 1), font, new Size(), textFormat);
			symbols[symbol] = measured.Width;

			if (lineHeight == -1)
				lineHeight = measured.Height;

			return measured.Width;
		}
	}
}