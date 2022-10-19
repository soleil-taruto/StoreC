using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace Charlotte.Tests
{
	public class Test0006
	{
		public void Test01()
		{
			Test01_a(0x7);
			Test01_a(0xf);
			Test01_a(0xff);
			Test01_a(0xffff);
			Test01_a(0xffffffff);
			Test01_a(ulong.MaxValue);
		}

		private void Test01_a(ulong mask)
		{
			for (int testcnt = 0; testcnt < 1000; testcnt++)
			{
				Test01_a2(mask);
			}
		}

		private void Test01_a2(ulong mask)
		{
			ulong a = GetULongRand() & mask;
			ulong b = GetULongRand() & mask;
			ulong m = GetULongRand() & mask;

			if (m == 0)
				return;

			ulong c = ModPow64(a, b, m);

			Console.WriteLine("ModPow ( " + a + " , " + b + " , " + m + " ) == " + c);

			ulong d = Test01_b(a, b, m);

			if (c != d)
				throw null;
		}

		private static ulong ModPow64(ulong b, ulong e, ulong m)
		{
			ulong a = 1;

			for (; 1 <= e; e >>= 1)
			{
				if ((e & 1) != 0)
					a = ModMul64(a, b, m);

				b = ModMul64(b, b, m);
			}
			return a % m;
		}

		private static ulong ModMul64(ulong b, ulong e, ulong m)
		{
			ulong a = 0;

			for (; 1 <= e; e >>= 1)
			{
				if ((e & 1) != 0)
					a = ModAdd64(a, b, m);

				b = ModAdd64(b, b, m);
			}
			return a;
		}

		private static ulong ModAdd64(ulong a, ulong b, ulong m)
		{
			ulong r = (ulong.MaxValue % m + 1) % m;

			while (ulong.MaxValue - a < b)
			{
				unchecked { a += b; }
				b = r;
			}
			return (a + b) % m;
		}

		// ====
		// Random
		// ====

		private static RandomNumberGenerator Csprng = new RNGCryptoServiceProvider();

		private static ulong GetULongRand()
		{
			byte[] data = new byte[8];
			ulong value = 0;

			Csprng.GetBytes(data);

			foreach (byte b in data)
			{
				value <<= 8;
				value |= b;
			}
			return value;
		}

		// ====

		private ulong Test01_b(ulong a, ulong b, ulong m)
		{
			BigInteger aa = new BigInteger(a);
			BigInteger bb = new BigInteger(b);
			BigInteger mm = new BigInteger(m);

			return (ulong)Test01_ModPow(aa, bb, mm);
		}

		private BigInteger Test01_ModPow(BigInteger aa, BigInteger bb, BigInteger mm)
		{
			if (bb == 0)
			{
				return 1 % mm;
			}
			if (bb == 1)
			{
				return aa % mm;
			}
			if (bb % 2 == 1)
			{
				return (Test01_ModPow(aa, bb - 1, mm) * aa) % mm;
			}
			return Test01_ModPow((aa * aa) % mm, bb / 2, mm);
		}
	}
}
