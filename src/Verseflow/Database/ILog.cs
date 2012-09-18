using System;

namespace Verseflow.Database
{
	public interface ILog
	{
		void Error(Exception exception, string message);
	}
}