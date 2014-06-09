using System;
using System.Drawing;
using VerseFlow.Common;

namespace VerseFlow.UI.Controls
{
	internal abstract class LineRenderer
	{
		protected Renderer renderer;

		protected LineRenderer(Renderer renderer)
		{
			Is.NotNull(renderer, "renderer");
			this.renderer = renderer;
		}

		public virtual void DrawLine(Graphics graphics, string line, Point point) { }

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