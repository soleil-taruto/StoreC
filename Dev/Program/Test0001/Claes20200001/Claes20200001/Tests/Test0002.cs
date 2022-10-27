﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			Console.WriteLine(SCommon.EraseExt("Test02"));
			Console.WriteLine(SCommon.EraseExt("Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@".\Test02"));
			Console.WriteLine(SCommon.EraseExt(@".\Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@"SubDir\Test02"));
			Console.WriteLine(SCommon.EraseExt(@"SubDir\Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@"\TopDir\Test02"));
			Console.WriteLine(SCommon.EraseExt(@"\TopDir\Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@"C:\TopDir\Test02"));
			Console.WriteLine(SCommon.EraseExt(@"C:\TopDir\Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@"\TopDir\SubDir\Test02"));
			Console.WriteLine(SCommon.EraseExt(@"\TopDir\SubDir\Test02.txt"));
			Console.WriteLine(SCommon.EraseExt(@"C:\TopDir\SubDir\Test02"));
			Console.WriteLine(SCommon.EraseExt(@"C:\TopDir\SubDir\Test02.txt"));

			/*
			 * output ...
Test02
Test02
.\Test02
.\Test02
SubDir\Test02
SubDir\Test02
\TopDir\Test02
\TopDir\Test02
C:\TopDir\Test02
C:\TopDir\Test02
\TopDir\SubDir\Test02
\TopDir\SubDir\Test02
C:\TopDir\SubDir\Test02
C:\TopDir\SubDir\Test02
Press ENTER key.

			 * */

		}
	}
}
