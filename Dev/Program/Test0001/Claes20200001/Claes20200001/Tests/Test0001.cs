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
			//const int RANGE_SCALE = 100;
			//const int RANGE_SCALE = 10000;
			const int RANGE_SCALE = 1000000;
			//const int RANGE_SCALE = 100000000;

			List<GapInfo> gaps = new List<GapInfo>();
			int lp = 2;

			foreach (int p in Enumerable.Range(3, RANGE_SCALE).Where(v => MillerRabin.IsPrime((ulong)v)))
			{
				gaps.Add(new GapInfo() { PrimeLw = lp, PrimeHi = p });
				lp = p;
			}

			{
				int maxGap = gaps.Select(v => v.Gap).Max();

				foreach (GapInfo gap in gaps)
					if (maxGap == gap.Gap)
						Console.WriteLine("maxGap : " + gap);
			}

			List<GapInfo[]> twoGaps = new List<GapInfo[]>();

			{
				GapInfo lGap = gaps[0];

				foreach (GapInfo gap in gaps.Skip(1))
				{
					twoGaps.Add(new GapInfo[] { lGap, gap });
					lGap = gap;
				}
			}

			{
				int maxTwoGap = twoGaps.Select(v => v[0].Gap + v[1].Gap).Max();

				foreach (GapInfo[] twoGap in twoGaps)
					if (maxTwoGap == twoGap[0].Gap + twoGap[1].Gap)
						Console.WriteLine("maxTwoGap : " + twoGap[0] + " , " + twoGap[1]);
			}

			List<GapInfo[]> threeGaps = new List<GapInfo[]>();

			{
				GapInfo kGap = gaps[0];
				GapInfo lGap = gaps[1];

				foreach (GapInfo gap in gaps.Skip(2))
				{
					threeGaps.Add(new GapInfo[] { kGap, lGap, gap });
					kGap = lGap;
					lGap = gap;
				}
			}

			{
				int maxThreeGap = threeGaps.Select(v => v[0].Gap + v[1].Gap + v[2].Gap).Max();

				foreach (GapInfo[] threeGap in threeGaps)
					if (maxThreeGap == threeGap[0].Gap + threeGap[1].Gap + threeGap[2].Gap)
						Console.WriteLine("maxThreeGap : " + threeGap[0] + " , " + threeGap[1] + " , " + threeGap[2]);
			}
		}

		private class GapInfo
		{
			public int PrimeLw;
			public int PrimeHi;

			public int Gap
			{
				get
				{
					return (this.PrimeHi - this.PrimeLw) - 1;
				}
			}

			public override string ToString()
			{
				return string.Format("{0} ..({1}).. {2}", this.PrimeLw, this.Gap, this.PrimeHi);
			}
		}
	}
}
