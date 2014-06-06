using System;
using System.Collections.Generic;
using System.ComponentModel;
using VerseFlow.Common;

namespace VerseFlow.Mvp.Core
{
	public class Errors : IDataErrorInfo
	{
		private readonly Dictionary<string, string> errors = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		public string this[string columnName]
		{
			get { return errors.Find(columnName); }
			set { errors[columnName] = value; }
		}

		public void Clear()
		{
			errors.Clear();
		}

		public string Error
		{
			get { return string.Empty; }
		}
	}
}