using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0005
	{
		public void Test01()
		{
			if (LiteFormat("123456789") != "9") throw null;

			Console.WriteLine("OK!");
		}

		private string LiteFormat(string str)
		{
			SCommon.DECIMAL.ForEach(chr => str = str.Replace(chr, '9'));
			SCommon.ALPHA.ForEach(chr => str = str.Replace(chr, 'A'));
			SCommon.alpha.ForEach(chr => str = str.Replace(chr, 'a'));

			for (int c = 0; c < 20; c++)
			{
				str = str.Replace("99", "9");
				str = str.Replace("AA", "A");
				str = str.Replace("aa", "a");
			}
			return str;
		}
	}
}
