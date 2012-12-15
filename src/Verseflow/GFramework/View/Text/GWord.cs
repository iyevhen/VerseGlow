using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Drawing.Fonts;

namespace VerseFlow.GFramework.View.Text
{
    public class GWord
    {
        #region Constructor

        public GWord(GTextStyle style)
        {
            m_Style = style;
            m_Location = PointF.Empty;
        }

        public GWord(GTextStyle style, string text)
            : this(style)
        {
            m_Text = text;
        }

        #endregion

        #region Public Methods

        public virtual void Initialize(GDeviceContext context)
        {
            m_FontMetric = context.GetFontDeviceMetric(m_Style.m_Font);
            m_Metric = context.MeasureWord(this);
        }
        public virtual void Paint(GTextViewPaintContext context, RectangleF bounds)
        {
            context.deviceContext.PaintWord(this);
        }

        public override string ToString()
        {
            return m_Text;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the style for this instance.
        /// </summary>
        public string Text
        {
            get
            {
                return m_Text;
            }
        }
        public GWordMetric Metric
        {
            get
            {
                return m_Metric;
            }
        }
        public GFontDeviceMetric FontMetric
        {
            get
            {
                return m_FontMetric;
            }
        }
        public PointF Location
        {
            get
            {
                return m_Location;
            }
        }

        protected GTextStyle Style
        {
            get
            {
                return m_Style;
            }
        }

        public virtual bool IsWhitespace
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Fields

        internal GWordMetric m_Metric;
        internal PointF m_Location;
        internal GTextStyle m_Style;
        internal GFontDeviceMetric m_FontMetric;
        internal Bitmap m_ShadowBitmap;
        internal Bitmap m_PathBitmap;
        internal string m_Text;
        internal GTextLine m_Owner;

        #endregion
    }
}
