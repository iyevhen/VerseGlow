using System;
using System.Collections.Generic;

namespace VerseGlow.Common
{
	public static class Extensions
	{
		public static TValue Find<TKey, TValue>(this Dictionary<TKey, TValue> target, TKey key)
		{
			TValue value;
			return target.TryGetValue(key, out value) ? value : default(TValue);
		}

		public static Int32 TryGetInt32(this string text)
		{
			Int32 number;
			return Int32.TryParse(text, out number) ? number : 0;
		}
	}
}