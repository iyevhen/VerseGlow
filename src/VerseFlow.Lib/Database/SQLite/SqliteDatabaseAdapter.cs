using System;
using System.Data;
using System.Data.SQLite;

namespace VerseFlow.Lib.Database.SQLite
{
	// to get table info execute query "PRAGMA table_info(table_name)" where table_name - name of the interested table;

	internal class SqliteDatabaseAdapter : IDatabaseAdapter
	{
		private readonly string connectionString;

		public SqliteDatabaseAdapter(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException("filePath");

			connectionString = String.Format(@"Data Source={0};Version=3;", filePath);
		}

		public IDbConnection Connection()
		{
			return new SQLiteConnection(connectionString);
		}

		public IDataParameter Parameter(object value)
		{
			return new SQLiteParameter { Value = value };
		}

		public IDisposable InBulk(IDbConnection connection)
		{
			return new SqliteBulk(connection);
		}

		public string RowIDQuery(string table)
		{
			if (string.IsNullOrEmpty(table))
				throw new ArgumentNullException("table");

			return string.Format("SELECT ROWID FROM {0} ORDER BY ROWID DESC LIMIT 1", table);
		}

		class SqliteBulk : IDisposable
		{
			private readonly IDbConnection connection;

			public SqliteBulk(IDbConnection connection)
			{
				if (connection == null)
					throw new ArgumentNullException("connection");

				this.connection = connection;

				if (connection.State != ConnectionState.Open)
					connection.Open();

				var begin = connection.CreateCommand();
				begin.CommandText = "BEGIN";
				begin.ExecuteNonQuery();
			}

			public void Dispose()
			{
				var end = connection.CreateCommand();
				end.CommandText = "END";
				end.ExecuteNonQuery();
			}
		}
	}
}