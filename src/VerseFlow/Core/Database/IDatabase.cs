using System;
using System.Collections.Generic;
using System.Data;

namespace VerseFlow.Core.Database
{
	public interface IDatabase
	{
		DatabaseRow ExecuteQueryOne(string sql, params object[] parameters);
		DatabaseRow ExecuteOne(string table, string pkName, object pkValue);
		int GetRowCount(string table, string pkName, object pkValue);
		int GetRowCount(string table);
		T GetRowID<T>(string table);
		int ExecuteNonQuery(string sql);
		int ExecuteNonQuery(string sql, params object[] parameters);
		int ExecuteNonQuery(string[] sqlStrings);
		List<DatabaseRow> ExecuteQuery(string sql);
		List<DatabaseRow> ExecuteQuery(string sql, params object[] parameters);
		IEnumerable<DatabaseRow> ExecuteReader(string sql, params object[] parameters);
		T ExecuteScalar<T>(string sql);
		T ExecuteScalar<T>(string sql, params object[] parameters);
		T ExecuteScalar<T>(IDbCommand cmd, params object[] parameters);
		IDisposable ExecuteInBulk(IDbConnection connection);
		int ExecuteNonQuery(IDbCommand command, params object[] parameters);
		IDbConnection GetNewConnection();
	}
}