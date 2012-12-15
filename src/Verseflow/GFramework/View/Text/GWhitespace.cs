using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;

namespace VerseFlow.GFramework.View.Text
{
	/// <summary>
	///     Defines a sequence of white spaces.
	/// </summary>
	public class GWhitespace : GWord
	{
		internal int m_Length;

		public GWhitespace(GTextStyle style, int length)
			: base(style)
		{
			m_Length = length;
		}

		public override bool IsWhitespace
		{
			get { return true; }
		}

		/// <summary>
		///     Gets the number of white spaces defined by this tab.
		/// </summary>
		public int Lenght
		{
			get { return m_Length; }
		}

		public override void Initialize(GDeviceContext context)
		{
			m_FontMetric = context.GetFontDeviceMetric(m_Style.m_Font);
			m_Metric = new GWordMetric
				{
					Size = new SizeF(m_Length*m_FontMetric.WhiteSpaceWidth, m_FontMetric.NativeFontHeight)
				};
			m_Metric.BlackBox = Size.Round(m_Metric.Size);
		}
	}
}