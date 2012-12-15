namespace VerseFlow.GFramework.Drawing.Fonts
{
    public class GFont : GDrawingAttribute
    {
        #region Constructor

        public GFont()
        {
        }
        public GFont(GFont prototype)
        {
            Face = prototype.Face;
            Size = prototype.Size;
            Bold = prototype.Bold;
            Italic = prototype.Italic;
            Underline = prototype.Underline;
            StrikeThrough = prototype.StrikeThrough;
            DecorationThickness = prototype.DecorationThickness;
            UnderlinePosition = prototype.UnderlinePosition;
        }
        public GFont(string face, float sizeInPoints)
        {
            Face = face;
            Size = sizeInPoints;
        }

        #endregion

        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case FacePropertyKey:
                    return DefaultFace;
                case SizePropertyKey:
                    return 8.25F;
                case BoldPropertyKey:
                    return false;
                case ItalicPropertyKey:
                    return false;
                case UnderlinePropertyKey:
                    return false;
                case StrikeThroughPropertyKey:
                    return false;
                case DecorationThicknessPropertyKey:
                    return 0.05F;
                case UnderlinePositionPropertyKey:
                    return 0.1F;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Properties

        public string Face
        {
            get
            {
                return GetPropertyValue(FacePropertyKey) as string;
            }
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
            get
            {
                return (float)GetPropertyValue(SizePropertyKey);
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                if (Size == value)
                {
                    return;
                }

                SetPropertyValue(SizePropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the thickness of decoration lines (underline, strike-through).
        /// Defaults to 1/20 of the font's EmHeight.
        /// </summary>
        public float DecorationThickness
        {
            get
            {
                return (float)GetPropertyValue(DecorationThicknessPropertyKey);
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                if (DecorationThickness == value)
                {
                    return;
                }

                SetPropertyValue(DecorationThicknessPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the offest from the baseline, where the underline decoration is displayed.
        /// Defaults to 1/10 of the font's EmHeight.
        /// </summary>
        public float UnderlinePosition
        {
            get
            {
                return (float)GetPropertyValue(UnderlinePositionPropertyKey);
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                if (UnderlinePosition == value)
                {
                    return;
                }

                SetPropertyValue(UnderlinePositionPropertyKey, value);
            }
        }
        public bool Bold
        {
            get
            {
                return (bool)GetPropertyValue(BoldPropertyKey);
            }
            set
            {
                if (Bold == value)
                {
                    return;
                }

                SetPropertyValue(BoldPropertyKey, value);
            }
        }
        public bool Italic
        {
            get
            {
                return (bool)GetPropertyValue(ItalicPropertyKey);
            }
            set
            {
                if (Italic == value)
                {
                    return;
                }

                SetPropertyValue(ItalicPropertyKey, value);
            }
        }
        public bool Underline
        {
            get
            {
                return (bool)GetPropertyValue(UnderlinePropertyKey);
            }
            set
            {
                if (Underline == value)
                {
                    return;
                }

                SetPropertyValue(UnderlinePropertyKey, value);
            }
        }
        public bool StrikeThrough
        {
            get
            {
                return (bool)GetPropertyValue(StrikeThroughPropertyKey);
            }
            set
            {
                if (StrikeThrough == value)
                {
                    return;
                }

                SetPropertyValue(StrikeThroughPropertyKey, value);
            }
        }

        #endregion

        #region Property Constants

        public const int FacePropertyKey = 1;
        public const int SizePropertyKey = FacePropertyKey + 1;
        public const int BoldPropertyKey = SizePropertyKey + 1;
        public const int ItalicPropertyKey = BoldPropertyKey + 1;
        public const int UnderlinePropertyKey = ItalicPropertyKey + 1;
        public const int StrikeThroughPropertyKey = UnderlinePropertyKey + 1;
        public const int DecorationThicknessPropertyKey = StrikeThroughPropertyKey + 1;
        public const int UnderlinePositionPropertyKey = DecorationThicknessPropertyKey + 1;

        #endregion

        #region Static

        public static readonly float DefaultSize = 8.25F;
        public static readonly string DefaultFace = "Tahoma";

        #endregion
    }
}
