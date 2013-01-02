using System;

namespace VerseFlow.Core.Import
{
	public abstract class FlatFileLine
	{
		protected string[] values = new string[0];

		public abstract int ValuesCount { get; }

		public abstract void Parse(string line);

		public void SetValues(string[] values)
		{
			if (values == null)
				throw new ArgumentNullException("values");

			if (values.Length != ValuesCount)
			{
				throw new ArgumentException(string.Format("Incorrect values length. Expecting [{0}] but was [{1}].{3}{3}Values are:{3}{2}",
					this.values.Length,
					values.Length,
					string.Join(Environment.NewLine, values),
					Environment.NewLine));
			}

			this.values = values;
		}

		public string[] GetValues()
		{
			var result = new string[values.Length];
			values.CopyTo(result, 0);

			return result;
		}

		protected int GetInt(string intString)
		{
			int value;
			int.TryParse(intString, out value);
			return value;
		}
	}
}