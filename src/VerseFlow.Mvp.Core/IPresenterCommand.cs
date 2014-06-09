using System;

namespace VerseFlow.Mvp.Core
{
	public interface IPresenterCommand
	{
		event EventHandler CanExecuteChanged;
		bool CanExecute();
		void Execute(object parameter);
	}
}