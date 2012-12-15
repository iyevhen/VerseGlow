using System.Collections.Generic;
using System.Text;
using System.Drawing;
using VerseFlow.GFramework.Drawing;
using VerseFlow.GFramework.Drawing.Brushes;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Drawing.Pens;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.Model.Collections;
using VerseFlow.GFramework.Model.Text;

namespace VerseFlow.GFramework.View.Text
{
    /// <summary>
    /// A context passed in text building processes.
    /// </summary>
    internal class GTextDocumentParser
    {
        #region Constructor

        internal GTextDocumentParser(GDeviceContext deviceContext, GTextView view)
        {
            m_DeviceContext = deviceContext;
            m_View = view;
            m_Styles = new Stack<GTextStyle>();
            m_Paragraphs = new Stack<GParagraph>();

            m_Styles.Push(GTextStyle.NewDefaultStyle());

            //create default paragraph and add it to the view
            GParagraph defaultParagraph = new GParagraph();
            m_Paragraphs.Push(defaultParagraph);
            m_View.children.Add(defaultParagraph);
        }

        #endregion

        #region Implementation

        internal void ProcessCollection(GNodeCollection modelElements)
        {
            int count = modelElements.Count;
            if (count == 0)
            {
                return;
            }

            GTextElement current;

            for (int i = 0; i < count; i++)
            {
                current = (GTextElement)modelElements[i];
                ProcessElement(current);
            }
        }
        internal void ProcessElement(GTextElement element)
        {
            GTextStyle currentStyle = m_Styles.Peek();
            GTextStyle newStyle = null;
            bool newParagraph = false;
            bool newAnchor = false;

            switch (element.TagName)
            {
                    //anchor element
                case GTextDocument.AnchorNodeName:
                    //open anchor and create new style for all anchor words
                    newStyle = OpenAnchor((GAnchorElement)element, currentStyle);
                    newAnchor = true;
                    break;
                    //paragraph element
                case GTextDocument.ParagraphNodeName:
                    newParagraph = true;
                    break;
                    //bold element
                case GTextDocument.BoldNodeName:
                    //we have a currently bold font, no need to create new one
                    if (currentStyle.m_Font.Bold)
                    {
                        break;
                    }
                    //we need a new style to reflect the "Bold"
                    newStyle = new GTextStyle(currentStyle);
                    newStyle.m_Font = NewBoldFont(currentStyle.m_Font);
                    break;
                    //italic element
                case GTextDocument.ItalicNodeName:
                    //we have a currently italic font, no need to create new one
                    if (currentStyle.m_Font.Italic)
                    {
                        break;
                    }
                    //we need a new style to reflect the "Italic"
                    newStyle = new GTextStyle(currentStyle);
                    newStyle.m_Font = NewItalicFont(currentStyle.m_Font);
                    break;
                    //underline element
                case GTextDocument.UnderlineNodeName:
                    //we have a currently italic font, no need to create new one
                    if (currentStyle.m_Font.Underline)
                    {
                        break;
                    }
                    //we need a new style to reflect the "Underline"
                    newStyle = new GTextStyle(currentStyle);
                    newStyle.m_Font = NewUnderlineFont(currentStyle.m_Font);
                    break;
                    //font element
                case GTextDocument.FontNodeName:
                    //we need a new style to reflect the "Font" element
                    newStyle = new GTextStyle(currentStyle);
                    GFontElement fontElement = (GFontElement)element;
                    newStyle.m_Font = NewFont(fontElement, currentStyle.m_Font);
                    if (fontElement.ContainsLocalProperty(GFontElement.ColorPropertyKey))
                    {
                        newStyle.m_Brush = new GSolidBrush(fontElement.Color);
                    }
                    newStyle.m_ScaleX = fontElement.ScaleX;
                    newStyle.m_ScaleY = fontElement.ScaleY;
                    break;
                    //outline
                case GTextDocument.StrokeNodeName:
                    GStrokeElement strokeElement = (GStrokeElement)element;
                    if (strokeElement.Width > 0)
                    {
                        newStyle = new GTextStyle(currentStyle);
                        newStyle.m_Pen = new GPen(strokeElement.Color, strokeElement.Width);
                    }
                    break;
                case GTextDocument.ShadowNodeName:
                    GShadowElement shadowElement = (GShadowElement)element;
                    newStyle = new GTextStyle(currentStyle);
                    newStyle.m_Shadow = NewShadow(shadowElement);
                    break;
                    //new line
                case GTextDocument.LineBreakNodeName:
                    BreakLine();
                    break;
                    //whitespace
                case GTextDocument.WhitespaceNodeName:
                    int length = ((GWhitespaceElement)element).Length;
                    GWhitespace whiteSpace = new GWhitespace(m_Styles.Peek(), length);
                    whiteSpace.Initialize(m_DeviceContext);
                    m_CurrentTextBlock.m_Words.AddLast(whiteSpace);
                    break;
                    //a string element
                case GTextDocument.TextNodeName:
                    string text = ((GStringElement)element).Text;
                    ProcessText(text);
                    break;
            }

            //push the new style (if any)
            if (newStyle != null)
            {
                m_Styles.Push(newStyle);
            }
            if (newParagraph)
            {
                PushParagraph(element);
            }

            ProcessCollection(element.children);

            //pop previuosly pushed style
            if (newStyle != null)
            {
                m_Styles.Pop();
            }
            if (newParagraph)
            {
                PopParagraph();
            }
            if (newAnchor)
            {
                CloseAnchor();
            }
        }

