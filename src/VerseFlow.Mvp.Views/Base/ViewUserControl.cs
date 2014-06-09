using System;
using System.Windows.Forms;
using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp.Views.Base
{
	/// <summary>
	/// A <see cref="UserControl"/> that is managed by a presenter.
	/// </summary>
	/// <typeparam name="TPresenter">The type of the presenter.</typeparam>
	public class ViewUserControl<TPresenter> : UserControl, IView
		where TPresenter : class, IPresenter
	{
		private Control lastParent;
		private TPresenter presenter;

		/// <summary>
		/// Gets or sets the presenter that manages the control.
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
		/// Occurs when the view is first displayed.
		/// </summary>
		public event EventHandler Shown = delegate { };

		public virtual void RefreshBindings() { }

		/// <summary>
		/// Occurs when the control's Parent is changed.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);

			if ((lastParent == null) && (Parent != null))
				Shown(this, EventArgs.Empty);
			
			lastParent = Parent;
		}

		/// <summary>
		/// Called when a presenter is connected to the control.
		/// </summary>
		/// <param name="presenter">The presenter that was connected.</param>
		protected virtual void OnPresenterConnected(TPresenter presenter)
		{
		}

		/// <summary>
		/// Called when a presenter is disconnected from the control.
		/// </summary>
		/// <param name="presenter">The presenter that was disconnected.</param>
		protected virtual void OnPresenterDisconnected(TPresenter presenter)
		{
		}
	}
}