namespace VerseFlow.GFramework.DataStructure
{
	public struct GBitVector64
	{
		private ulong data;

		public bool this[ulong key]
		{
			get { return (data & key) == key; }
			set
			{
				if (value)
				{
					data |= key;
				}
				else
				{
					data &= ~key;
				}
			}
		}

		public bool Equals(GBitVector64 other)
		{
			return data == other.data;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is GBitVector64 && Equals((GBitVector64) obj);
		}

		public override int GetHashCode()
		{
			return data.GetHashCode();
		}

		public static bool operator ==(GBitVector64 left, GBitVector64 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(GBitVector64 left, GBitVector64 right)
		{
			return !left.Equals(right);
		}
	}
}