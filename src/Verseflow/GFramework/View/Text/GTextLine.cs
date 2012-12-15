using System;
using System.Collections.Generic;
using System.Drawing;
using VerseFlow.GFramework.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Drawing.Pens;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View.Text
{
	/// <summary>
	///     A line of text which children are GChar instances.
	/// </summary>
	internal class GTextLine
	{
		internal float m_Baseline;
		internal GFontDecorationInfo m_CurrDecoration;
		internal List<GFontDecorationInfo> m_Decorations;
		internal bool m_IsLastLine;
		internal float m_SpaceToDistribute;
		internal float m_Top;
		internal LinkedList<GWord> m_Words;
		internal float m_WordsHeight;
		internal float m_WordsWidth;

		public GTextLine()
		{
			m_Words = new LinkedList<GWord>();
			m_Decorations = new List<GFontDecorationInfo>();
		}

		internal void Paint(GTextViewPaintContext context)
		{
			LinkedListNode<GWord> currNode = m_Words.First;
			RectangleF clip = context.deviceContext.ClipBounds;
			m_Decorations.Clear();

			while (currNode != null)
			{
				GWord currWord = currNode.Value;

				var bounds = new RectangleF(currWord.m_Location, currWord.m_Metric.Size);
				if (clip.IntersectsWith(bounds) && (currWord.IsWhitespace == false))
				{
					context.deviceContext.PaintWord(currWord);
				}

				currNode = currNode.Next;

				ProcessDecoration(currWord, currNode == null);
			}

			//paint all decorations
			int count = m_Decorations.Count;
			var pen = new GPen();

			for (int i = 0; i < count; i++)
			{
				GFontDecorationInfo info = m_Decorations[i];
				pen.Width = (int)(info.Thickness + .5F);

				foreach (GLine line in info.Lines)
				{
					pen.Color = line.Color;
					var start = new PointF(line.StartX, line.StartY + info.Offset);
					var end = new PointF(line.EndX, line.EndY + info.Offset);
					context.deviceContext.DrawLine(pen, start, end);
				}
			}
		}

		internal void Layout(GTextViewLayoutContext context)
		{
			//remove any whitespaces on left and right
			Trim();

			//no need to perform operations of word count is zero
			int count = m_Words.Count;
			if (count == 0)
			{
				return;
			}

			//calculate baseline position and line height
			CalculateMetrics(context);
			//remember the Y coordinate of the line
			m_Top = context.Y;

			//determine the X-coordinate of the firts word
			float x = GetLineStart(context);
			float maxRight = context.AvailableSize.Width - x - context.Right;
			float y;

			LinkedListNode<GWord> firstNode = m_Words.First;
			LinkedListNode<GWord> node = firstNode;
			GWord currWord = node.Value;

			while (node != null)
			{
				currWord = node.Value;
				node = node.Next;

				//subtract the render padding on the left
				x -= currWord.m_Metric.Padding.Left;
				//the y coordinate of the word is baseline minus word's EmHeight
				y = context.Y + (m_Baseline - currWord.m_FontMetric.TextMetric.tmAscent);

				//remember the calculated location
				currWord.m_Location = new PointF(x, y);

				//advance the x value
				x += currWord.m_Metric.Size.Width - currWord.m_Metric.Padding.Right;
				x += m_SpaceToDistribute;
			}

			//advance the Y value of the context with the height of the line
			context.Y += m_WordsHeight;
		}

		internal void CalculateMetrics(GTextViewLayoutContext context)
		{
			LinkedListNode<GWord> currNode = m_Words.First;
			GWord currWord;

			while (currNode != null)
			{
				currWord = currNode.Value;
				currNode = currNode.Next;

				m_WordsWidth += currWord.m_Metric.BlackBox.Width;
				m_WordsHeight = Math.Max(m_WordsHeight, currWord.m_Metric.Size.Height);

				m_Baseline = Math.Max(m_Baseline, currWord.m_FontMetric.TextMetric.tmAscent);
			}
		}

		internal float GetLineStart(GTextViewLayoutContext context)
		{
			m_SpaceToDistribute = 0F;
			float x = context.X;
			float lineWidth;

			switch (context.Align)
			{
				case ParagraphAlign.Right:
					float right = context.AvailableSize.Width - context.Right;
					x = Math.Max(x, right - m_WordsWidth);
					break;
				case ParagraphAlign.Center:
					lineWidth = context.AvailableSize.Width - context.X - context.Right;
					x += (lineWidth - m_WordsWidth) / 2F;
					break;
				case ParagraphAlign.Justify:
					//calculate the offset to apply to each space to accomodate the Justify setting
					if (m_IsLastLine)
					{
						break;
					}
					lineWidth = context.AvailableSize.Width - context.X - context.Right;
					m_SpaceToDistribute = (lineWidth - m_WordsWidth) / (m_Words.Count - 1);
					m_SpaceToDistribute = Math.Max(0, m_SpaceToDistribute);
					break;
			}

			return x;
		}

		internal void AddWord(GWord word)
		{
			m_Words.AddLast(word);
			word.m_Owner = this;
		}

		internal void Trim()
		{
			LinkedListNode<GWord> node = m_Words.First;
			GWord word;

			//trim left
			while (node != null)
			{
				word = node.Value;
				node = node.Next;

				if (word.IsWhitespace)
				{
					m_Words.RemoveFirst();
				}
				else
				{
					break;
				}
			}

			node = m_Words.Last;
			//trim right
			while (node != null)
			{
				word = node.Value;
				node = node.Previous;

				if (word.IsWhitespace)
				{
					m_Words.RemoveLast();
				}
				else
				{
					break;
				}
			}
		}

		internal void ProcessDecoration(GWord word, bool isLast)
		{
			if (word.m_Style.m_Font.Underline)
			{
				Underline(word);
				if (isLast)
				{
					EndUnderline();
				}
			}
			else
			{
				EndUnderline();
			}
		}

		internal void Underline(GWord word)
		{
			if (string.IsNullOrEmpty(word.m_Text))
			{
				return;
			}

			if (m_CurrDecoration != null)
			{
				m_CurrDecoration.Thickness = Math.Max(word.m_FontMetric.DecorationThickness, m_CurrDecoration.Thickness);
				m_CurrDecoration.Offset = Math.Max(word.m_FontMetric.UnderlinePosition, m_CurrDecoration.Offset);

				//update lines
				GLine currLine = m_CurrDecoration.Lines.Last.Value;
				//add new line with new color
				if (currLine.Color != word.m_Style.m_Brush.Color)
				{
					var newLine = new GLine(currLine);
					newLine.StartX = word.m_Location.X + word.m_Metric.Padding.Left;
					newLine.EndX = newLine.StartX + word.m_Metric.BlackBox.Width;
					newLine.Color = word.m_Style.m_Brush.Color;

					m_CurrDecoration.Lines.AddLast(newLine);
				}
				else
				{
					currLine.EndX = word.m_Location.X + word.m_Metric.Size.Width - word.m_Metric.Padding.Right;
				}
			}
			else
			{
				m_CurrDecoration = new GFontDecorationInfo
					{
						Thickness = word.m_FontMetric.DecorationThickness,
						Offset = word.m_FontMetric.UnderlinePosition
					};

				var newLine = new GLine { StartX = word.m_Location.X + word.m_Metric.Padding.Left };
				newLine.EndX = newLine.StartX + word.m_Metric.BlackBox.Width;
				newLine.StartY = (int)(m_Top + m_Baseline);
				newLine.EndY = newLine.StartY;
				newLine.Color = word.m_Style.m_Brush.Color;

				m_CurrDecoration.Lines.AddLast(newLine);
			}
		}

		internal void EndUnderline()
		{
			if (m_CurrDecoration == null)
			{
				return;
			}

			m_Decorations.Add(m_CurrDecoration);
			m_CurrDecoration = null;
		}

		//using linked list for dynamic sequential storage
	}
}