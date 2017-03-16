using System.Drawing;

namespace VerseFlow.UI.Controls.LineRenderers
{
	internal class RegularRowRenderer : RowRenderer
	{
		private readonly VerseViewColorTheme colorTheme;

		public RegularRowRenderer(Renderer renderer, VerseViewColorTheme colorTheme)
			: base(renderer)
		{
			this.renderer = renderer;
			this.colorTheme = colorTheme;
		}

		public override void DrawLine(Graphics graphics, string value, Point point)
		{
			renderer.DrawText(graphics, value, point, colorTheme.TextColor);
		}
	}
}