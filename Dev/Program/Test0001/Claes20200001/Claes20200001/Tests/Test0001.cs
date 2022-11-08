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
			Canvas a = Canvas.LoadFromFile(@"C:\temp\1.jpg");
			Canvas b = Canvas.LoadFromFile(@"C:\temp\2.jpg");

			if (a.W != b.W)
				throw null;

			if (a.H != b.H)
				throw null;
		}
	}
}
