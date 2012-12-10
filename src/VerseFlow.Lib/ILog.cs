using System;

namespace VerseFlow.Lib
{
	public interface ILog
	{
		void Error(Exception exception, string message);
	}
}