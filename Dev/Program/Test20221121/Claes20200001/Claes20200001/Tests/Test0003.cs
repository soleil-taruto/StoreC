using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Charlotte.Tests
{
	public class Test0003
	{
		public void Test01()
		{
			for (int testcnt = 0; testcnt < 30; testcnt++)
			{
				int[] arr1 = GetRandIntList().ToArray();
				int[] arr2 = arr1.ToArray(); // Cloning

				Array.Sort(arr1, (a, b) => a - b);

				arr2 = MergeSort(arr2, (a, b) => a - b).ToArray();

				for (int index = 0; index < arr1.Length; index++)
					if (arr1[index] != arr2[index])
						throw null;

				//Console.WriteLine("OK");
			}
			Console.WriteLine("OK!");
		}

		private static IEnumerable<T> MergeSort<T>(IList<T> list, Comparison<T> comp)
		{
			if (list.Count == 0)
				return new T[0];

			Queue<IEnumerable<T>> q = new Queue<IEnumerable<T>>(list.Select(v => new T[] { v }));

			while (2 <= q.Count)
				q.Enqueue(E_Merge(q.Dequeue(), q.Dequeue(), comp));

			return q.Dequeue();
		}

		private static IEnumerable<T> E_Merge<T>(IEnumerable<T> v1, IEnumerable<T> v2, Comparison<T> comp)
		{
			IEnumerator<T> a = v1.GetEnumerator();
			IEnumerator<T> b = v2.GetEnumerator();

			if (!a.MoveNext()) throw null;
			if (!b.MoveNext()) throw null;

			for (; ; )
			{
				int ret = comp(a.Current, b.Current);

				if (ret <= 0)
				{
					yield return a.Current;
					if (!a.MoveNext()) { a = b; break; }
				}
				if (0 <= ret)
				{
					yield return b.Current;
					if (!b.MoveNext()) break;
				}
			}
			do { yield return a.Current; } while (a.MoveNext());
		}

		// ====
		// Random
		// ====

		private static RandomNumberGenerator Csprng = new RNGCryptoServiceProvider();

		private static uint GetRandUInt()
		{
			byte[] data = new byte[4];
			uint value = 0;

			Csprng.GetBytes(data);

			foreach (byte b in data)
			{
				value <<= 8;
				value |= b;
			}
			return value;
		}

		private static int GetRandInt(int modulo)
		{
			return (int)(GetRandUInt() % (uint)modulo);
		}

		private static IEnumerable<int> GetRandIntList()
		{
			int count = GetRandInt(10000);
			int limit = GetRandInt(10000) + 1;

			for (int index = 0; index < count; index++)
				yield return GetRandInt(limit);
		}

		// ====
	}
}
