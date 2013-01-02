using System.Drawing;
using System.Xml;
using VerseFlow.GFramework.Drawing.Fonts;

namespace VerseFlow.GFramework.Model.Text
{
	public class GFontElement : GTextElement
	{
		public const int FacePropertyKey = 1;
		public const int SizePropertyKey = FacePropertyKey + 1;
		public const int ColorPropertyKey = SizePropertyKey + 1;
		public const int ScaleXPropertyKey = ColorPropertyKey + 1;
		public const int ScaleYPropertyKey = ScaleXPropertyKey + 1;
		public const int DecorationThicknessPropertyKey = ScaleYPropertyKey + 1;

		public const string FaceAttributeName = "face";
		public const string SizeAttributeName = "size";
		public const string ColorAttributeName = "color";
		public const string ScaleXAttributeName = "scalex";
		public const string ScaleYAttributeName = "scaley";
		public const string DecorationThicknessAttributeName = "dt";

		public override string TagName
		{
			get { return GTextDocument.FontNodeName; }
		}

		public string Face
		{
			get { return (string) GetPropertyValue(FacePropertyKey); }
			set
			{
				if (Face == value)
				{
					return;
				}

				SetPropertyValue(FacePropertyKey, value);
			}
		}

		public float Size
		{
			get { return (float) GetPropertyValue(SizePropertyKey); }
			set
			{
				if (Size == value)
				{
					return;
				}

				SetPropertyValue(SizePropertyKey, value);
			}
		}

		public float ScaleX
		{
			get { return (float) GetPropertyValue(ScaleXPropertyKey); }
			set
			{
				if (ScaleX == value)
				{
					return;
				}

				SetPropertyValue(ScaleXPropertyKey, value);
			}
		}

		public float ScaleY
		{
			get { return (float) GetPropertyValue(ScaleYPropertyKey); }
			set
			{
				if (ScaleY == value)
				{
					return;
				}

				SetPropertyValue(ScaleYPropertyKey, value);
			}
		}

		public Color Color
		{
			get { return (Color) GetPropertyValue(ColorPropertyKey); }
			set
			{
				if (Color == value)
				{
					return;
				}

				SetPropertyValue(ColorPropertyKey, value);
			}
		}

		/// <summary>
		///     Gets or sets the thickness of the decoration lines (underline, strike-through).
		///     Defaults to 1/20 of the font Em height.
		/// </summary>
		public float DecorationThickness
		{
			get { return (float) GetPropertyValue(DecorationThicknessPropertyKey); }
			set
			{
				if (DecorationThickness == value)
				{
					return;
				}

				SetPropertyValue(DecorationThicknessPropertyKey, value);
			}
		}

		protected override object GetDefaultPropertyValue(int propertyKey)
		{
			switch (propertyKey)
			{
				case SizePropertyKey:
					return GFont.DefaultSize;
				case FacePropertyKey:
					return GFont.DefaultFace;
				case ColorPropertyKey:
					return Color.Black;
				case ScaleXPropertyKey:
					return 1F;
				case ScaleYPropertyKey:
					return 1F;
				case DecorationThicknessPropertyKey:
					return 0.05F;
			}

			return base.GetDefaultPropertyValue(propertyKey);
		}

		protected override void ParseAttribute(XmlAttribute attribute)
		{
			switch (attribute.Name.ToLower())
			{
				case FaceAttributeName:
					Face = attribute.Value;
					return;
				case ColorAttributeName:
					Color = ColorTranslator.FromHtml(attribute.Value);
					return;
				case SizeAttributeName:
					float size;
					if (float.TryParse(attribute.Value, out size))
					{
						Size = size;
					}
					return;
				case ScaleXAttributeName:
					float scaleX;
					if (float.TryParse(attribute.Value, out scaleX))
					{
						ScaleX = scaleX;
					}
					return;
				case ScaleYAttributeName:
					float scaleY;
					if (float.TryParse(attribute.Value, out scaleY))
					{
						ScaleY = scaleY;
					}
					return;
				case DecorationThicknessAttributeName:
					float thickness;
					if (float.TryParse(attribute.Value, out thickness))
					{
						DecorationThickness = thickness;
					}
					return;
			}

			base.ParseAttribute(attribute);
		}
	}
}