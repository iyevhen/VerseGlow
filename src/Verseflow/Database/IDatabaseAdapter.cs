using System;
using System.Data;

namespace SOSOnlineBackup.Common.DB
{
	public interface IDatabaseAdapter
	{
		IDbConnection Connection();
		IDataParameter Parameter(object value);
		IDisposable InBulk(IDbConnection connection);
		string RowIDQuery(string table);
	}
}