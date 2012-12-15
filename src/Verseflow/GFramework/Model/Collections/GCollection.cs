using System;
using System.Collections;
using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.Model.Collections
{
	public abstract class GCollection : ICollection
	{
		[NonSerialized] internal bool m_NestedSorting;
		[NonSerialized] internal bool m_PostProcessCollectionChange;
		[NonSerialized] internal bool m_PreProcessCollectionChange;
		[NonSerialized] internal int m_Sorting;
		[NonSerialized] internal int m_UpdateLock;

		protected GCollection()
		{
			m_PreProcessCollectionChange = true;
			m_PostProcessCollectionChange = true;
		}

		public bool IsBatchUpdating
		{
			get { return m_UpdateLock > 0; }
		}

		/// <summary>
		///     Determines whether the pre-processing methods (such as OnElementInserting) will be raised.
		/// </summary>
		public bool PreProcessCollectionChange
		{
			get { return m_PreProcessCollectionChange; }
			set { m_PreProcessCollectionChange = value; }
		}

		/// <summary>
		///     Determines whether the post-processing methods (such as OnElementInserted) will be raised.
		/// </summary>
		public bool PostProcessCollectionChange
		{
			get { return m_PostProcessCollectionChange; }
			set { m_PostProcessCollectionChange = value; }
		}

		/// <summary>
		///     Determines whether nested collections will be also sorted.
		/// </summary>
		public bool NestedSorting
		{
			get { return m_NestedSorting; }
			set { m_NestedSorting = value; }
		}

		public void CopyTo(Array array, int index)
		{
			CopyCore(array, index);
		}

		bool ICollection.IsSynchronized
		{
			get { return false; }
		}

		object ICollection.SyncRoot
		{
			get { return null; }
		}

		public virtual IEnumerator GetEnumerator()
		{
			return null;
		}

		/// <summary>
		///     Gets the count of the collection.
		/// </summary>
		public virtual int Count
		{
			get { return 0; }
		}

		public void BeginBatchUpdate()
		{
			m_UpdateLock++;
		}

		public void EndBatchUpdate()
		{
			m_UpdateLock--;
			m_UpdateLock = Math.Max(0, m_UpdateLock);

			if (m_UpdateLock > 0)
			{
				return;
			}

			Update();
		}

		public void BubbleSort()
		{
			PerformBubbleSort();
		}

		public void QuickSort()
		{
			PerformQuickSort();
		}

		public void MergeSort()
		{
			PerformMergeSort();
		}

		protected virtual EventResult OnElementAdding(object element)
		{
			return EventResult.Unspecified;
		}

		protected virtual void OnElementAdded(object element)
		{
		}

		protected virtual EventResult OnElementInserting(int index, object element)
		{
			return EventResult.Unspecified;
		}

		protected virtual void OnElementInserted(int index, object element)
		{
		}

		protected virtual EventResult OnElementRemoving(object element)
		{
			return EventResult.Unspecified;
		}

		protected virtual void OnElementRemoved(object element)
		{
		}

		protected virtual EventResult OnElementIndexChanging(object element, int oldIndex, int newIndex)
		{
			return EventResult.Unspecified;
		}

		protected virtual void OnElementIndexChanged(object element, int oldIndex, int newIndex)
		{
		}

		protected virtual EventResult OnClearing()
		{
			return EventResult.Unspecified;
		}

		protected virtual void OnCleared()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void CopyCore(Array array, int index)
		{
		}

		protected virtual void PerformBubbleSort()
		{
		}

		protected virtual void PerformQuickSort()
		{
		}

		protected virtual void PerformMergeSort()
		{
		}

		protected virtual int Compare(object element1, object element2)
		{
			if (element1 == element2)
			{
				return 0;
			}

			var el1 = element1 as IComparable;
			if (el1 != null)
			{
				return el1.CompareTo(element2);
			}

			return 0;
		}
	}
}