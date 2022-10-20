using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Tests
{
	public class Test0011
	{
		public void Test01()
		{
			Enumerable.Range(1, 3)
				.Test0011_ForEach(v => Console.WriteLine("1 : " + v))
				.Test0011_ForEach(v => Console.WriteLine("2 : " + v))
				.Test0011_ForEach(v => Console.WriteLine("3 : " + v))
				.ToArray();

			// ----

			Enumerable.Range(1, 3)
				.Concat(Enumerable.Range(1, 3))
				.Test0011_ForEach(v => Console.WriteLine("A : " + v))
				.DistinctOrderBy((a, b) => a - b)
				.Test0011_ForEach(v => Console.WriteLine("B : " + v))
				.ToArray();

			// ----

			Enumerable.Range(1, 3)
				.Select(v => new int[] { v })
				.Test0011_ForEach(v => Console.WriteLine("1 : " + v[0]))
				.Test0011_ForEach(v => v[0] *= -1) // <================================ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ???
				.Test0011_ForEach(v => Console.WriteLine("2 : " + v[0]))
				.DistinctOrderBy((a, b) => a[0] - b[0])
				.Test0011_ForEach(v => Console.WriteLine("3 : " + v[0]))
				.ToArray();
		}
	}
}
