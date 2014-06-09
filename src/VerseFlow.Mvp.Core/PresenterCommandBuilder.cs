using System;
using System.Linq.Expressions;

namespace VerseFlow.Mvp.Core
{
	public class PresenterCommandBuilder
	{
		readonly IPresenter presenter;

		public PresenterCommandBuilder(IPresenter presenter)
		{
			this.presenter = presenter;
		}

		public IPresenterCommand For(Expression<Action> expression)
		{
			var methodCall = (MethodCallExpression)expression.Body;

			return new PresenterCommand(
				presenter,
				methodCall.Method,
				presenter.GetType().GetProperty("Can" + methodCall.Method.Name));
		}
	}

	/*
	 * void InitializeCommands()
		{
			var build = new ViewModelCommandBuilder(this);

			CreateCommand = build.For(()=> Create());
			DeleteCommand = build.For(()=> Delete());			
		}

		public ICommand CreateCommand
		{
			get; private set;
		}		

		public ICommand DeleteCommand
		{
			get; private set;
		}
	  
		public bool CanCreate
		{
			get { return !string.IsNullOrEmpty(Description); }
		}
	  
		public bool CanDelete
		{
			get { return Selected != null; }
		}
	 * 
	 * public void Create()
	 * {
	 * }
	 */
}