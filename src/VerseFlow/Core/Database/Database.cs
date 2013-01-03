using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VerseFlow.Core.Database
{
	public class Database : IDatabase
	{
		private readonly IDatabaseAdapter adapter;
		//		private static readonly ILog log = App.Log;
		private static readonly ILog log = null;

		public Database(IDatabaseAdapter adapter)
		{
			if (adapter == null)
				throw new ArgumentNullException("adapter");

			this.adapter = adapter;
		}

		public int ExecuteNonQuery(IDbCommand command, params object[] parameters)
		{
			if (command == null)
				throw new ArgumentNullException("command");

			try
			{
				if (parameters != null)
				{
					command.Parameters.Clear();

					foreach (object value in parameters)
					{
						command.Parameters.Add(adapter.Parameter(value));
					}
				}

				return command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				log.Error(e, FormatErrorMessage(command.CommandText, parameters));
				throw;
			}
		}

		public IDbConnection GetNewConnection()
		{
			return adapter.Connection();
		}

		public IDisposable ExecuteInBulk(IDbConnection connection)
		{
			return adapter.InBulk(connection);
		}

		public DatabaseRow ExecuteQueryOne(string sql, params object[] parameters)
		{
			List<DatabaseRow> rows = ExecuteQueryImpl(sql, true, parameters);
			return rows.Count > 0 ? rows[0] : null;
		}

		public DatabaseRow ExecuteOne(string table, string pkName, object pkValue)
		{
			string sql = string.Format("SELECT * FROM {0} WHERE {1} = ?", table, pkName);
			List<DatabaseRow> rows = ExecuteQueryImpl(sql, true, pkValue);
			return rows.Count > 0 ? rows[0] : null;
		}

		public int GetRowCount(string table, string pkName, object pkValue)
		{
			return ExecuteScalar<int>(string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = ?", table, pkName), pkValue);
		}

		public int GetRowCount(string table)
		{
			return ExecuteScalar<int>(string.Format("SELECT COUNT(*) FROM {0}", table));
		}

		public T GetRowID<T>(string table)
		{
			return ExecuteScalar<T>(adapter.RowIDQuery(table));
		}

		public int ExecuteNonQuery(string sql)
		{
			return ExecuteNonQuery(sql, null);
		}

		public int ExecuteNonQuery(string[] sqlStrings)
		{
			int i = 0;

			using (IDbConnection connection = GetNewConnection())
			{
				try
				{
					connection.Open();
				}
				catch (Exception e)
				{
					log.Error(e, "Cannot open connection");
					throw;
				}

				foreach (string t in sqlStrings)
				{
					try
					{
						IDbCommand command = connection.CreateCommand();
						command.CommandText = t;
						i = command.ExecuteNonQuery();
					}
					catch (Exception e)
					{
						log.Error(e, string.Format(@"SQL = [{0}]", t));
					}
				}
			}

			return i;
		}

		public int ExecuteNonQuery(string sql, params object[] parameters)
		{
			try
			{
				using (IDbConnection connection = GetNewConnection())
				{
					IDbCommand command = connection.CreateCommand();
					command.CommandText = sql;

					if (parameters != null)
					{
						foreach (object value in parameters)
						{
							command.Parameters.Add(adapter.Parameter(value));
						}
					}

					connection.Open();
					return command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				log.Error(e, FormatErrorMessage(sql, parameters));
				throw;
			}
		}

		public List<DatabaseRow> ExecuteQuery(string sql)
		{
			return ExecuteQueryImpl(sql, false, null);
		}

		public List<DatabaseRow> ExecuteQuery(string sql, params object[] parameters)
		{
			return ExecuteQueryImpl(sql, false, parameters);
		}

		public T ExecuteScalar<T>(string sql)
		{
			return ExecuteScalar<T>(sql, null);
		}

		public T ExecuteScalar<T>(IDbCommand command, params object[] parameters)
		{
			if (command == null)
				throw new ArgumentNullException("command");

			try
			{
				command.Parameters.Clear();

				if (parameters != null)
				{
					foreach (object value in parameters)
					{
						command.Parameters.Add(adapter.Parameter(value));
					}
				}

				return ConvertObj<T>(command.ExecuteScalar());
			}
			catch (Exception e)
			{
				log.Error(e, FormatErrorMessage(command.CommandText, parameters));
				throw;
			}
		}

		public T ExecuteScalar<T>(string sql, params object[] parameters)
		{
			using (IDbConnection connection = GetNewConnection())
			{
				IDbCommand command = connection.CreateCommand();
				command.CommandText = sql;

				if (parameters != null)
				{
					foreach (object value in parameters)
					{
						command.Parameters.Add(adapter.Parameter(value));
					}
				}

				try
				{
					connection.Open();
					return ConvertObj<T>(command.ExecuteScalar());
				}
				catch (Exception e)
				{
					log.Error(e, FormatErrorMessage(sql, parameters));
					throw;
				}
			}
		}

		private T ConvertObj<T>(object scalar)
		{
			if (scalar == null || scalar == DBNull.Value)
				return default(T);

			try
			{
				return (T)Convert.ChangeType(scalar, typeof(T));
			}
			catch (Exception e)
			{
				log.Error(e, string.Format("Could not cast value [{0}] to type [{1}]", scalar, typeof(T).Name));
			}

			return default(T);
		}

		public IEnumerable<DatabaseRow> ExecuteReader(string sql, params object[] parameters)
		{
			using (IDbConnection connection = GetNewConnection())
			{
				IDbCommand command = connection.CreateCommand();
				command.CommandText = sql;

				if (parameters != null)
				{
					foreach (object value in parameters)
					{
						command.Parameters.Add(adapter.Parameter(value));
					}
				}

				connection.Open();

				using (IDataReader reader = command.ExecuteReader())
				{
					if (reader == null)
						yield break;

					while (reader.Read())
					{
						var fields = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
						var t = new DataTable();


						for (int i = 0; i < reader.FieldCount; i++)
						{
							object value = reader[i];
							string name = reader.GetName(i);


							fields.Add(name, value);
						}

						yield break;
					}
				}
			}
		}

		private List<DatabaseRow> ExecuteQueryImpl(string sql, bool topOne, params object[] parameters)
		{
			var rows = new List<DatabaseRow>();

			try
			{
				using (IDbConnection connection = GetNewConnection())
				{
					IDbCommand command = connection.CreateCommand();
					command.CommandText = sql;

					if (parameters != null)
					{
						foreach (object value in parameters)
						{
							command.Parameters.Add(adapter.Parameter(value));
						}
					}

					connection.Open();

					using (IDataReader reader = command.ExecuteReader())
					{
						if (reader == null)
							return rows;

						while (reader.Read())
						{
							var row = new DatabaseRow();
							rows.Add(row);

							for (int i = 0; i < reader.FieldCount; i++)
							{
								object value = reader[i];
								string name = reader.GetName(i);
								row.Add(name, value);
							}

							if (topOne)
								return rows;
						}
					}
				}
			}
			catch (Exception e)
			{
				log.Error(e, FormatErrorMessage(sql, parameters));
				throw;
			}

			return rows;
		}

		private string FormatErrorMessage(string sql, object[] parameters)
		{
			var sb = new StringBuilder();
			sb.AppendFormat("SQL = '{0}'. Parameters = ", sql);

			if (parameters == null || parameters.Length == 0)
			{
				sb.Append("NONE");
				return sb.ToString();
			}

			foreach (object param in parameters)
			{
				sb.AppendFormat("'{0}'=[{1}]; ", param.GetType().Name, param);
			}

			return sb.ToString();
		}
	}
}