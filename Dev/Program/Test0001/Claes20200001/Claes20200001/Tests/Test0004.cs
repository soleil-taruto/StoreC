using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
				if (n % 1000 == 0) Console.WriteLine(n); // cout

				dict[Collatz(n)] = n;
			}
		}

		private int Collatz(int ni)
		{
			ulong n = (ulong)ni;
			int c;

#if true
			while (n % 2 == 0) n /= 2;
			for (c = 0; n != 1; c++)
			{
				if (2642245 < n) throw null; // overflow

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
	}
}
