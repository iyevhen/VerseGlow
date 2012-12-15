using System.Xml;

namespace VerseFlow.GFramework.Model.Text
{
    /// <summary>
    /// Defines sequence of white spaces.
    /// </summary>
    public class GWhitespaceElement : GTextElement
    {
        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case LengthPropertyKey:
                    return 4;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Protected Overrides

        protected override void ParseAttribute(XmlAttribute attribute)
        {
            switch (attribute.Name)
            {
                case LengthAttributeName:
                    int length;
                    if (int.TryParse(attribute.Value, out length))
                    {
                        Length = length;
                    }
                    return;
            }

            base.ParseAttribute(attribute);
        }

        #endregion

        #region Properties

        public override string TagName
        {
            get
            {
                return GTextDocument.WhitespaceNodeName;
            }
        }

        /// <summary>
        /// Gets or sets the length of white spaces defined by this tab element.
        /// </summary>
        public int Length
        {
            get
            {
                return (int)GetPropertyValue(LengthPropertyKey);
            }
            set
            {
                if (Length == value)
                {
                    return;
                }

                SetPropertyValue(LengthPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int LengthPropertyKey = 1;

        #endregion

        #region Static

        public const string LengthAttributeName = "length";

        #endregion
    }
}
