using System;

namespace VerseGlow.Common
{
	/// <summary>
	/// A disposable object.
	/// </summary>
	public interface IDisposableEx : IDisposable
	{
		/// <summary>
		/// Gets a value indicating whether the object has been disposed.
		/// </summary>
		bool IsDisposed { get; }
	}
}