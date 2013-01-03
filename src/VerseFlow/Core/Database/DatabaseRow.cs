using System;
using System.Collections.Generic;
using System.Data;

namespace VerseFlow.Core.Database
{
	public class DatabaseRow
	{
		private readonly Dictionary<string, object> fields;

		public DatabaseRow() : this(new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)) { }

		public DatabaseRow(Dictionary<string, object> fields)
		{
			this.fields = fields;
		}

		public object this[string field]
		{
			get
			{
				try
				{
					return fields[field];
				}
				catch (KeyNotFoundException e)
				{
					throw new DataException(string.Format("Field [{0}] could not be found. Please check version of your database.", field), e);
				}
			}
		}

		public T As<T>(string field)
		{
			object obj = this[field];

			try
			{
				return (T)obj;
			}
			catch (InvalidCastException) { }

			if (obj == null || obj == DBNull.Value)
				return default(T);

			Type toType = typeof(T);

			try
			{
				if (toType.IsEnum)
				{
					Type ut = Enum.GetUnderlyingType(toType);

					if (ut != typeof(string))
						return (T)Enum.ToObject(toType, Convert.ChangeType(obj, ut));

					return (T)Enum.Parse(toType, obj.ToString());
				}

				return (T)Convert.ChangeType(obj, toType);
			}
			catch (Exception e)
			{
				throw new InvalidCastException(string.Format("Cannot cast [{0}] to type [{1}] for field [{2}].", obj, toType.Name, field), e);
			}
		}

		public bool IsNull(string fieldName)
		{
			object value;
			fields.TryGetValue(fieldName, out value);

			if (value == null)
				return true;

			return value == DBNull.Value;
		}

		public void Add(string field, object value)
		{
			fields.Add(field, value);
		}
	}
}