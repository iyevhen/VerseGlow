using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace VerseFlow.Mvp.Core
{
	public class PresenterCommand : IPresenterCommand
	{
		readonly MethodInfo execute;
		readonly PropertyInfo canExecute;
		readonly IPresenter presenter;

		public event EventHandler CanExecuteChanged = delegate { };

		public PresenterCommand(IPresenter presenter, MethodInfo execute, PropertyInfo canExecute)
		{
			this.presenter = presenter;
			this.execute = execute;
			this.canExecute = canExecute;

			if (canExecute != null)
			{
				presenter.PropertyChanged += (s, e) =>
				{
					if (e.PropertyName == canExecute.Name)
						CanExecuteChanged(this, EventArgs.Empty);
				};
			}
		}

		public bool CanExecute()
		{
			return canExecute == null || (bool)canExecute.GetValue(presenter, null);
		}

		public void Execute(object parameter)
		{
			execute.Invoke(presenter, parameter == null ? null : new[] { parameter });
		}
	}
}