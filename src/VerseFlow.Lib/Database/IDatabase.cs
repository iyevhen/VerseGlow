using System;
using System.Collections.Generic;
using System.Data;

namespace VerseFlow.Lib.Database
{
	public interface IDatabase
	{
		DataRow ExecuteQueryOne(string sql, params object[] parameters);
		DataRow ExecuteOne(string table, string pkName, object pkValue);
		int GetRowCount(string table, string pkName, object pkValue);
		int GetRowCount(string table);
		T GetRowID<T>(string table);
		int ExecuteNonQuery(string sql);
		int ExecuteNonQuery(string sql, params object[] parameters);
		int ExecuteNonQuery(string[] sqlStrings);
		List<DataRow> ExecuteQuery(string sql);
		List<DataRow> ExecuteQuery(string sql, params object[] parameters);
		IEnumerable<DataRow> ExecuteReader(string sql, params object[] parameters);
		T ExecuteScalar<T>(string sql);
		T ExecuteScalar<T>(string sql, params object[] parameters);
		T ExecuteScalar<T>(IDbCommand cmd, params object[] parameters);
		IDisposable ExecuteInBulk(IDbConnection connection);
		int ExecuteNonQuery(IDbCommand command, params object[] parameters);
		IDbConnection GetNewConnection();
	}
}