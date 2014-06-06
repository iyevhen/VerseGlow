using System.Windows.Forms;
using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp.Views.Base
{
	/// <summary>
	/// A <see cref="Form"/> that is managed by a presenter.
	/// </summary>
	/// <remarks>
	/// Types cannot inherit directly from this type, because the Visual Studio designer does not
	/// allow forms to inherit directly from generic types. Instead, forms must inherit from a
	/// shim type. For example:
	/// <code>
	/// public class ExampleForm : ExampleFormBase, IExampleView { ... }
	/// public class ExampleFormBase : ViewForm&lt;ExampleForm&gt; { ... }
	/// </code>
	/// </remarks>
	public class ViewForm<TPresenter> : Form, IView
		where TPresenter : class, IPresenter
	{
		private TPresenter presenter;

		/// <summary>
		/// Gets or sets the presenter that manages the form.
		/// </summary>
		public TPresenter Presenter
		{
			get { return presenter; }
			set
			{
				if (presenter != null)
					OnPresenterDisconnected(presenter);

				presenter = value;
				value.SetView(this);

				OnPresenterConnected(value);
			}
		}

		/// <summary>
		/// Called when a presenter is connected to the form.
		/// </summary>
		/// <param name="presenter">The presenter that was connected.</param>
		protected virtual void OnPresenterConnected(TPresenter presenter)
		{
		}

		/// <summary>
		/// Called when a presenter is disconnected from the form.
		/// </summary>
		/// <param name="presenter">The presenter that was disconnected.</param>
		protected virtual void OnPresenterDisconnected(TPresenter presenter)
		{
		}

		public virtual void RefreshBindings() { }
	}
}