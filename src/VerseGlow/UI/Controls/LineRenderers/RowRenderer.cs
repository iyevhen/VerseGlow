using System;
using System.Drawing;

using VerseGlow.Common;

namespace VerseGlow.UI.Controls.LineRenderers
{
	internal abstract class RowRenderer
	{
		protected Renderer renderer;

		protected RowRenderer(Renderer renderer)
		{
			Is.NotNull(renderer, "renderer");
			this.renderer = renderer;
		}

		public virtual void DrawLine(Graphics graphics, string value, Point point) { }

		public Renderer Renderer
		{
			get { return renderer; }
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");
				renderer = value;
			}
		}
	}
}