using System;
using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.Model.Nodes
{
	public abstract class GNode : GDisposableObject, IGEventListener, IComparable
	{
		[NonSerialized] internal GNode parent;
		[NonSerialized] internal GRootElement root;

		public GNode Parent
		{
			get { return parent; }
		}

		public GRootElement Root
		{
			get { return root; }
		}

		public int CompareTo(object obj)
		{
			var node = obj as GNode;
			if (node == null)
			{
				throw new ArgumentException("May compare to GNode instances only.");
			}

			return CompareCore(node);
		}

		void IGEventListener.PreviewEvent(GEventArgs e)
		{
			OnPreviewEvent(e);
		}

		public GNode GetAncestor(int level)
		{
			if (level <= 0)
			{
				return null;
			}

			GNode parent = this.parent;
			level--;

			while (level > 0)
			{
				parent = parent.parent;
				level--;
			}

			return parent;
		}

		protected override bool GetCanRaiseEvents()
		{
			if (root != null && root.initializeLock > 0)
			{
				return false;
			}

			return base.GetCanRaiseEvents();
		}

		protected internal virtual void OnParentChanged(GElement parent)
		{
			this.parent = parent;

			if (this.parent == null)
			{
				SetRoot(null);
			}
		}

		protected internal virtual void SetRoot(GRootElement root)
		{
			this.root = root;
		}

		protected internal virtual void BubbleEvent(GEventArgs e)
		{
			//no parent to bubble to
			if (parent == null)
			{
				return;
			}

			//bubble process has been explicitly canceled
			if ((e.m_Result & EventResult.Cancel) == EventResult.Cancel)
			{
				return;
			}

			e.m_Sender = this;
			parent.OnBubbleEvent(e);
		}

		protected internal virtual void TunnelEvent(GEventArgs e)
		{
		}

		protected internal virtual void OnBubbleEvent(GEventArgs e)
		{
			BubbleEvent(e);
		}

		protected internal virtual void OnTunnelEvent(GEventArgs e)
		{
			TunnelEvent(e);
		}

		protected virtual void OnPreviewEvent(GEventArgs e)
		{
		}

		protected virtual int CompareCore(GNode node)
		{
			return 0;
		}

		protected override void RaiseEvent(GEventArgs args)
		{
			if ((args.m_Propagation & EventPropagation.Bubble) == EventPropagation.Bubble)
			{
				//notify parent chain fo an event
				BubbleEvent(args);

				if ((args.m_Result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			if ((args.m_Propagation & EventPropagation.Tunnel) == EventPropagation.Tunnel)
			{
				//notify parent chain fo an event
				TunnelEvent(args);

				if ((args.m_Result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			base.RaiseEvent(args);
		}
	}
}