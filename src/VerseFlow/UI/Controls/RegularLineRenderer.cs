using System.Drawing;

namespace VerseFlow.UI.Controls
{
	internal class RegularLineRenderer : LineRenderer
	{
		private readonly VerseViewColorTheme colorTheme;

		public RegularLineRenderer(Renderer renderer, VerseViewColorTheme colorTheme)
			: base(renderer)
		{
			this.renderer = renderer;
			this.colorTheme = colorTheme;
		}

		public override void DrawLine(Graphics graphics, string line, Point point)
		{
			renderer.DrawText(graphics, line, point, colorTheme.TextColor);
		}
	}
}