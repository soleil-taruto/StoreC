using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;
using System.IO;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			Test01_a(@"C:\temp\2022-11-22_16-49-06_000.jpg");
		}

		private void Test01_a(string file)
		{
			Canvas canvas = Canvas.LoadFromFile(file);

			canvas.FilterAllDot(dot =>
			{
				dot = new I4Color(
					255 - (255 - dot.R) / 2,
					255 - (255 - dot.G) / 2,
					255 - (255 - dot.B) / 2,
					dot.A
					);

				return dot;
			});

			canvas.Save(SCommon.NextOutputPath() + ".png");

			// ----

			canvas = Canvas.LoadFromFile(file);

			canvas.FilterAllDot(dot =>
			{
				dot = new I4Color(
					Math.Min(255, dot.R * 2),
					Math.Min(255, dot.G * 2),
					Math.Min(255, dot.B * 2),
					dot.A
					);

				return dot;
			});

			canvas.Save(SCommon.NextOutputPath() + ".png");

			// ----

			canvas = Canvas.LoadFromFile(file);

			canvas.FilterAllDot(dot =>
			{
				dot = new I4Color(
					Math.Min(255, dot.R * 4),
					Math.Min(255, dot.G * 4),
					Math.Min(255, dot.B * 4),
					dot.A
					);

				return dot;
			});

			canvas.Save(SCommon.NextOutputPath() + ".png");
		}
	}
}
