using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VerseFlow.UI.Controls
{
	/// <summary>
	///     ���������� ����� ��� ������ � �����������.
	/// </summary>
	/// <typeparam name="T">��� �������� ���������.</typeparam>
	public class Interval<T> : IEquatable<Interval<T>> where T : IComparable<T>
	{
		private readonly T max;
		private readonly T min;

		/// <summary>
		///     ������� ����� ��������.
		/// </summary>
		/// <param name="min">������ ������ ���������.</param>
		/// <param name="max">������� ������ ���������.</param>
		public Interval(T min, T max)
		{
			Debug.Assert(max.CompareTo(min) >= 0);
			this.min = min;
			this.max = max;
		}

		#region ������������� ��������

		/// <summary>
		///     ������ ������ ���������.
		/// </summary>
		public T Min
		{
			get { return min; }
		}

		/// <summary>
		///     ������� ������ ���������.
		/// </summary>
		public T Max
		{
			get { return max; }
		}

		#endregion

		#region ������������� ������

		/// <summary>
		///     ���������, ����������� �� �������� ���������.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <returns>true - ���� �����������, false - ���� �� �����������.</returns>
		public bool Contains(T value)
		{
			return (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0);
		}

		/// <summary>
		///     ���������, ���������� �� ��������� �������� <paramref name="value" /> � ������� ���������.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <returns>true - ���� ����������, false - ���� �� ����������.</returns>
		public bool Contains(Interval<T> value)
		{
			return (value.Max.CompareTo(value.Min) >= 0 && value.Contains(value.Min) && value.Contains(value.Max));
		}

		/// <summary>
		///     ���������, ������� �� ����������� (����� ��������) � �������� ��������� � ���������� <paramref name="value" />.
		/// </summary>
		/// <param name="value">��������.</param>
		public bool IsIntersection(Interval<T> value)
		{
			return (min.CompareTo(value.Min) > 0 ? min : value.Min)
				.CompareTo(max.CompareTo(value.Max) < 0 ? max : value.Max) <= 0;
		}

		/// <summary>
		///     ���������, ������� �� ����������� (����� ��������) � �������� ��������� � ������� ����������
		///     <paramref name="values" />.
		/// </summary>
		/// <param name="values">����� ����������.</param>
		public bool IsIntersection(IEnumerable<Interval<T>> values)
		{
			IEnumerator<Interval<T>> value = values.GetEnumerator();
			while (value.MoveNext())
			{
				if (IsIntersection(value.Current))
					return true;
			}
			return false;
		}

		/// <summary>
		///     ������� ����������� ��������� <paramref name="value" /> � ������� ����������.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <returns>���� ��������� ����� ����� �����, �� ��������, ����� - null.</returns>
		public Interval<T> Intersect(Interval<T> value)
		{
			T tmin = min.CompareTo(value.Min) > 0 ? min : value.Min;
			T tmax = max.CompareTo(value.Max) < 0 ? max : value.Max;
			return tmin.CompareTo(tmax) <= 0 ? new Interval<T>(tmin, tmax) : null;
		}

		/// <summary>
		///     ������� ����������� ������ ���������� <paramref name="values" /> � ������� ����������.
		/// </summary>
		/// <param name="values">��������.</param>
		/// <returns>���� ��������� ����� ����� �����, �� ��������, ����� - null.</returns>
		/// <remarks>���������� ���������� � ���� ������ �� ������������.</remarks>
		public List<Interval<T>> Intersect(IEnumerable<Interval<T>> values)
		{
			var tmp = new List<Interval<T>>();
			foreach (var interval in values)
				if (IsIntersection(interval))
					tmp.Add(Intersect(interval));
			return tmp;
		}

		/// <summary>
		///     ���������, ������� �� ����������� (����� ��������) � �������� ��������� � ��������� <paramref name="value" />.
		///     �� ��, ��� � ����� IsIntersection.
		/// </summary>
		/// <param name="value">����� ����������.</param>
		public bool IsCombination(Interval<T> value)
		{
			return (IsIntersection(value));
		}

		/// <summary>
		///     ���������� ����� ���������� value � ������� ����������.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <returns>���� ��������� ����� ����� �����, �� ��������, ����� - null.</returns>
		public Interval<T> Combine(Interval<T> value)
		{
			return IsCombination(value)
				? new Interval<T>(min.CompareTo(value.Min) < 0 ? min : value.Min, max.CompareTo(value.Max) > 0 ? max : value.Max)
				: null;
		}

		/// <summary>
		///     ���������� ����� ���������� <paramref name="values" /> � ������� ����������.
		///     ����, � ���������� �����������, �� ���������� ���������� �� ������������� ������ ����� ���������� ����,
		///     ���������� ��� ���������, �� ��� ��������� ����� ���������� � ���� ��������.
		/// </summary>
		/// <param name="values">����� ����������.</param>
		/// <returns>����� ����������.</returns>
		public List<Interval<T>> Combine(List<Interval<T>> values)
		{
			values.Add(this);
			values.Sort(SorterByMin);
			Interval<T> cur = this;
			var curValues = new List<Interval<T>>(values.Count);
			bool wasCombine = false;

			for (int i = 0; i < values.Count; i++)
			{
				wasCombine = cur.IsCombination(values[i]);
				if (wasCombine)
					cur = cur.Combine(values[i]);
				else
				{
					curValues.Add(cur);
					cur = values[i];
				}
			}
			if (wasCombine)
				curValues.Add(cur);

			curValues.TrimExcess();
			return curValues;
		}

		/// <summary>
		///     ��������� ������� �������� �� ��������� <paramref name="value" />.
		/// </summary>
		/// <param name="value">����� ����������.</param>
		/// <returns>���� ��������� ����� ����� �����, �� ����� ���������� �� 1 ��� 2 ���������, ����� - null.</returns>
		public Interval<T>[] Exclude(Interval<T> value)
		{
			if (min.CompareTo(value.Min) < 0 && max.CompareTo(value.Max) > 0)
			{
				return new[] {new Interval<T>(min, value.Min), new Interval<T>(value.Max, max)};
			}
			T tmin = min.CompareTo(value.Min) < 0 ? min : value.Max;
			T tmax = max.CompareTo(value.Max) > 0 ? max : value.Min;
			return tmin.CompareTo(tmax) <= 0 ? new[] {new Interval<T>(tmin, tmax)} : null;
		}

		/// <summary>
		///     ��������� ������� �������� �� ������ ���������� <paramref name="values" />.
		/// </summary>
		/// <param name="values">����� ����������.</param>
		/// <returns>����� ����������.</returns>
		public List<Interval<T>> Exclude(List<Interval<T>> values)
		{
			var curValues = new List<Interval<T>>(values.Count);
			for (int i = 0; i < values.Count; i++)
			{
				if (IsIntersection(values[i]))
				{
					Interval<T>[] cur = Exclude(values[i]);
					if (cur != null)
						curValues.AddRange(cur);
				}
				else
					curValues.Add(values[i]);
			}
			return curValues;
		}

		#endregion

		#region IEquatable<Interval<T>> Members

		public bool Equals(Interval<T> other)
		{
			return other.min.CompareTo(min) == 0 && other.max.CompareTo(max) == 0;
		}

		#endregion

		private static int SorterByMin(Interval<T> a, Interval<T> b)
		{
			return a.Min.CompareTo(b.Min);
		}
	}
}