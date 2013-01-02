using System;

namespace VerseFlow
{
	public interface ILog
	{
		void Error(Exception exception, string message);
	}
}