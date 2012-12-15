using System.Collections.Generic;
using System.Drawing;
using System.Text;
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
	internal class GTextDocumentParser
	{
		private GAnchor currentAnchor;
		private GTextBlock currentTextBlock;
		private readonly GDeviceContext deviceContext;
		private readonly Stack<GParagraph> paragraphs;
		private readonly Stack<GTextStyle> textStyles;
		private readonly GTextView textView;

		internal GTextDocumentParser(GDeviceContext deviceContext, GTextView view)
		{
			this.deviceContext = deviceContext;
			textView = view;
			textStyles = new Stack<GTextStyle>();
			paragraphs = new Stack<GParagraph>();

			textStyles.Push(GTextStyle.NewDefaultStyle());

			//create default paragraph and add it to the view
			var defaultParagraph = new GParagraph();
			paragraphs.Push(defaultParagraph);
			textView.children.Add(defaultParagraph);
		}

		private GTextBlock CurrentTextBlock
		{
			get
			{
				if (currentTextBlock == null)
				{
					currentTextBlock = new GTextBlock();
					paragraphs.Peek().children.Add(currentTextBlock);
				}

				return currentTextBlock;
			}
		}

		internal void ProcessCollection(GNodeCollection modelElements)
		{
			int count = modelElements.Count;
			if (count == 0)
			{
				return;
			}

			for (int i = 0; i < count; i++)
			{
				var current = (GTextElement)modelElements[i];
				ProcessElement(current);
			}
		}

		private void ProcessElement(GTextElement element)
		{
			GTextStyle currentStyle = textStyles.Peek();
			GTextStyle newStyle = null;
			bool newParagraph = false;
			bool newAnchor = false;

			switch (element.TagName)
			{
				case GTextDocument.AnchorNodeName:
					{
						//open anchor and create new style for all anchor words
						newStyle = OpenAnchor((GAnchorElement)element, currentStyle);
						newAnchor = true;
						break;
					}
				case GTextDocument.ParagraphNodeName:
					{
						newParagraph = true;
						break;
					}
				case GTextDocument.BoldNodeName:
					{
						if (!currentStyle.m_Font.Bold)
							newStyle = new GTextStyle(currentStyle) { m_Font = NewBoldFont(currentStyle.m_Font) };

						break;
					}
				case GTextDocument.ItalicNodeName:
					{
						if (!currentStyle.m_Font.Italic)
							newStyle = new GTextStyle(currentStyle) { m_Font = NewItalicFont(currentStyle.m_Font) };

						break;
					}
				case GTextDocument.UnderlineNodeName:
					{
						if (!currentStyle.m_Font.Underline)
							newStyle = new GTextStyle(currentStyle) { m_Font = NewUnderlineFont(currentStyle.m_Font) };

						break;
					}
				case GTextDocument.FontNodeName:
					{
						var fontElement = (GFontElement)element;
						newStyle = new GTextStyle(currentStyle) { m_Font = NewFont(fontElement, currentStyle.m_Font) };

						if (fontElement.ContainsLocalProperty(GFontElement.ColorPropertyKey))
						{
							newStyle.m_Brush = new GSolidBrush(fontElement.Color);
						}
						newStyle.m_ScaleX = fontElement.ScaleX;
						newStyle.m_ScaleY = fontElement.ScaleY;
						break;
					}
				case GTextDocument.StrokeNodeName:
					{
						var strokeElement = (GStrokeElement)element;

						if (strokeElement.Width > 0)
						{
							newStyle = new GTextStyle(currentStyle) { m_Pen = new GPen(strokeElement.Color, strokeElement.Width) };
						}
						break;
					}
				case GTextDocument.ShadowNodeName:
					{
						var shadowElement = (GShadowElement)element;
						newStyle = new GTextStyle(currentStyle) { m_Shadow = NewShadow(shadowElement) };
						break;
					}
				case GTextDocument.LineBreakNodeName:
					{
						BreakLine();
						break;
					}
				case GTextDocument.WhitespaceNodeName:
					{
						int length = ((GWhitespaceElement)element).Length;
						var whiteSpace = new GWhitespace(textStyles.Peek(), length);
						whiteSpace.Initialize(deviceContext);
						currentTextBlock.m_Words.AddLast(whiteSpace);
						break;
					}
				case GTextDocument.TextNodeName:
					{
						string text = ((GStringElement)element).Text;
						ProcessText(text);
						break;
					}
			}

			if (newStyle != null)
				textStyles.Push(newStyle);

			if (newParagraph)
				PushParagraph(element);

			ProcessCollection(element.children);

			if (newStyle != null)
				textStyles.Pop();


			if (newParagraph)
				PopParagraph();

			if (newAnchor)
				CloseAnchor();
		}

		private void ProcessText(string text)
		{
			if (string.IsNullOrEmpty(text))
				return;

			text = text.Replace("\r\n", "");
			text = text.Replace("\t", "");
			text = text.Replace("\n", "");

			if (string.IsNullOrEmpty(text))
				return;

			GTextStyle current = textStyles.Peek();
			GTextBlock textBlock = CurrentTextBlock;

			var sb = new StringBuilder();
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
						whiteSpace.Initialize(deviceContext);
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
				whiteSpace.Initialize(deviceContext);
			}
		}

		private GWord CreateWord(StringBuilder sb, GTextStyle style, GTextBlock block)
		{
			var word = new GWord(style, sb.ToString());
			word.Initialize(deviceContext);
			block.m_Words.AddLast(word);
			if (currentAnchor != null)
			{
				currentAnchor.AddWord(word);
			}

			sb.Remove(0, sb.Length);

			return word;
		}

		private GWhitespace CreateWhitespace(GTextStyle style, GTextBlock block)
		{
			var whitespace = new GWhitespace(style, 1);
			block.m_Words.AddLast(whitespace);

			if (currentAnchor != null)
			{
				currentAnchor.AddWord(whitespace);
			}

			return whitespace;
		}

		private GFont NewFont(GFontElement element, GFont current)
		{
			var font = new GFont(current);

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

		private GFont NewBoldFont(GFont prototype)
		{
			return new GFont(prototype) { Bold = true };
		}

		private GFont NewItalicFont(GFont prototype)
		{
			return new GFont(prototype) { Italic = true };
		}

		private GFont NewUnderlineFont(GFont prototype)
		{
			return new GFont(prototype) { Underline = true };
		}

		private GShadow NewShadow(GShadowElement model)
		{
			var shadow = new GShadow
				{
					m_Style = model.Style,
					m_Color = model.Color,
					m_Offset = model.Offset,
					m_Strength = model.Strength
				};

			return shadow;
		}

		private void PushParagraph(GTextElement model)
		{
			GParagraph currentParagraph = paragraphs.Peek();
			var paragraph = new GParagraph();
			paragraph.InitFromTextElement(model);

			currentParagraph.children.Add(paragraph);
			paragraphs.Push(paragraph);
			currentTextBlock = null;
		}

		private void PopParagraph()
		{
			paragraphs.Pop();
			currentTextBlock = null;
		}

		private void BreakLine()
		{
			//the current text block is null, we have a line break which should be treated as advancing the Y value of the text
			//this is done by creating an empty text block and specifying its linebreak font.
			if (currentTextBlock == null)
			{
				currentTextBlock = CurrentTextBlock;
				currentTextBlock.m_LineBreakFont = textStyles.Peek().m_Font;
			}

			currentTextBlock = null;
		}

		private GTextStyle OpenAnchor(GAnchorElement anchor, GTextStyle currStyle)
		{
			if (currentAnchor != null)
			{
				return null;
			}

			currentAnchor = new GAnchor(anchor);
			GParagraph currParagraph = paragraphs.Peek();
			currParagraph.anchors.AddLast(currentAnchor);

			//update the style
			var newStyle = new GTextStyle(currStyle);
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

		private void CloseAnchor()
		{
			currentAnchor = null;
		}
	}
}