using System;

namespace VerseFlow.Mvp.Core
{
	/// <summary>
	/// An abstract definition of a view.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Occurs when the view is first displayed.
		/// </summary>
		event EventHandler Shown;
		void Dispose();
	}
}