        internal void ProcessText(string text)
        {
            //remove escape characters
            text = text.Replace("\r\n", "");
            text = text.Replace("\t", "");
            text = text.Replace("\n", "");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            GTextStyle current = m_Styles.Peek();
            GTextBlock textBlock = CurrentTextBlock;

            StringBuilder sb = new StringBuilder();
            int length = text.Length;
            GWhitespace whiteSpace = null;

            for (int i = 0; i < length; i++)
            {
                char currChar = text[i];

                if (currChar == ' ')
                {
                    if (sb.Length > 0)
                    {
                        CreateWord(sb, current, textBlock);
                    }
                    if (whiteSpace == null)
                    {
                        whiteSpace = CreateWhitespace(current, textBlock);
                    }
                    else
                    {
                        whiteSpace.m_Length++;
                    }
                }
                else
                {
                    if (whiteSpace != null)
                    {
                        whiteSpace.Initialize(m_DeviceContext);
                    }
                    whiteSpace = null;
                    sb.Append(currChar);
                }
            }

            if (sb.Length > 0)
            {
                CreateWord(sb, current, textBlock);
            }
            if (whiteSpace != null)
            {
                whiteSpace.Initialize(m_DeviceContext);
            }
        }
        internal GWord CreateWord(StringBuilder sb, GTextStyle style, GTextBlock block)
        {
            GWord word = new GWord(style, sb.ToString());
            word.Initialize(m_DeviceContext);
            block.m_Words.AddLast(word);
            if (m_CurrentAnchor != null)
            {
                m_CurrentAnchor.AddWord(word);
            }

            sb.Remove(0, sb.Length);

            return word;
        }
        internal GWhitespace CreateWhitespace(GTextStyle style, GTextBlock block)
        {
            GWhitespace whitespace = new GWhitespace(style, 1);
            block.m_Words.AddLast(whitespace);

            if (m_CurrentAnchor != null)
            {
                m_CurrentAnchor.AddWord(whitespace);
            }

            return whitespace;
        }

        internal GFont NewFont(GFontElement element, GFont current)
        {
            GFont font = new GFont(current);

            object face = element.GetLocalPropertyValue(GFontElement.FacePropertyKey);
            if (face != null)
            {
                font.Face = (string)face;
            }
            object size = element.GetLocalPropertyValue(GFontElement.SizePropertyKey);
            if (size != null)
            {
                font.Size = (float)size;
            }

            return font;
        }
        internal GFont NewBoldFont(GFont prototype)
        {
            GFont font = new GFont(prototype);
            font.Bold = true;

            return font;
        }
        internal GFont NewItalicFont(GFont prototype)
        {
            GFont font = new GFont(prototype);
            font.Italic = true;

            return font;
        }
        internal GFont NewUnderlineFont(GFont prototype)
        {
            GFont font = new GFont(prototype);
            font.Underline = true;

            return font;
        }
        internal GShadow NewShadow(GShadowElement model)
        {
            GShadow shadow = new GShadow();
            shadow.m_Style = model.Style;
            shadow.m_Color = model.Color;
            shadow.m_Offset = model.Offset;
            shadow.m_Strength = model.Strength;

            return shadow;
        }

        internal void PushParagraph(GTextElement model)
        {
            GParagraph currentParagraph = m_Paragraphs.Peek();
            GParagraph paragraph = new GParagraph();
            paragraph.InitFromTextElement(model);

            currentParagraph.children.Add(paragraph);
            m_Paragraphs.Push(paragraph);
            m_CurrentTextBlock = null;
        }
        internal void PopParagraph()
        {
            m_Paragraphs.Pop();
            m_CurrentTextBlock = null;
        }
        internal void BreakLine()
        {
            //the current text block is null, we have a line break which should be treated as advancing the Y value of the text
            //this is done by creating an empty text block and specifying its linebreak font.
            if (m_CurrentTextBlock == null)
            {
                m_CurrentTextBlock = CurrentTextBlock;
                m_CurrentTextBlock.m_LineBreakFont = m_Styles.Peek().m_Font;
            }

            m_CurrentTextBlock = null;
        }
        internal GTextBlock CurrentTextBlock
        {
            get
            {
                if (m_CurrentTextBlock == null)
                {
                    m_CurrentTextBlock = new GTextBlock();
                    m_Paragraphs.Peek().children.Add(m_CurrentTextBlock);
                }

                return m_CurrentTextBlock;
            }
        }

        internal GTextStyle OpenAnchor(GAnchorElement anchor, GTextStyle currStyle)
        {
            if (m_CurrentAnchor != null)
            {
                return null;
            }

            m_CurrentAnchor = new GAnchor(anchor);
            GParagraph currParagraph = m_Paragraphs.Peek();
            currParagraph.anchors.AddLast(m_CurrentAnchor);

            //update the style
            GTextStyle newStyle = new GTextStyle(currStyle);
            switch (anchor.Decoration)
            {
                case AnchorDecoration.Underline:
                    newStyle.m_Font.Underline = true;
                    break;
                case AnchorDecoration.None:
                    newStyle.m_Font.Underline = false;
                    break;
            }

            if (anchor.ForeColor != Color.Empty)
            {
                newStyle.m_Brush = new GSolidBrush(anchor.ForeColor);
            }

            return newStyle;
        }
        internal void CloseAnchor()
        {
            m_CurrentAnchor = null;
        }

        #endregion

        #region Fields

        internal GTextView m_View;
        internal GDeviceContext m_DeviceContext;
        internal Stack<GTextStyle> m_Styles;
        internal Stack<GParagraph> m_Paragraphs;
        internal GTextBlock m_CurrentTextBlock;
        internal GAnchor m_CurrentAnchor;

        #endregion
    }
}
