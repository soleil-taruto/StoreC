using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Charlotte.Tests
{
	public class Test0005
	{
		public void Test01()
		{
			const int ARR_LEN = 50000000;

			{
				int[] arr = Enumerable.Range(1, ARR_LEN).ToArray();

				PrintExecuteTime(() => Console.WriteLine(arr.Count())); // 0.0s
				PrintExecuteTime(() => Console.WriteLine(arr.Count())); // 0.0s
				PrintExecuteTime(() => Console.WriteLine(arr.Count())); // 0.0s
			}

			{
				List<int> list = new List<int>();

				foreach (int value in Enumerable.Range(1, ARR_LEN))
					list.Add(value);

				PrintExecuteTime(() => Console.WriteLine(list.Count())); // 0.0s
				PrintExecuteTime(() => Console.WriteLine(list.Count())); // 0.0s
				PrintExecuteTime(() => Console.WriteLine(list.Count())); // 0.0s
			}

			{
				int[] arr = Enumerable.Range(1, ARR_LEN).ToArray();

				IEnumerable<int> enu = arr.Take(arr.Length);

				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.3s
				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.3s
				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.3s
			}

			{
				List<int> list = new List<int>();

				foreach (int value in Enumerable.Range(1, ARR_LEN))
					list.Add(value);

				IEnumerable<int> enu = list.Take(list.Count);

				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.5s
				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.5s
				PrintExecuteTime(() => Console.WriteLine(enu.Count())); // 0.5s
			}
		}

		private static void PrintExecuteTime(Action routine)
		{
			DateTime stTm = DateTime.Now;
			routine();
			DateTime edTm = DateTime.Now;
			Console.WriteLine((edTm - stTm).TotalSeconds.ToString("F9") + " 秒");
		}
	}
}
