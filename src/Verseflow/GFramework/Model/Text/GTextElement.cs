using System.Xml;
using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Text
{
    public abstract class GTextElement : GElement
    {
	    protected internal virtual void OnInitialized() { }

        protected internal virtual void ParseAttributes(XmlNode node)
        {
            XmlAttributeCollection attributes = node.Attributes;
            if (attributes == null)
            {
                return;
            }

            int count = attributes.Count;
            for (int i = 0; i < count; i++)
            {
                ParseAttribute(attributes[i]);
            }
        }
        protected virtual void ParseAttribute(XmlAttribute attribute)
        {
        }

	    public abstract string TagName
        {
            get;
        }
        public virtual bool IsContainer
        {
            get
            {
                return false;
            }
        }
        public virtual bool ContainsText
        {
            get
            {
                return false;
            }
        }
        public virtual bool IsLineBreak
        {
            get
            {
                return false;
            }
        }
    }
}
