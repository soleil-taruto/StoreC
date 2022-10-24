using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0003
	{
		public void Test01()
		{
			string[] lLines = File.ReadAllLines(@"C:\temp\左側ファイル.txt");
			string[] rLines = File.ReadAllLines(@"C:\temp\右側ファイル.txt");

			int lNearly = 0;
			int rNearly = 0;

			for (int index = 0; index < lLines.Length; index++)
			{
				string[] lTokens = SCommon.Tokenize(lLines[index], " ", false, true);
				string[] rTokens = SCommon.Tokenize(rLines[index], " ", false, true);

				bool sinFlag = lTokens[0][0] == 'S';
				double degree = double.Parse(lTokens[1]);
				double lValue = double.Parse(lTokens[4]);
				double rValue = double.Parse(rTokens[4]);

				double mathClsValue = sinFlag ?
					Math.Sin(degree * (Math.PI / 180.0)) :
					Math.Cos(degree * (Math.PI / 180.0));

				double lDiff = Math.Abs(lValue - mathClsValue);
				double rDiff = Math.Abs(rValue - mathClsValue);

				if (lDiff < rDiff)
					lNearly++;

				if (rDiff < lDiff)
					rNearly++;

				Console.WriteLine(string.Format("{0:F20} {1:F20}", lDiff, rDiff));
			}
			Console.WriteLine(lNearly);
			Console.WriteLine(rNearly);
		}
	}
}
