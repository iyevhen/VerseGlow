using System;
using System.Drawing;
using System.Xml;
using VerseFlow.GFramework.Utils;

namespace VerseFlow.GFramework.Model.Text
{
    public class GShadowElement : GTextElement
    {
        #region Constructor

        public GShadowElement()
        {
        }

        #endregion

        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case ColorPropertyKey:
                    return Color.FromArgb(100, Color.Black);
                case OffsetPropertyKey:
                    return new PointF(1, 1);
                case StrengthPropertyKey:
                    return new Point(1, 1);
                case StylePropertyKey:
                    return ShadowStyle.Solid;
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
                case OffsetAttributeName:
                    PointF offset;
                    if (GLayoutHelper.TryParsePointF(attribute.Value, out offset))
                    {
                        Offset = offset;
                    }
                    return;
                case StrengthAttributeName:
                    Point strength;
                    if (GLayoutHelper.TryParsePoint(attribute.Value, out strength))
                    {
                        Strength = strength;
                    }
                    return;
                case StyleAttributeName:
                    Style = (ShadowStyle)Enum.Parse(typeof(ShadowStyle), attribute.Value, true);
                    return;
            }

            base.ParseAttribute(attribute);
        }

        #endregion

        #region Implementation
        #endregion

        #region Propeties

        public override string TagName
        {
            get
            {
                return GTextDocument.ShadowNodeName;
            }
        }
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
        public PointF Offset
        {
            get
            {
                return (PointF)GetPropertyValue(OffsetPropertyKey);
            }
            set
            {
                if (Offset == value)
                {
                    return;
                }

                SetPropertyValue(OffsetPropertyKey, value);
            }
        }
        public ShadowStyle Style
        {
            get
            {
                return (ShadowStyle)GetPropertyValue(StylePropertyKey);
            }
            set
            {
                if (Style == value)
                {
                    return;
                }

                SetPropertyValue(StylePropertyKey, value);
            }
        }
        public Point Strength
        {
            get
            {
                return (Point)GetPropertyValue(StrengthPropertyKey);
            }
            set
            {
                value = GLayoutHelper.NormalizePoint(value);
                if (Strength == value)
                {
                    return;
                }

                SetPropertyValue(StrengthPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int ColorPropertyKey = 1;
        public const int OffsetPropertyKey = ColorPropertyKey + 1;
        public const int StylePropertyKey = OffsetPropertyKey + 1;
        public const int StrengthPropertyKey = StylePropertyKey + 1;

        #endregion

        #region Static

        public const string ColorAttributeName = "color";
        public const string OffsetAttributeName = "offset";
        public const string StyleAttributeName = "style";
        public const string StrengthAttributeName = "strength";

        #endregion
    }
}
