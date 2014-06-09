using System;
using System.ComponentModel;

namespace VerseFlow.Mvp.Core
{
	/// <summary>
	/// An abstract definition of a presenter.
	/// </summary>
	public interface IPresenter : INotifyPropertyChanged, IDataErrorInfo, IDisposable
	{
		/// <summary>
		/// Injects the view into the presenter.
		/// </summary>
		/// <param name="view">The view to associate with the presenter.</param>
		void SetView(IView view);
		IView GetView();
	}
}