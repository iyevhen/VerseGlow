using System.Drawing;

namespace VerseFlow.GFramework.Drawing.Pens
{
	public class GPen : GDrawingAttribute
	{
		private Color m_Color;
		private float m_Width;

		public GPen()
		{
		}

		public GPen(Color color)
		{
			m_Color = color;
		}

		public GPen(Color color, float width)
			: this(color)
		{
			m_Width = width;
		}

		public Color Color
		{
			get { return m_Color; }
			set
			{
				if (m_Color == value)
				{
					return;
				}

				m_Color = value;
			}
		}

		public float Width
		{
			get { return m_Width; }
			set
			{
				if (m_Width == value)
				{
					return;
				}

				m_Width = value;
			}
		}

		public override int GetHashCode()
		{
			return m_Color.GetHashCode() + m_Width.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var pen = obj as GPen;
			if (pen == null)
			{
				return false;
			}

			return pen.m_Width == m_Width && pen.m_Color == m_Color;
		}
	}
}