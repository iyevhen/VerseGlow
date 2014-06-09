using System;

namespace VerseFlow.Common
{
	/// <summary>
	/// An abstract object that is disposable. Used for proper implementation of the Disposal pattern.
	/// </summary>
	public abstract class DisposableObject : IDisposableEx
	{
		/// <summary>
		/// Gets a value indicating whether the object has been disposed.
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>
		/// Releases all resources currently held by the object.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases all resources currently held by the object.
		/// </summary>
		/// <param name="disposing"><see langword="True"/> if managed objects should be disposed, otherwise <see langword="false"/>.</param>
		protected virtual void Dispose(bool disposing)
		{
			IsDisposed = true;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// object is reclaimed by garbage collection.
		/// </summary>
		~DisposableObject()
		{
			Dispose(false);
		}
	}
}