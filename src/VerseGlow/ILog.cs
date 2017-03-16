using System;

namespace VerseGlow
{
	public interface ILog
	{
		void Error(Exception exception, string message);
	}
}