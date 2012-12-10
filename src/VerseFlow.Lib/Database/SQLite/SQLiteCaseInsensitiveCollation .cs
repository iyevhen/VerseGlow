using System.Data.SQLite;
using System.Globalization;

namespace VerseFlow.Lib.Database.SQLite
{
	/// <summary>
	/// This function adds case-insensitive sort feature to SQLite engine 
	/// To initialize, use SQLiteFunction.RegisterFunction() before all connections are open 
	/// </summary>
	[SQLiteFunction(FuncType = FunctionType.Collation, Name = "UTF8CI")]//UTF8CI which means UTF8 Case Insensitive 
	public class SqliteCaseInsensitiveCollation : SQLiteFunction
	{
		/// <summary>
		/// CultureInfo for comparing strings in case insensitive manner 
		/// </summary>
		private static readonly CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("ru-RU");

		/// <summary>
		/// Does case-insensitive comparison using _cultureInfo 
		/// </summary>
		/// <param name="x">Left string</param>
		/// <param name="y">Right string</param>
		/// <returns>The result of a comparison</returns>
		public override int Compare(string x, string y)
		{
			return string.Compare(x, y, cultureInfo, CompareOptions.IgnoreCase);
		}
	}
}