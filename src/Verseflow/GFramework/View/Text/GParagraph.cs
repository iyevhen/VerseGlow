using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.GFramework.Model.Text;

namespace VerseFlow.GFramework.View.Text
{
	public class GParagraph : GTextVisual
	{
		internal readonly LinkedList<GAnchor> anchors;
		private GParagraphElement paragraphElement;

		public GParagraph()
		{
			anchors = new LinkedList<GAnchor>();
		}

		public GAnchor AnchorFromPoint(PointF point)
		{
			LinkedListNode<GAnchor> anchor = anchors.First;

			while (anchor != null)
			{
				GAnchor gAnchor = anchor.Value;

				if (gAnchor.WordHitTest(point))
					return gAnchor;

				anchor = anchor.Next;
			}

			return null;
		}

		public override void InitFromTextElement(GTextElement textElement)
		{
			base.InitFromTextElement(textElement);
			paragraphElement = textElement as GParagraphElement;
		}

		protected override void LayoutCore(GTextViewLayoutContext context)
		{
			GTextViewLayoutContextState state = context.GetState();

			var myLocation = new PointF(context.X, context.Y);
			float thisWidth = context.AvailableSize.Width - (context.X + context.Right);

			Padding padding = paragraphElement == null ? Padding.Empty : paragraphElement.Padding;
			context.X += padding.Left;
			context.Y += padding.Top;
			context.Right += padding.Right;

			if (paragraphElement != null)
			{
				context.Wrap = paragraphElement.Wrap;
				context.Align = paragraphElement.Align;
			}

			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				var child = (GTextVisual)children[i];
				child.InvalidateLayout();
				child.Layout(context);
			}

			context.SetState(state);

			//advance the Y value of the context
			context.Y += padding.Bottom;

			float myHeight = context.Y - myLocation.Y;
			bounds = new RectangleF(myLocation, new SizeF(thisWidth, myHeight));

			//rebuild anchor lines
			foreach (GAnchor anchor in anchors)
			{
				anchor.BuildLines();
			}
		}
	}
}