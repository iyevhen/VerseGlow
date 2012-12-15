using System;

namespace VerseFlow.GFramework.DataStructure
{
	public class GPropertyStorage
	{
		private static int m_CurrKey;
		private Entry[] m_Entries;

		static GPropertyStorage()
		{
			m_CurrKey = 0;
		}

		public bool ContainsEntry(int key)
		{
			bool found;
			GetEntry(key, out found);

			return found;
		}

		public object GetEntry(int key)
		{
			bool found;
			return GetEntry(key, out found);
		}

		public object GetEntry(int key, out bool found)
		{
			int objectIndex;
			short element;
			short entryKey = SplitKey(key, out element);
			found = false;

			bool locate = LocateObject(entryKey, out objectIndex);
			if (locate == false)
			{
				return null;
			}

			if (((1 << element) & m_Entries[objectIndex].Mask) == 0)
			{
				return null;
			}

			found = true;
			switch (element)
			{
				case 0:
					return m_Entries[objectIndex].Val1;

				case 1:
					return m_Entries[objectIndex].Val2;

				case 2:
					return m_Entries[objectIndex].Val3;

				case 3:
					return m_Entries[objectIndex].Val4;
			}

			return null;
		}

		public void SetEntry(int key, object value)
		{
			int objectIndex;
			short element;
			short entryKey = SplitKey(key, out element);

			if (LocateObject(entryKey, out objectIndex) == false)
			{
				if (m_Entries == null)
				{
					m_Entries = new Entry[1];
				}
				else
				{
					var destArray = new Entry[m_Entries.Length + 1];
					if (objectIndex > 0)
					{
						Array.Copy(m_Entries, 0, destArray, 0, objectIndex);
					}
					if ((m_Entries.Length - objectIndex) > 0)
					{
						Array.Copy(m_Entries, objectIndex, destArray, objectIndex + 1, m_Entries.Length - objectIndex);
					}
					m_Entries = destArray;
				}

				m_Entries[objectIndex].Key = entryKey;
			}

			switch (element)
			{
				case 0:
					m_Entries[objectIndex].Val1 = value;
					break;

				case 1:
					m_Entries[objectIndex].Val2 = value;
					break;

				case 2:
					m_Entries[objectIndex].Val3 = value;
					break;

				case 3:
					m_Entries[objectIndex].Val4 = value;
					break;
			}

			m_Entries[objectIndex].Mask = (short) (((ushort) m_Entries[objectIndex].Mask) | ((1) << element));
		}

		public void RemoveEntry(int key)
		{
			int objectIndex;
			short element;

			short entryKey = SplitKey(key, out element);
			bool hasObject = LocateObject(entryKey, out objectIndex);

			if (hasObject)
			{
				bool hasMask = ((1 << element) & m_Entries[objectIndex].Mask) != 0;
				hasObject = hasObject && hasMask;
			}

			if (hasObject == false)
			{
				return;
			}

			short mask = m_Entries[objectIndex].Mask;
			mask = (short) (mask & ~((short) ((1) << element)));
			m_Entries[objectIndex].Mask = mask;

			if (mask == 0)
			{
				int length = m_Entries.Length;
				if (length == 1)
				{
					m_Entries = null;
				}
				else
				{
					var destArray = new Entry[length - 1];
					if (objectIndex > 0)
					{
						Array.Copy(m_Entries, 0, destArray, 0, objectIndex);
					}
					if (objectIndex < length)
					{
						Array.Copy(m_Entries, objectIndex + 1, destArray, objectIndex, (length - objectIndex) - 1);
					}
					m_Entries = destArray;
				}
			}
			else
			{
				switch (element)
				{
					case 0:
						m_Entries[objectIndex].Val1 = null;
						return;

					case 1:
						m_Entries[objectIndex].Val2 = null;
						return;

					case 2:
						m_Entries[objectIndex].Val3 = null;
						return;

					case 3:
						m_Entries[objectIndex].Val4 = null;
						return;
				}
			}
		}

		private short SplitKey(int key, out short element)
		{
			element = (short) (key & 3);
			return (short) (key & 0xfffffffc);
		}

		private bool LocateObject(short entryKey, out int index)
		{
			index = 0;

			if (m_Entries == null)
			{
				return false;
			}

			int middle;
			int length = m_Entries.Length;

			if (length <= 16)
			{
				middle = length/2;
				if (m_Entries[middle].Key <= entryKey)
				{
					index = middle;
					if (m_Entries[index].Key == entryKey)
					{
						return true;
					}
				}

				middle = (length + 1)/4;
				if (m_Entries[index + middle].Key <= entryKey)
				{
					index += middle;
					if (m_Entries[index].Key == entryKey)
					{
						return true;
					}
				}

				middle = (length + 3)/8;
				if (m_Entries[index + middle].Key <= entryKey)
				{
					index += middle;
					if (m_Entries[index].Key == entryKey)
					{
						return true;
					}
				}

				middle = (length + 7)/16;
				if (m_Entries[index + middle].Key <= entryKey)
				{
					index += middle;
					if (m_Entries[index].Key == entryKey)
					{
						return true;
					}
				}

				if (entryKey > m_Entries[index].Key)
				{
					index++;
				}

				return false;
			}

			int left = 0;
			int right = length - 1;
			middle = 0;
			short key;

			do
			{
				middle = (right + left)/2;
				key = m_Entries[middle].Key;

				if (key == entryKey)
				{
					index = middle;
					return true;
				}

				if (entryKey < key)
				{
					right = middle - 1;
				}
				else
				{
					left = middle + 1;
				}
			} while (right >= left);

			index = middle;
			if (entryKey > m_Entries[index].Key)
			{
				index++;
			}

			return false;
		}

		public static int CreateKey()
		{
			return m_CurrKey++;
		}

		internal struct Entry
		{
			internal short Key;
			internal short Mask;
			internal object Val1;
			internal object Val2;
			internal object Val3;
			internal object Val4;

			public object GetVal(int valIndex)
			{
				object val = null;
				switch (valIndex)
				{
					case 1:
						val = Val1;
						break;
					case 2:
						val = Val2;
						break;
					case 3:
						val = Val3;
						break;
					case 4:
						val = Val4;
						break;
				}

				return val;
			}
		}
	}
}