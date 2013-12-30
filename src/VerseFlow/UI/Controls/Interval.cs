using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VerseFlow.UI.Controls
{
	/// <summary>
	///     Обобщенный класс для работы с интервалами.
	/// </summary>
	/// <typeparam name="T">Тип элемента интервала.</typeparam>
	public class Interval<T> : IEquatable<Interval<T>> where T : IComparable<T>
	{
		private readonly T max;
		private readonly T min;

		/// <summary>
		///     Создать новый интервал.
		/// </summary>
		/// <param name="min">Нижний предел интервала.</param>
		/// <param name="max">Верхний предел интервала.</param>
		public Interval(T min, T max)
		{
			Debug.Assert(max.CompareTo(min) >= 0);
			this.min = min;
			this.max = max;
		}

		#region Общедоступные свойства

		/// <summary>
		///     Нижний предел интервала.
		/// </summary>
		public T Min
		{
			get { return min; }
		}

		/// <summary>
		///     Верхний предел интервала.
		/// </summary>
		public T Max
		{
			get { return max; }
		}

		#endregion

		#region Общедоступные методы

		/// <summary>
		///     Проверяет, принадлежит ли значение интервалу.
		/// </summary>
		/// <param name="value">Значение.</param>
		/// <returns>true - если принадлежит, false - если не принадлежит.</returns>
		public bool Contains(T value)
		{
			return (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0);
		}

		/// <summary>
		///     Проверяет, содержится ли полностью интервал <paramref name="value" /> в текущем интервале.
		/// </summary>
		/// <param name="value">Интервал.</param>
		/// <returns>true - если содержится, false - если не содержится.</returns>
		public bool Contains(Interval<T> value)
		{
			return (value.Max.CompareTo(value.Min) >= 0 && value.Contains(value.Min) && value.Contains(value.Max));
		}

		/// <summary>
		///     Проверяет, имеется ли пересечение (общие значения) у текущего интервала с интервалом <paramref name="value" />.
		/// </summary>
		/// <param name="value">Интервал.</param>
		public bool IsIntersection(Interval<T> value)
		{
			return (min.CompareTo(value.Min) > 0 ? min : value.Min)
				.CompareTo(max.CompareTo(value.Max) < 0 ? max : value.Max) <= 0;
		}

		/// <summary>
		///     Проверяет, имеется ли пересечение (общие значения) у текущего интервала с набором интервалов
		///     <paramref name="values" />.
		/// </summary>
		/// <param name="values">Набор интервалов.</param>
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
		///     Находит пересечение интервала <paramref name="value" /> с текущим интервалом.
		/// </summary>
		/// <param name="value">Интервал.</param>
		/// <returns>Если интервалы имеют общие точки, то интервал, иначе - null.</returns>
		public Interval<T> Intersect(Interval<T> value)
		{
			T tmin = min.CompareTo(value.Min) > 0 ? min : value.Min;
			T tmax = max.CompareTo(value.Max) < 0 ? max : value.Max;
			return tmin.CompareTo(tmax) <= 0 ? new Interval<T>(tmin, tmax) : null;
		}

		/// <summary>
		///     Находит пересечение набора интервалов <paramref name="values" /> с текущим интервалом.
		/// </summary>
		/// <param name="values">Интервал.</param>
		/// <returns>Если интервалы имеют общие точки, то интервал, иначе - null.</returns>
		/// <remarks>Уплотнение интервалов в этом методе не производится.</remarks>
		public List<Interval<T>> Intersect(IEnumerable<Interval<T>> values)
		{
			var tmp = new List<Interval<T>>();
			foreach (var interval in values)
				if (IsIntersection(interval))
					tmp.Add(Intersect(interval));
			return tmp;
		}

		/// <summary>
		///     Проверяет, имеется ли объединение (общие значения) у текущего интервала с нтервалом <paramref name="value" />.
		///     То же, что и метод IsIntersection.
		/// </summary>
		/// <param name="value">Набор интервалов.</param>
		public bool IsCombination(Interval<T> value)
		{
			return (IsIntersection(value));
		}

		/// <summary>
		///     Объединяет набор интервалов value с текущим интервалом.
		/// </summary>
		/// <param name="value">Интервал.</param>
		/// <returns>Если интервалы имеют общие точки, то интервал, иначе - null.</returns>
		public Interval<T> Combine(Interval<T> value)
		{
			return IsCombination(value)
				? new Interval<T>(min.CompareTo(value.Min) < 0 ? min : value.Min, max.CompareTo(value.Max) > 0 ? max : value.Max)
				: null;
		}

		/// <summary>
		///     Объединяет набор интервалов <paramref name="values" /> с текущим интервалом.
		///     Если, в результате объединения, из нескольких интервалов из получившегося набора можно образовать один,
		///     содержащий эти интервалы, то эти интервалы будут объединены в один интервал.
		/// </summary>
		/// <param name="values">Набор интервалов.</param>
		/// <returns>Набор интервалов.</returns>
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
		///     Исключает текущий интервал из интервала <paramref name="value" />.
		/// </summary>
		/// <param name="value">Набор интервалов.</param>
		/// <returns>Если интервалы имеют общие точки, то набор интервалов из 1 или 2 элементов, иначе - null.</returns>
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
		///     Исключает текущий интервал из набора интервалов <paramref name="values" />.
		/// </summary>
		/// <param name="values">Набор интервалов.</param>
		/// <returns>Набор интервалов.</returns>
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