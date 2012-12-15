using System;
using System.Diagnostics;
using System.Xml;
using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Text
{
	public class GTextDocument : GElement
	{
		internal const ulong StateValidMarkup = StateHasUnmanagedResources << 1;
		public const int TextPropertyKey = 1;
		public const int ElementFactoryPropertyKey = TextPropertyKey + 1;
		public const string AnchorNodeName = "a";
		public const string BoldNodeName = "b";
		public const string FontNodeName = "font";
		public const string ItalicNodeName = "i";
		public const string LineBreakNodeName = "br";
		public const string ParagraphNodeName = "p";
		public const string ShadowNodeName = "shadow";
		public const string StrokeNodeName = "stroke";
		public const string UnderlineNodeName = "u";
		public const string TextNodeName = "#text";
		public const string WhitespaceNodeName = "whitespace";

		/// <summary>
		///     Gets or sets the text to be processed.
		/// </summary>
		public string Text
		{
			get { return GetPropertyValue(TextPropertyKey) as string; }
			set
			{
				if (Text == value)
				{
					return;
				}

				SetPropertyValue(TextPropertyKey, value);
			}
		}

		public GTextElementFactory ElementFactory
		{
			get { return GetPropertyValue(ElementFactoryPropertyKey) as GTextElementFactory; }
			set { SetPropertyValue(ElementFactoryPropertyKey, value); }
		}

		public bool IsValidMarkup
		{
			get { return bitStates[StateValidMarkup]; }
		}

		protected override object GetDefaultPropertyValue(int propertyKey)
		{
			if (propertyKey == ElementFactoryPropertyKey)
			{
				return GTextElementFactory.Default;
			}

			return base.GetDefaultPropertyValue(propertyKey);
		}

		protected virtual void Rebuild()
		{
			children.Clear();
			bitStates[StateValidMarkup] = false;

			string text = Text;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}

			XmlDocument doc = null;

			try
			{
				doc = new XmlDocument();

				//always create a root element
				text = text.Insert(0, "<root>");
				text = text.Insert(text.Length, "</root>");

				doc.LoadXml(text);
				Parse(doc);

				bitStates[StateValidMarkup] = true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		protected virtual void Parse(XmlDocument doc)
		{
			var context = new GTextDocumentParseContext(ElementFactory);
			context.m_Elements.Push(this);
			ParseElement(doc.DocumentElement, context);
		}

		internal void ParseElement(XmlNode xmlNode, GTextDocumentParseContext context)
		{
			//try to add a text element instance to the current parent
			GElement currentParent = context.m_Elements.Peek();
			GTextElement currentChild = context.m_Factory.CreateInstance(xmlNode);
			if (currentChild != null)
			{
				currentChild.ParseAttributes(xmlNode);
				currentChild.OnInitialized();
				currentParent.children.AddInternal(currentChild);
			}

			//loop through all child gnodes
			XmlNodeList children = xmlNode.ChildNodes;
			XmlNode child;
			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				child = children[i];
				if (child == null)
				{
					continue;
				}

				//call this function recursive for the current child element
				if (currentChild != null)
				{
					context.m_Elements.Push(currentChild);
				}

				ParseElement(child, context);

				if (currentChild != null)
				{
					context.m_Elements.Pop();
				}
			}
		}

		protected override void OnPropertyValueChanged(int propertyKey)
		{
			base.OnPropertyValueChanged(propertyKey);

			if (propertyKey != TextPropertyKey)
			{
				return;
			}

			Rebuild();
		}
	}
}