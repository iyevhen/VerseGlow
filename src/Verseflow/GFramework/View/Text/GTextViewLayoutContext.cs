using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View.Text
{
    /// <summary>
    /// Encapsulates layout information for a GTextView.
    /// </summary>
    public class GTextViewLayoutContext
    {
        #region Constructor

        internal GTextViewLayoutContext(GDeviceContext deviceContext)
        {
            DeviceContext = deviceContext;
        }

        #endregion

        #region Methods

        public GTextViewLayoutContextState Save()
        {
            GTextViewLayoutContextState state = new GTextViewLayoutContextState();

            state.Indent = Indent;
            state.Right = Right;
            state.Wrap = Wrap;
            state.X = X;
            state.Align = Align;

            return state;
        }

        public void Restore(GTextViewLayoutContextState state)
        {
            Indent = state.Indent;
            Right = state.Right;
            Wrap = state.Wrap;
            X = state.X;
            Align = state.Align;
        }

        #endregion

        #region Fields

        public GDeviceContext DeviceContext;
        public SizeF AvailableSize;
        public RectangleF ViewBounds;
        public float X;
        public float Y;
        public float Indent;
        public float Right;
        public TextWrap Wrap = TextWrap.Word;
        public ParagraphAlign Align = ParagraphAlign.Left;

        #endregion
    }
}
