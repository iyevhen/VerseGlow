using System;
using System.Drawing;

namespace VerseFlow.UI.Controls.LineRenderers
{
    internal class HighlightRowRenderer : RowRenderer
    {
        private readonly VerseViewColorTheme colorTheme;
        private readonly string highlight;

        public HighlightRowRenderer(Renderer renderer, VerseViewColorTheme colorTheme, string highlight)
            : base(renderer)
        {
            this.colorTheme = colorTheme;
            this.highlight = highlight;
        }

        public override void DrawLine(Graphics graphics, string value, Point point)
        {
            int cur = 0;
            while (cur < value.Length)
            {
                int found = value.IndexOf(highlight, cur, StringComparison.OrdinalIgnoreCase);

                if (found > -1)
                {
                    int normal = found - cur;
                    string before = value.Substring(cur, normal);

                    renderer.DrawText(graphics, before, point, colorTheme.TextColor);
                    point.X += renderer.MeasureTextWidth(graphics, before);
                    
                    string highligten = value.Substring(found, highlight.Length);
                    renderer.DrawText(graphics, highligten, point, colorTheme.TextHighlightColor, colorTheme.TextHighlightBackColor);
                    point.X += renderer.MeasureTextWidth(graphics, highligten);

                    cur = found + highlight.Length;
                }
                else
                {
                    renderer.DrawText(graphics, value.Substring(cur), point, colorTheme.TextColor);
                    cur = value.Length;
                }
            }
        }
    }
}