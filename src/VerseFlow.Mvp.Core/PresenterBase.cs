using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;
using VerseFlow.Common;

namespace VerseFlow.Mvp.Core
{
	/// <summary>
	///     The baseline definition of a presenter.
	/// </summary>
	/// <typeparam name="TView">The type of the view that the presenter manages.</typeparam>
	public abstract class PresenterBase<TView> : DisposableObject, IPresenter
		where TView : class, IView
	{
		protected readonly Errors errors = new Errors();
		protected readonly SynchronizationContext syncContext;
		private TView view;

		protected PresenterBase()
		{
			syncContext = SynchronizationContext.Current;
		}

		#region IPresenter Members

		public event PropertyChangedEventHandler PropertyChanged;

		void IPresenter.SetView(IView view)
		{
			var strongView = view as TView;

			if (strongView == null)
				throw new ArgumentException("view");

			View = strongView;
		}

		IView IPresenter.GetView()
		{
			return view;
		}

		public string this[string columnName]
		{
			get { return errors[columnName]; }
		}

		public string Error
		{
			get { return errors.Error; }
		}

		#endregion

		/// <summary>
		///     Releases all resources currently held by the object.
		/// </summary>
		/// <param name="disposing">
		///     <see langword="True" /> if managed objects should be disposed, otherwise
		///     <see langword="false" />.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && !IsDisposed)
			{
				if (view != null)
				{
					view.Dispose();
					view = null;
				}
			}

			base.Dispose(disposing);
		}

		/// <summary>
		///     Called when a view is connected to the presenter.
		/// </summary>
		/// <param name="v"></param>
		protected virtual void OnViewConnected(TView v)
		{
			v.Shown += FireViewShown;
		}

		/// <summary>
		///     Called when a view is disconnected from the presenter.
		/// </summary>
		/// <param name="v"></param>
		protected virtual void OnViewDisconnected(TView v)
		{
			v.Shown -= FireViewShown;
		}

		/// <summary>
		///     Called when the view is first displayed.
		/// </summary>
		protected virtual void OnViewShown()
		{
		}

		private void FireViewShown(object sender, EventArgs e)
		{
			OnViewShown();
		}

		protected void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
		{
			string propertyName = PropertyName.Get(property);

			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				if (syncContext != null)
				{
					syncContext.Post(delegate { handler(this, new PropertyChangedEventArgs(propertyName)); }, null);
				}
				else
				{
					handler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}

		/// <summary>
		///     Gets the views that the presenter should manage.
		/// </summary>
		/// <summary>
		///     Gets or sets the view that the presenter should manage.
		/// </summary>
		public TView View
		{
			get { return view; }
			set
			{
				if (view != null)
					OnViewDisconnected(view);

				view = value;

				if (value != null)
					OnViewConnected(value);
			}
		}
	}
}