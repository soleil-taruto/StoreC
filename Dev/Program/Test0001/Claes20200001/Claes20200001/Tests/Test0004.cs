using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0004
	{
		public void Test01()
		{
			for (int n = 1; n < 9998; n++)
			{
				Console.WriteLine(n + " --> " + Collatz(n));
			}
		}

		public void Test02()
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();

			for (int n = 1; n < 1000000; n++)
			{
				//if (n % 1000 == 0) Console.WriteLine(n); // cout

				int c = Collatz(n);

				if (!dict.ContainsKey(c))
					dict[c] = n;
			}

			foreach (int c in dict.Keys.OrderBy(SCommon.Comp))
			{
				Console.WriteLine(dict[c] + " --> " + c);
			}
		}

		private int Collatz(BigInteger n)
		{
			int c;

#if true
			while (n % 2 == 0) n /= 2;
			for (c = 0; n != 1; c++)
			{
				n = n * 3 + 1;
				while (n % 2 == 0) n /= 2;
			}
#else
			for (c = 0; n != 1; c++)
			{
				if (n % 2 == 1)
					n = n * 3 + 1;
				else
					n /= 2;
			}
#endif
			return c;
		}

		public void Test03()
		{
			BigInteger n = 837799;

			while (n != 1)
			{
				Console.WriteLine(n);

				n = n * 3 + 1;
				while (n % 2 == 0) n /= 2;
			}
		}
	}
}
