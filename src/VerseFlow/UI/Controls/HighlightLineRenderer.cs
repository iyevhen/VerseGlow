using System;
using System.Drawing;

namespace VerseFlow.UI.Controls
{
	internal class HighlightLineRenderer : LineRenderer
	{
		private readonly VerseViewColorTheme colorTheme;
		private readonly string highlight;

		public HighlightLineRenderer(Renderer renderer, VerseViewColorTheme colorTheme, string highlight)
			: base(renderer)
		{
			this.colorTheme = colorTheme;
			this.highlight = highlight;
		}

		public override void DrawLine(Graphics graphics, string line, Point point)
		{
			int linelen = line.Length;
			int lightlen = highlight.Length;

			int cur = 0;

			while (cur < linelen)
			{
				int found = line.IndexOf(highlight, cur, StringComparison.OrdinalIgnoreCase);

				if (found > -1)
				{
					int normal = found - cur;
					string before = line.Substring(cur, normal);

					renderer.DrawText(graphics, before, point, colorTheme.TextColor);
					point.X += renderer.MeasureTextWidth(graphics, before);

					string highligten = line.Substring(found, lightlen);

					renderer.DrawText(graphics, highligten, point, colorTheme.TextHighlightColor, colorTheme.TextHighlightBackColor);
					point.X += renderer.MeasureTextWidth(graphics, highligten);

					cur = found + lightlen;
				}
				else
				{
					renderer.DrawText(graphics, line.Substring(cur), point, colorTheme.TextColor);
					cur = linelen;
				}
			}
		}
	}
}