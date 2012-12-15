using System;
using System.Collections;
using System.Collections.Generic;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Collections
{
	public abstract class GNodeCollectionBase : GCollection
	{
		[NonSerialized]
		internal IComparer<GNode> m_Comparer;
		[NonSerialized]
		internal List<GNode> gnodes;
		[NonSerialized]
		internal GElement ownerElement;

		public GNodeCollectionBase(GElement ownerElement)
		{
			ownerElement = ownerElement;
			gnodes = new List<GNode>();
		}

		internal GNodeCollectionBase()
		{
			gnodes = new List<GNode>();
			//update collection flags so no additional processing is performed
			m_PreProcessCollectionChange = false;
			m_PostProcessCollectionChange = false;
			m_UpdateLock++;
			m_Sorting++;
		}

		public GNode this[int index]
		{
			get { return gnodes[index]; }
		}

		public IComparer<GNode> Comparer
		{
			get { return m_Comparer; }
			set { m_Comparer = value; }
		}
		
		public int TotalCount
		{
			get
			{
				int thisCount = Count;
				int totalCount = thisCount;

				for (int i = 0; i < thisCount; i++)
				{
					var element = gnodes[i] as GElement;

					if (element != null)
						totalCount += element.children.TotalCount;
				}

				return totalCount;
			}
		}

		public override int Count
		{
			get { return gnodes.Count; }
		}

		public override IEnumerator GetEnumerator()
		{
			return new GNodeCollectionEnumerator(this);
		}

		public int IndexOf(GNode node)
		{
			return gnodes.IndexOf(node);
		}

		public bool Contains(GNode node)
		{
			return node != null && node.parent == ownerElement;
		}

		public GNode[] ToArray()
		{
			return gnodes.ToArray();
		}

		protected override EventResult OnElementAdding(object element)
		{
			var data = new GCollectionEventData(element, -1, -1, CollectionNotification.ElementAdding);
			var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

			ownerElement.OnCollectionNotification(e);

			return e.m_Result;
		}

		protected override void OnElementAdded(object element)
		{
			var node = (GNode)element;
			gnodes.Add(node);

			if (m_Sorting == 0)
			{
				//notify the node of being added
				node.OnParentChanged(ownerElement);
			}

			if (m_PostProcessCollectionChange)
			{
				var data = new GCollectionEventData(element, -1, -1, CollectionNotification.ElementAdded);
				var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

				ownerElement.OnCollectionNotification(e);
			}
		}

		protected override EventResult OnElementInserting(int index, object element)
		{
			var data = new GCollectionEventData(element, index, -1, CollectionNotification.ElementInserting);
			var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

			ownerElement.OnCollectionNotification(e);

			return e.m_Result;
		}

		protected override void OnElementInserted(int index, object element)
		{
			var node = (GNode)element;
			gnodes.Insert(index, node);

			if (m_Sorting == 0)
			{
				node.OnParentChanged(ownerElement);
			}

			if (m_PostProcessCollectionChange)
			{
				var data = new GCollectionEventData(element, index, -1, CollectionNotification.ElementInserted);
				var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

				ownerElement.OnCollectionNotification(e);
			}
		}

		protected override EventResult OnElementIndexChanging(object element, int oldIndex, int newIndex)
		{
			var data = new GCollectionEventData(element, oldIndex, newIndex, CollectionNotification.ElementIndexChanging);
			var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

			ownerElement.OnCollectionNotification(e);

			return e.m_Result;
		}

		protected override void OnElementIndexChanged(object element, int oldIndex, int newIndex)
		{
			var node = (GNode)element;
			GNode oldNode = this[newIndex];

			gnodes[newIndex] = node;
			gnodes[oldIndex] = oldNode;

			if (m_PostProcessCollectionChange)
			{
				var data = new GCollectionEventData(element, oldIndex, newIndex, CollectionNotification.ElementIndexChanged);
				var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

				ownerElement.OnCollectionNotification(e);
			}
		}

		protected override EventResult OnElementRemoving(object element)
		{
			var data = new GCollectionEventData(element, -1, -1, CollectionNotification.ElementRemoving);
			var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

			ownerElement.OnCollectionNotification(e);

			return e.m_Result;
		}

		protected override void OnElementRemoved(object element)
		{
			var node = (GNode)element;
			gnodes.Remove(node);

			if (m_Sorting == 0)
			{
				node.OnParentChanged(null);
			}

			if (m_PostProcessCollectionChange)
			{
				var data = new GCollectionEventData(element, -1, -1, CollectionNotification.ElementRemoved);
				var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

				ownerElement.OnCollectionNotification(e);
			}
		}

		protected override EventResult OnClearing()
		{
			var data = new GCollectionEventData(null, -1, -1, CollectionNotification.CollectionClearing);
			var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

			ownerElement.OnCollectionNotification(e);

			return e.m_Result;
		}

		protected override void OnCleared()
		{
			BeginBatchUpdate();

			gnodes.Clear();

			EndBatchUpdate();

			if (m_PostProcessCollectionChange)
			{
				var data = new GCollectionEventData(null, -1, -1, CollectionNotification.CollectionCleared);
				var e = new GEventArgs(this, data, GElement.CollectionNotificationEventKey, EventPropagation.None);

				ownerElement.OnCollectionNotification(e);
			}
		}

		protected override void CopyCore(Array array, int index)
		{
			int count = gnodes.Count;
			if (index < 0 || index > count - 1)
			{
				return;
			}

			int arrayIndex = 0;

			for (int i = index; i < count; i++)
			{
				array.SetValue(gnodes[index], arrayIndex);
				arrayIndex++;
			}
		}

		protected override void PerformBubbleSort()
		{
			int count = gnodes.Count;
			if (count <= 1)
			{
				return;
			}

			bool swapped;
			int iterations;
			int maxIterations = count - 1;

			do
			{
				swapped = false;
				iterations = 0;
				GNode node;
				GNode nextNode;

				for (int i = 0; i < count; i++)
				{
					if (iterations == maxIterations)
					{
						break;
					}

					node = gnodes[i];

					if (i < count - 1)
					{
						nextNode = gnodes[i + 1];
						if (Compare(node, nextNode) == 1)
						{
							//swap gnodes
							gnodes[i] = nextNode;
							gnodes[i + 1] = node;
							swapped = true;
						}
					}

					iterations++;
				}
			} while (swapped);
		}

		protected override void PerformQuickSort()
		{
			if (m_Comparer != null)
			{
				gnodes.Sort(m_Comparer);
			}
			else
			{
				gnodes.Sort();
			}
		}

		protected override void PerformMergeSort()
		{
			//m_FirstNode = MergeSort(m_FirstNode);
			//m_LastNode = this[m_Count - 1];
		}

		protected override int Compare(object element1, object element2)
		{
			if (m_Comparer != null)
			{
				return m_Comparer.Compare((GNode)element1, (GNode)element2);
			}

			return base.Compare(element1, element2);
		}

		internal void AddInternal(GNode node)
		{
			if (m_PreProcessCollectionChange)
			{
				EventResult result = OnElementAdding(node);
				if ((result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			OnElementAdded(node);
		}

		internal void AddRangeInternal(GNode[] nodes)
		{
			BeginBatchUpdate();

			int length = nodes.Length;
			for (int i = 0; i < length; i++)
			{
				AddInternal(nodes[i]);
			}

			EndBatchUpdate();
		}

		internal void InsertInternal(int index, GNode node)
		{
			if (index < 0 || index > gnodes.Count - 1)
			{
				return;
			}

			if (m_PreProcessCollectionChange)
			{
				EventResult result = OnElementInserting(index, node);
				if ((result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			OnElementInserted(index, node);
		}

		internal void InsertRangeInternal(int index, GNode[] nodes)
		{
			BeginBatchUpdate();

			int length = nodes.Length;
			for (int i = 0; i < length; i++)
			{
				InsertInternal(index + i, nodes[i]);
			}

			EndBatchUpdate();
		}

		internal void RemoveRangeInternal(int index, int count)
		{
			BeginBatchUpdate();

			for (int i = 0; i < count; i++)
			{
				RemoveAtInternal(index + i);
			}

			EndBatchUpdate();
		}

		internal void RemoveInternal(GNode node)
		{
			if (m_PreProcessCollectionChange)
			{
				EventResult result = OnElementRemoving(node);
				if ((result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			OnElementRemoved(node);
		}

		internal void RemoveAtInternal(int index)
		{
			GNode node = this[index];
			if (node != null)
			{
				RemoveInternal(node);
			}
		}

		internal void ClearInternal()
		{
			if (m_PreProcessCollectionChange)
			{
				EventResult result = OnClearing();
				if ((result & EventResult.Cancel) == EventResult.Cancel)
				{
					return;
				}
			}

			OnCleared();
		}
	}
}