using System;
using System.Runtime.Serialization;

namespace FreePresenter.Core
{
	[Serializable]
	public class FreePresenterException : ApplicationException
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public FreePresenterException() {}

		public FreePresenterException(string message) : base(message) {}

		public FreePresenterException(string message, Exception inner) : base(message, inner) {}

		protected FreePresenterException(
			SerializationInfo info,
			StreamingContext context) : base(info, context) {}
	}
}