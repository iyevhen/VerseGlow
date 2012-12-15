using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View.Text
{
    public class GTextViewLayoutContext
    {
	    internal GTextViewLayoutContext(GDeviceContext deviceContext)
        {
            DeviceContext = deviceContext;
        }

	    public GTextViewLayoutContextState GetState()
        {
            var state = new GTextViewLayoutContextState
	            {
		            Indent = Indent,
		            Right = Right,
		            Wrap = Wrap,
		            X = X,
		            Align = Align
	            };

		    return state;
        }

        public void SetState(GTextViewLayoutContextState state)
        {
            Indent = state.Indent;
            Right = state.Right;
            Wrap = state.Wrap;
            X = state.X;
            Align = state.Align;
        }

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
