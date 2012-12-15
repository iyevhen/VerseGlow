using System;

namespace VerseFlow.GFramework.Model
{
	public abstract class GDisposableObject : GObject, IDisposable
	{
		private const ulong StateDisposing = StateCanRaiseEvents << 1;
		private const ulong StateDisposed = StateDisposing << 1;
		private const int DisposedEventKey = GObjectLastEventKey + 1;
		internal const ulong StateHasUnmanagedResources = StateDisposed << 1;
		internal const int GDisposableObjectLastEventKey = DefaultEventRange*2;

		public bool Disposing
		{
			get { return bitStates[StateDisposing]; }
		}

		public bool IsDisposed
		{
			get { return bitStates[StateDisposed]; }
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~GDisposableObject()
		{
			if (bitStates[StateHasUnmanagedResources])
			{
				Dispose(false);
				GC.SuppressFinalize(this);
			}
		}

		public event EventHandler Disposed
		{
			add { Events.AddHandler(DisposedEventKey, value); }
			remove { Events.RemoveHandler(DisposedEventKey, value); }
		}

		protected void Dispose(bool disposing)
		{
			var eh = Events[DisposedEventKey] as EventHandler;

			if (eh != null)
				eh(this, EventArgs.Empty);

			bitStates[StateDisposing] = true;

			if (disposing)
			{
				DisposeManagedResources();
			}

			DisposeUnmanagedResources();

			bitStates[StateDisposing] = false;
			bitStates[StateDisposed] = true;
		}

		protected virtual void DisposeManagedResources()
		{
			if (events != null)
				events.Dispose();
		}

		protected virtual void DisposeUnmanagedResources()
		{
		}
	}
}