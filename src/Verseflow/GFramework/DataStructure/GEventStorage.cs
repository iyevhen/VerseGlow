using System;
using System.Collections.Generic;

namespace VerseFlow.GFramework.DataStructure
{
	public class GEventStorage : IDisposable
	{
		private readonly LinkedList<Entry> entries;

		public GEventStorage()
		{
			entries = new LinkedList<Entry>();
		}

		public Delegate this[int key]
		{
			get
			{
				Entry entry = FindEntry(key);
				if (entry != null)
				{
					return entry.Value;
				}

				return null;
			}
			set
			{
				Entry entry = FindEntry(key);
				if (entry != null)
				{
					entry.Value = value;
				}
				else
				{
					entry = new Entry(key, value);
					entries.AddLast(entry);
				}
			}
		}

		public void Dispose()
		{
			foreach (Entry entry in entries)
			{
				Delegate[] delegateList = entry.Value.GetInvocationList();
				foreach (Delegate del in delegateList)
				{
					entry.Value = Delegate.Remove(entry.Value, del);
				}
				entry.Value = null;
			}

			entries.Clear();
		}

		public void AddHandler(int key, Delegate value)
		{
			Entry entry = FindEntry(key);
			if (entry != null)
			{
				entry.Value = Delegate.Combine(entry.Value, value);
			}
			else
			{
				entry = new Entry(key, value);
				entries.AddLast(entry);
			}
		}

		public void RemoveHandler(int key, Delegate value)
		{
			Entry entry = FindEntry(key);
			if (entry != null)
			{
				entry.Value = Delegate.Remove(entry.Value, value);
			}
		}

		private Entry FindEntry(int key)
		{
			foreach (Entry entry in entries)
			{
				if (entry.Key == key)
				{
					return entry;
				}
			}

			return null;
		}

		private class Entry
		{
			public readonly int Key;
			public Delegate Value;

			public Entry(int key, Delegate value)
			{
				Key = key;
				Value = value;
			}
		}
	}
}