using System;
using System.Collections;
using System.Xml;

namespace VerseFlow.GFramework.Model.Text
{
    /// <summary>
    /// Creates a text element depending on the specified XML name.
    /// </summary>
    public abstract class GTextElementFactory
    {
        #region Constructor

        public GTextElementFactory()
        {
        }

        #endregion

        #region Public Overridables

        public abstract GTextElement CreateInstance(XmlNode node);

        #endregion

        #region Fields

        /// <summary>
        /// The default factory for creating text elements.
        /// </summary>
        public static readonly GTextElementFactory Default = new GDefaultTextElementFactory();

        #endregion

        internal class GDefaultTextElementFactory : GTextElementFactory
        {
            #region Constructor

            internal GDefaultTextElementFactory()
            {
                InitMap();
            }

            #endregion

            #region Public Implementation

            public override GTextElement CreateInstance(XmlNode node)
            {
                string key = node.Name.ToLower();

                if (m_ElementMap.ContainsKey(key) == false)
                {
                    return null;
                }

                Type type = (Type)m_ElementMap[key];
                GTextElement element = (GTextElement)Activator.CreateInstance(type);

                if (element is GStringElement)
                {
                    ((GStringElement)element).m_Text = node.Value;
                }

                return element;
            }

            #endregion

            #region Private Implementation

            private void InitMap()
            {
                //initialize currently supported tags
                //the hashtable will have as a key the XMLTag and the corresponding type as a value.
                m_ElementMap = new Hashtable();

                //root element
                m_ElementMap.Add("root", typeof(GRootElement));

                //default text element
                m_ElementMap.Add(GTextDocument.TextNodeName, typeof(GStringElement));
                //<b> element
                m_ElementMap.Add(GTextDocument.BoldNodeName, typeof(GBoldElement));
                //<i> element
                m_ElementMap.Add(GTextDocument.ItalicNodeName, typeof(GItalicElement));
                //<u> element
                m_ElementMap.Add(GTextDocument.UnderlineNodeName, typeof(GUnderlineElement));
                //<font> element
                m_ElementMap.Add(GTextDocument.FontNodeName, typeof(GFontElement));
                //<br> element
                m_ElementMap.Add(GTextDocument.LineBreakNodeName, typeof(GLineBreakElement));
                //<p> element
                m_ElementMap.Add(GTextDocument.ParagraphNodeName, typeof(GParagraphElement));
                //<stroke> element
                m_ElementMap.Add(GTextDocument.StrokeNodeName, typeof(GStrokeElement));
                //<ws> element
                m_ElementMap.Add(GTextDocument.WhitespaceNodeName, typeof(GWhitespaceElement));
                //<a> element
                m_ElementMap.Add(GTextDocument.AnchorNodeName, typeof(GAnchorElement));
                //<shadow> element
                m_ElementMap.Add(GTextDocument.ShadowNodeName, typeof(GShadowElement));
            }

            #endregion

            #region Fields

            internal Hashtable m_ElementMap;

            #endregion
        }
    }
}
