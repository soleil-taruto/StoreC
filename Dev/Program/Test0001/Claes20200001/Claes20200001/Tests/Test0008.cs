using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Tests
{
	public class Test0008
	{
		//private const int N_SCALE = 100000;
		//private const int N_SCALE = 1000000;
		//private const int N_SCALE = 10000000;
		private const int N_SCALE = 100000000;

		public void Test01()
		{
			int[] dc = Enumerable.Range(0, N_SCALE).Select(dummy => -1).ToArray();
			Queue<int> odds = new Queue<int>();

			dc[1] = 0;
			dc[2] = 1;
			dc[4] = 2;

			odds.Enqueue(4);

			while (1 <= odds.Count)
			{
				int odd = odds.Dequeue();

				for (int c = odd * 2; c < N_SCALE; c *= 2)
				{
					dc[c] = dc[odd];

					if ((c - 1) % 3 == 0)
					{
						int d = (c - 1) / 3;
						dc[d] = dc[c];
						odds.Enqueue(d);
					}
				}
			}

			{
				int c;
				for (c = 1; dc[c] != -1; c++) ;
				Console.WriteLine(c);
			}

			{
				int x = 0;

				for (int c = 1; c < N_SCALE; c++)
					if (dc[c] == -1)
						x++;

				Console.WriteLine(x);
			}
		}
	}
}
