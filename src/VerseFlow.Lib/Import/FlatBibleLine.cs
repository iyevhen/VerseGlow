using System;
using System.Globalization;

namespace VerseFlow.Lib.Import
{
	public class FlatBibleLine : FlatFileLine
	{
		public FlatBibleLine()
		{
			values = new string[4];
		}

		public string BookName
		{
			get { return values[0]; }
			set { values[0] = value; }
		}

		public int ChapterNumber
		{
			get { return GetInt(values[1]); }
			set
			{
				if (value <= 0)
					throw new ArgumentException("Chapter number cannot be less or equals zero");

				values[1] = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public int VerseNumber
		{
			get { return GetInt(values[2]); }
			set
			{
				if (value <= 0)
					throw new ArgumentException("Verse number cannot be less or equals zero");

				values[2] = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public string VerseText
		{
			get { return values[3]; }
			set { values[3] = value; }
		}

		public override int ValuesCount
		{
			get { return values.Length; }
		}
	}
}