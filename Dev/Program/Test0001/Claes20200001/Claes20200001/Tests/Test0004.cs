using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0004
	{
		public void Test01()
		{
			RndCtr = (ulong)DateTime.Now.Ticks;

			D2Point[] Points = Enumerable.Range(0, 91).Select(dummy => new D2Point(GetRandReal(), GetRandReal())).ToArray();

			Points[0].X = 1.0;
			Points[0].Y = 0.0;

			Points[90].X = 0.0;
			Points[90].Y = 1.0;

			for (int c = 0; c < 100000000; c++)
			{
				int d = GetRandInt(89) + 1;

				Points[d] = (Points[d - 1] + Points[d + 1]) / 2.0;
				Points[d] /= GetDistance(Points[d]);
			}

			for (int d = 0; d <= 90; d++)
			{
				Console.WriteLine(string.Format("Cos {0} degree is {1:F15}", d, Points[d].X));
				Console.WriteLine(string.Format("Sin {0} degree is {1:F15}", d, Points[d].Y));
			}
		}

		private double GetDistance(D2Point pt)
		{
			return Math.Sqrt(pt.X * pt.X + pt.Y * pt.Y);
		}

		// ====
		// Random
		// ====

		public static ulong RndCtr = 1;

		public static ulong GetRandULong() // Xorshift-64
		{
			RndCtr ^= RndCtr << 13;
			RndCtr ^= RndCtr >> 7;
			RndCtr ^= RndCtr << 17;
			return RndCtr;
		}

		public static int GetRandInt(int modulo)
		{
			return (int)(GetRandULong() % (ulong)modulo);
		}

		public static double GetRandReal() // ret: 0.0 ～ 1.0
		{
			return (double)GetRandInt(int.MaxValue) / (int.MaxValue - 1);
		}

		// ====
	}
}
