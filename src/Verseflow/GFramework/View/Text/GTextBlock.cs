using System.Drawing;
using System.Collections.Generic;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View.Text
{
    /// <summary>
    /// A block of text, which contains characters and may have nested blocks as children.
    /// </summary>
    public class GTextBlock : GTextVisual
    {
        #region Constructor

        public GTextBlock()
        {
            m_Lines = new LinkedList<GTextLine>();
            m_Words = new LinkedList<GWord>();
        }

        #endregion

        #region Protected Overrides

        protected override void LayoutCore(GTextViewLayoutContext context)
        {
            //zero word count means that this is a line-break text block
            if (m_Words.Count == 0)
            {
                //simply advance the Y value of the context by the
                GFontDeviceMetric metric = context.DeviceContext.GetFontDeviceMetric(m_LineBreakFont);
                context.Y += metric.LineSpacing;
                return;
            }

            //get text wrapping from the parent paragraph
            GParagraph ownerParagraph = (GParagraph)parent;
            m_MaxWidth = context.AvailableSize.Width - context.X - context.Right;
            //layout words in lines
            BuildLines(context);
            LayoutLines(context);
        }
        protected override void PaintContent(GPaintContext context)
        {
            if (m_Lines.Count == 0)
            {
                return;
            }

            GTextViewPaintContext textContext = (GTextViewPaintContext)context;

            PointF offset = textContext.ViewBounds.Location;
            RectangleF clipBounds = textContext.deviceContext.ClipBounds;
            LinkedListNode<GTextLine> currNode = m_Lines.First;
            GTextLine currLine;

            while (currNode != null)
            {
                currLine = currNode.Value;
                currNode = currNode.Next;

                //determine whether we need to paint the current line
                float lineHeight = currLine.m_WordsHeight;
                textContext.LineStart = currLine.m_Top + lineHeight;

                if (textContext.LineStart + GDeviceContext.AntialiasOffset > textContext.ViewBounds.Bottom)
                {
                    break;
                }

                //check for word count since the line may have only trimmed whitespaces
                if (currLine.m_Words.Count == 0)
                {
                    continue;
                }

                GWord firstWord = currLine.m_Words.First.Value;
                RectangleF lineBounds = new RectangleF(firstWord.m_Location.X, currLine.m_Top, m_MaxWidth, lineHeight);

                if (lineBounds.IntersectsWith(clipBounds))
                {
                    currLine.Paint(textContext);
                }
            }
        }

        #endregion

        #region Implementation

        internal void BuildLines(GTextViewLayoutContext context)
        {
            m_Lines.Clear();

            int count = m_Words.Count;
            if (count == 0)
            {
                return;
            }

            GTextLine currLine = new GTextLine();
            m_Lines.AddFirst(currLine);

            float lineWidth = 0;
            float wordWidth = 0;

            LinkedListNode<GWord> currNode = m_Words.First;
            GWord currWord;

            while (currNode != null)
            {
                currWord = currNode.Value;
                wordWidth = currWord.m_Metric.Size.Width - currWord.m_Metric.Padding.Horizontal;
                lineWidth += wordWidth;

                //check whether we need a line break
                if (lineWidth > m_MaxWidth && context.Wrap == TextWrap.Word && currLine.m_Words.Count > 0)
                {
                    currLine = new GTextLine();
                    m_Lines.AddLast(currLine);
                    lineWidth = wordWidth;
                }

                currLine.AddWord(currWord);

                currNode = currNode.Next;
                if (currNode == null)
                {
                    currLine.m_IsLastLine = true;
                }
            }
        }
        internal void LayoutLines(GTextViewLayoutContext context)
        {
            LinkedListNode<GTextLine> currNode = m_Lines.First;
            while (currNode != null)
            {
                currNode.Value.Layout(context);
                currNode = currNode.Next;
            }
        }

        #endregion

        #region Fields

        internal float m_MaxWidth;
        internal GFont m_LineBreakFont;
        //using linked list for dynamic sequential storage is times better than List
        internal LinkedList<GTextLine> m_Lines;
        internal LinkedList<GWord> m_Words;

        #endregion
    }
}
