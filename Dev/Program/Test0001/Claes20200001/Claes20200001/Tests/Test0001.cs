using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			List<int> gaps = new List<int>();
			int n = 2;

			while (n < 1000000)
			{
				int c;

				for (c = 0; ; c++)
					if (MillerRabin.IsPrime((ulong)++n))
						break;

				gaps.Add(c);
			}

			Console.WriteLine(gaps.Max());
		}
	}
}
