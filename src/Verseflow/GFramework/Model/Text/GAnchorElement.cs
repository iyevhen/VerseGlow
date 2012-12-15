using System;
using System.Xml;
using System.Drawing;

namespace VerseFlow.GFramework.Model.Text
{
    public class GAnchorElement : GTextElement
    {
        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case HrefPropertyKey:
                    return string.Empty;
                case DecorationPropertyKey:
                    return AnchorDecoration.Underline;
                case ColorPropertyKey:
                    return Color.Navy;
                case HoverColorPropertyKey:
                    return Color.Red;
                case CursorPropertyKey:
                    return PredefinedCursors.Hand;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Protected Overrides

        protected internal override void ParseAttributes(XmlNode node)
        {
            base.ParseAttributes(node);

            Text = node.InnerText;
        }
        protected override void ParseAttribute(XmlAttribute attribute)
        {
            switch (attribute.Name.ToLower())
            {
                case HrefAttributeName:
                    Href = attribute.Value;
                    return;
                case DecorationAttributeName:
                    try
                    {
                        Decoration = (AnchorDecoration)Enum.Parse(typeof(AnchorDecoration), attribute.Value);
                    }
                    catch
                    {
                    }
                    return;
                case ColorAttributeName:
                    try
                    {
                        ForeColor = ColorTranslator.FromHtml(attribute.Value);
                    }
                    catch
                    {
                    }
                    return;
                case HoverColorAttributeName:
                    try
                    {
                        HoverForeColor = ColorTranslator.FromHtml(attribute.Value);
                    }
                    catch
                    {
                    }
                    return;
                case CursorAttributeName:
                    try
                    {
                        Cursor = (PredefinedCursors)Enum.Parse(typeof(PredefinedCursors), attribute.Value);
                    }
                    catch
                    {
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
                return GTextDocument.AnchorNodeName;
            }
        }
        /// <summary>
        /// Gets or sets the Href attribute of this anchor element.
        /// </summary>
        public string Href
        {
            get
            {
                return (string)GetPropertyValue(HrefPropertyKey);
            }
            set
            {
                if (Href == value)
                {
                    return;
                }

                SetPropertyValue(HrefPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets the Display Text of this anchor element.
        /// </summary>
        public string Text
        {
            get
            {
                return (string)GetPropertyValue(TextPropertyKey);
            }
            private set
            {
                if (Text == value)
                {
                    return;
                }

                SetPropertyValue(TextPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the Decoration attribute of this anchor element.
        /// </summary>
        public AnchorDecoration Decoration
        {
            get
            {
                return (AnchorDecoration)GetPropertyValue(DecorationPropertyKey);
            }
            set
            {
                if (Decoration == value)
                {
                    return;
                }

                SetPropertyValue(DecorationPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the fore color for this anchor.
        /// Color.Navy by default.
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return (Color)GetPropertyValue(ColorPropertyKey);
            }
            set
            {
                if (ForeColor == value)
                {
                    return;
                }

                SetPropertyValue(ColorPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the fore color for this anchor when it is hovered.
        /// </summary>
        public Color HoverForeColor
        {
            get
            {
                return (Color)GetPropertyValue(HoverColorPropertyKey);
            }
            set
            {
                if (HoverForeColor == value)
                {
                    return;
                }

                SetPropertyValue(HoverColorPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the cursor to be displayed when the mouse hovers this anchor.
        /// </summary>
        public PredefinedCursors Cursor
        {
            get
            {
                return (PredefinedCursors)GetPropertyValue(CursorPropertyKey);
            }
            set
            {
                if (Cursor == value)
                {
                    return;
                }

                SetPropertyValue(CursorPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int HrefPropertyKey = 1;
        public const int TextPropertyKey = HrefPropertyKey + 1;
        public const int DecorationPropertyKey = TextPropertyKey + 1;
        public const int ColorPropertyKey = DecorationPropertyKey + 1;
        public const int HoverColorPropertyKey = ColorPropertyKey + 1;
        public const int CursorPropertyKey = HoverColorPropertyKey + 1;

        #endregion

        #region Static

        public const string HrefAttributeName = "href";
        public const string DecorationAttributeName = "decoration";
        public const string ColorAttributeName = "color";
        public const string HoverColorAttributeName = "hcolor";
        public const string CursorAttributeName = "cursor";

        #endregion
    }
}
