using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model.Collections;

namespace VerseFlow.GFramework.Model.Nodes
{
	/// <summary>
	///     The element is a node which may have child elements.
	/// </summary>
	public class GElement : GNode
	{
		protected GElement()
		{
			children = new GNodeCollection(this);
			attributes = new GAttributeCollection(this);
		}


		protected internal virtual void OnCollectionNotification(GEventArgs e)
		{
		}

		

		protected internal override void SetRoot(GRootElement root)
		{
			base.SetRoot(root);

			int count = children.Count;
			for (int i = 0; i < count; i++)
			{
				children[i].SetRoot(root);
			}
		}

		protected internal override void TunnelEvent(GEventArgs e)
		{
			base.TunnelEvent(e);

			e.m_Sender = this;
			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				GNode node = children[i];
				node.OnTunnelEvent(e);
			}
		}

		public GNodeCollection Children
		{
			get { return children; }
		}

		public GAttributeCollection Attributes
		{
			get { return attributes; }
		}

		public const int CollectionNotificationEventKey = GDisposableObjectLastEventKey + 1;

		internal const int GElementLastEventKey = CollectionNotificationEventKey + DefaultEventRange;
		internal readonly GNodeCollection children;
		private readonly GAttributeCollection attributes;
	}
}