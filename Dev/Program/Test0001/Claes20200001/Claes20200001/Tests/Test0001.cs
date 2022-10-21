using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			Test01_a(uint.MaxValue - 3, (ulong)(uint.MaxValue - 3) * (uint.MaxValue - 3), (ulong)(uint.MaxValue - 2) * (uint.MaxValue - 2) - 1);
			Test01_a(uint.MaxValue - 2, (ulong)(uint.MaxValue - 2) * (uint.MaxValue - 2), (ulong)(uint.MaxValue - 1) * (uint.MaxValue - 1) - 1);
			Test01_a(uint.MaxValue - 1, (ulong)(uint.MaxValue - 1) * (uint.MaxValue - 1), (ulong)(uint.MaxValue - 0) * (uint.MaxValue - 0) - 1);
			Test01_a(uint.MaxValue - 0, (ulong)(uint.MaxValue - 0) * (uint.MaxValue - 0), ulong.MaxValue);

			Test01_b(10000, 100);
			Test01_b(10000, 10000);
			Test01_b(10000, 1000000);
			Test01_b(10000, 100000000);
			Test01_b(10000, 10000000000);
			Test01_b(10000, 1000000000000);
			Test01_b(10000, 100000000000000);
			Test01_b(10000, 10000000000000000);
			Test01_b(10000, 1000000000000000000);
			Test01_b(10000, 18440000000000000000);

			Test01_c(10000, 100);
			Test01_c(10000, 10000);
			Test01_c(10000, 1000000);
			Test01_c(10000, 100000000);
			Test01_c(10000, 10000000000);
			Test01_c(10000, 1000000000000);
			Test01_c(10000, 100000000000000);
			Test01_c(10000, 10000000000000000);
			Test01_c(10000, 1000000000000000000);
			Test01_c(10000, 9220000000000000000);

			Console.WriteLine("OK!");
		}

		private void Test01_a(uint expectRet, ulong minPrm, ulong maxPrm)
		{
			for (ulong prm = minPrm; ; prm++)
			{
				ulong ret = UIntSqrt(prm);

				if (ret != expectRet)
					throw null; // BUG !!!

				// ----

				if (maxPrm <= prm)
					break;

				if (minPrm + 3000000 < maxPrm) // 多い -> ワープ
					if (prm == minPrm + 1000000)
						prm = maxPrm - 1000000;
			}
			Console.WriteLine("OK");
		}

		private void Test01_b(int testCount, ulong prmScale)
		{
			for (int testcnt = 0; testcnt < testCount; testcnt++)
			{
				ulong prm = SCommon.CRandom.GetULong_M(prmScale);
				uint ret = UIntSqrt(prm);

				if ((ulong)ret * ret > prm)
					throw null; // BUG !!!

				if ((ulong)(ret + 1) * (ret + 1) <= prm)
					throw null; // BUG !!!
			}
			Console.WriteLine("OK");
		}

		private void Test01_c(int testCount, long prmScale)
		{
			for (int testcnt = 0; testcnt < testCount; testcnt++)
			{
				long prm = SCommon.CRandom.GetLong(prmScale);
				int ret = IntSqrt(prm);

				if ((long)ret * ret > prm)
					throw null; // BUG !!!

				if ((long)(ret + 1) * (ret + 1) <= prm)
					throw null; // BUG !!!
			}
			Console.WriteLine("OK");
		}

		public static int IntSqrt(long value)
		{
			if (value < 0)
				throw new ArgumentException();

			return (int)UIntSqrt((ulong)value);
		}

		public static uint UIntSqrt(ulong value)
		{
			ulong l = 0;
			ulong r = (ulong)uint.MaxValue + 1;

			while (l + 1 < r)
			{
				ulong m = (l + r) / 2;

				if (m * m <= value)
				{
					l = m;
				}
				else
				{
					r = m;
				}
			}
			return (uint)l;
		}
	}
}
