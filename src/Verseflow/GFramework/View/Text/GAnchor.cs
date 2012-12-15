using System.Collections.Generic;
using System.Drawing;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.Model.Text;

namespace VerseFlow.GFramework.View.Text
{
	public class GAnchor
	{
		internal GAnchorElement anchorElement;
		internal LinkedList<GWord> gwords;
		internal List<RectangleF> lines;
		internal InputElementMouseState m_MouseState;

		internal GAnchor(GAnchorElement anchorElement)
		{
			this.anchorElement = anchorElement;
			gwords = new LinkedList<GWord>();
			lines = new List<RectangleF>();
		}

		internal void AddWord(GWord word)
		{
			gwords.AddLast(word);
		}

		internal void BuildLines()
		{
			lines.Clear();
			RectangleF currRect = RectangleF.Empty;
			GTextLine currLine = null;

			foreach (GWord word in gwords)
			{
				var bounds = new RectangleF(word.m_Location, word.m_Metric.Size);

				if (currLine != word.m_Owner)
				{
					currRect = bounds;
					currLine = word.m_Owner;
					lines.Add(currRect);
				}
				else
				{
					//combine only if the rect are with higher X
					//this eliminates trimmed (non-laid out whitespaces)
					if (currRect.X < bounds.X)
					{
						currRect = RectangleF.Union(currRect, bounds);
					}
					lines[lines.Count - 1] = currRect;
				}
			}
		}

		public RectangleF SetMouseState(InputElementMouseState state)
		{
			if (m_MouseState == state)
			{
				return RectangleF.Empty;
			}

			m_MouseState = state;

			Color foreColor;
			bool? underline = null;

			switch (anchorElement.Decoration)
			{
				case AnchorDecoration.HoverUnderline:
					underline = state == InputElementMouseState.Hot;
					break;
				case AnchorDecoration.Underline:
					underline = true;
					break;
				case AnchorDecoration.None:
					underline = false;
					break;
			}

			switch (m_MouseState)
			{
				case InputElementMouseState.Hot:
				case InputElementMouseState.Pressed:
					foreColor = anchorElement.HoverForeColor;
					break;
				default:
					foreColor = anchorElement.ForeColor;
					break;
			}

			//update all the words with the new style
			RectangleF invalid = RectangleF.Empty;
			foreach (GWord word in gwords)
			{
				if (foreColor != Color.Empty)
				{
					word.m_Style.m_Brush.Color = foreColor;
				}
				if (underline != null)
				{
					word.m_Style.m_Font.Underline = underline.Value;
				}

				var wordBounds = new RectangleF(word.m_Location, word.m_Metric.Size);
				if (invalid.IsEmpty)
				{
					invalid = wordBounds;
				}
				else
				{
					invalid = RectangleF.Union(invalid, wordBounds);
				}
			}

			return invalid;
		}

		public bool WordHitTest(PointF point)
		{
			foreach (RectangleF rect in lines)
			{
				if (rect.Contains(point))
				{
					return true;
				}
			}

			return false;
		}
	}
}