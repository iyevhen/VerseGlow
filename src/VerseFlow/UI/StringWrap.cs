using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VerseFlow.UI
{
	/// <summary>
	/// Class that can automatically wrap a given string.
	/// </summary>
	public class StringWrap
	{
		/// <summary>
		/// List of characters to break a string around.  A <c>char</c> key points to an
		/// <c>int</c> weight.  Higher weights indicate a higher preference to break at
		/// that character.
		/// </summary>
		private readonly Hashtable breakable = new Hashtable();

		private readonly StringFormat format;

		/// <summary>
		/// Class that can automatically wrap a given string.
		/// </summary>
		public StringWrap()
		{
			breakable[' '] = 10;
			breakable[','] = 20;
			breakable[';'] = 30;
			breakable['.'] = 40;
			breakable['?'] = 40;

			format = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};
		}

		public GraphicsPath GeneratePath(string text, RectangleF dest)
		{
			// draw a default path of a given size 
			var p = new GraphicsPath();
			p.AddString(text, FontFamily.GenericSansSerif, (int) FontStyle.Regular, 24.0f, new Point(0, 0), format);
//			p.AddString(text, FontFamily.GenericSansSerif, (int)FontStyle.Regular, 24.0f, dest, format);

			// calculate best ratio for stretching
			RectangleF bound = p.GetBounds();

			float ratio = Math.Min((dest.Width / bound.Width) * 0.95f, (dest.Height / bound.Height) * 0.9f);

			// scale to that ratio and translate into corner
			var m = new Matrix();
			m.Scale(ratio, ratio);
			m.Translate(-bound.Left, -bound.Top);
			p.Transform(m);
			m.Reset();

			return p;
		}

		/// <summary>
		/// Perform an automatic wrap given text, a target ratio, and a font ratio.
		/// </summary>
		/// <param name="text">Text to automatically wrap.</param>
		/// <param name="targetRatio">Ratio (Height / Width) of the target area
		/// for this text.</param>
		/// <param name="fontRatio">Average ratio (Height / Width) of a single
		/// character.</param>
		/// <returns>Automatically wrapped text.</returns>
		public string PerformWrap(string text, float targetRatio, float fontRatio)
		{
			string wrap = "";
			text = Cleanse(text);

			int rows = (int) Math.Sqrt(targetRatio * text.Length / fontRatio),
			    cols = text.Length / rows,
			    start = cols,
			    index = 0,
			    last;

			for (int i = 0; i < rows - 1; i++)
			{
				last = index;
				index = BestBreak(text, start, cols * 2);
				wrap += text.Substring(last, index - last).Trim() + "\n";
				start = index + cols;
			}

			wrap += text.Substring(index);
			return wrap;
		}

		/// <summary>
		/// Cleanse the given text from duplicate (two or more in a row) characters, as
		/// specified by <c>Breakable</c>.  Will also remove all existing newlines.
		/// </summary>
		/// <param name="text">Text to be cleansed.</param>
		/// <returns>Cleansed text.</returns>
		protected string Cleanse(string text)
		{
			text = text.Replace('\n', ' ');
			string find, replace;

			foreach (char c in breakable.Keys)
			{
				find = new string(c, 2);
				replace = new string(c, 1);

				while (text.IndexOf(find) != -1)
				{
					text = text.Replace(find, replace);
				}
			}

			return text;
		}

		/// <summary>
		/// Find the best place to break text given a starting index and a search radius.
		/// </summary>
		/// <param name="text">Full text to search through.</param>
		/// <param name="start">Index in string to start searching at.  Will be used
		/// as the center of the radius.</param>
		/// <param name="radius">Radius (in characters) to search around the given
		/// starting index.</param>
		/// <returns>Optimal index to break the text at.</returns>
		protected int BestBreak(string text, int start, int radius)
		{
			int bestIndex = start;
			float bestWeight = 0, examWeight;

			radius = Math.Min(Math.Min(start + radius, text.Length - 1) - start, start - Math.Max(start - radius, 0));

			for (int i = start - radius; i <= start + radius; i++)
			{
				object o = breakable[text[i]];
				if (o == null)
					continue;

				examWeight = (int) o / (float) Math.Abs(start - i);

				if (examWeight > bestWeight)
				{
					bestIndex = i;
					bestWeight = examWeight;
				}
			}

			return Math.Min(bestIndex + 1, text.Length - 1);
		}
	}
}