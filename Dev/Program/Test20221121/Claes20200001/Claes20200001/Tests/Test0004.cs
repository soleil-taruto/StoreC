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
			Test01_a(1, 3, 3, 7);
		}

		private class OperandInfo
		{
			public int Numer;
			public int Denom;
			public string Str;
		}

		private void Test01_a(params int[] ns)
		{
			Test01_b(ns.Select(v => new OperandInfo() { Numer = v, Denom = 1, Str = "" + v }).ToArray());
		}

		private void Test01_b(OperandInfo[] os)
		{
			if (os.Length == 1)
			{
				if (
					os[0].Numer / os[0].Denom == 10 &&
					os[0].Numer % os[0].Denom == 0
					)
					Console.WriteLine(os[0].Str);

				return;
			}

			for (int b = 1; b < os.Length; b++)
			{
				for (int a = 0; a < b; a++)
				{
					OperandInfo[] next = os;

					next = SCommon.A_RemoveRange(next, b, 1);
					next = SCommon.A_RemoveRange(next, a, 1);

					// a + b
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[a].Numer * os[b].Denom + os[b].Numer * os[a].Denom,
							Denom = os[a].Denom * os[b].Denom,
							Str = "(" + os[a].Str + " + " + os[b].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}

					// a - b
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[a].Numer * os[b].Denom - os[b].Numer * os[a].Denom,
							Denom = os[a].Denom * os[b].Denom,
							Str = "(" + os[a].Str + " - " + os[b].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}

					// b - a
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[b].Numer * os[a].Denom - os[a].Numer * os[b].Denom,
							Denom = os[a].Denom * os[b].Denom,
							Str = "(" + os[b].Str + " - " + os[a].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}

					// a * b
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[a].Numer * os[b].Numer,
							Denom = os[a].Denom * os[b].Denom,
							Str = "(" + os[a].Str + " * " + os[b].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}

					// a / b
					if (os[b].Numer != 0)
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[a].Numer * os[b].Denom,
							Denom = os[a].Denom * os[b].Numer,
							Str = "(" + os[a].Str + " / " + os[b].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}

					// b / a
					if (os[a].Numer != 0)
					{
						OperandInfo o = new OperandInfo()
						{
							Numer = os[a].Denom * os[b].Numer,
							Denom = os[a].Numer * os[b].Denom,
							Str = "(" + os[b].Str + " / " + os[a].Str + ")",
						};

						Test01_b(SCommon.A_AddRange(next, new OperandInfo[] { o }));
					}
				}
			}
		}
	}
}
