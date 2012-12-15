using System;
using System.Drawing;

namespace VerseFlow.GFramework.Utils
{
	public static class GLayoutHelper
	{
		public static RectangleF NormalizeRect(RectangleF rect)
		{
			rect.Width = Math.Max(0, rect.Width);
			rect.Height = Math.Max(0, rect.Height);

			return rect;
		}

		public static Point NormalizePoint(Point pt)
		{
			pt.X = Math.Max(0, pt.X);
			pt.Y = Math.Max(0, pt.Y);

			return pt;
		}

		public static PointF NormalizePointF(PointF pt)
		{
			pt.X = Math.Max(0, pt.X);
			pt.Y = Math.Max(0, pt.Y);

			return pt;
		}

		public static bool TryParsePoint(string value, out Point result)
		{
			result = Point.Empty;
			try
			{
				value = value.Replace(" ", "");
				string[] xy = value.Split(',');
				int x = int.Parse(xy[0]);
				int y = int.Parse(xy[1]);

				result = new Point(x, y);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool TryParsePointF(string value, out PointF result)
		{
			result = PointF.Empty;
			try
			{
				value = value.Replace(" ", "");
				string[] xy = value.Split(',');
				float x = float.Parse(xy[0]);
				float y = float.Parse(xy[1]);
				result = new PointF(x, y);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
