using System.Drawing;
using System.Xml;

namespace VerseFlow.GFramework.Model.Text
{
    public class GStrokeElement : GTextElement
    {
        #region Constructor

        public GStrokeElement()
        {
        }

        #endregion

        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case WidthPropertyKey:
                    return 1F;
                case ColorPropertyKey:
                    return Color.Black;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Protected Overrides

        protected override void ParseAttribute(XmlAttribute attribute)
        {
            switch (attribute.Name.ToLower())
            {
                case ColorAttributeName:
                    Color = ColorTranslator.FromHtml(attribute.Value);
                    return;
                case WidthAttributeName:
                    float width;
                    if (float.TryParse(attribute.Value, out width))
                    {
                        Width = width;
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
                return GTextDocument.StrokeNodeName;
            }
        }

        /// <summary>
        /// Gets or sets the width of the stroke (defaults to 1).
        /// </summary>
        public float Width
        {
            get
            {
                return (float)GetPropertyValue(WidthPropertyKey);
            }
            set
            {
                if (Width == value)
                {
                    return;
                }

                SetPropertyValue(WidthPropertyKey, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of stroke.
        /// </summary>
        public Color Color
        {
            get
            {
                return (Color)GetPropertyValue(ColorPropertyKey);
            }
            set
            {
                if (Color == value)
                {
                    return;
                }

                SetPropertyValue(ColorPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int WidthPropertyKey = 1;
        public const int ColorPropertyKey = WidthPropertyKey + 1;

        #endregion

        #region Static

        public const string WidthAttributeName = "width";
        public const string ColorAttributeName = "color";

        #endregion
    }
}
