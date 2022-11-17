﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Utilities;
using Charlotte.Commons;
using System.Drawing;

namespace Charlotte.Tests
{
	public class Test0004
	{
		public void Test01()
		{
			MakeAliceCirnoTitlePicture("AliceCirno", 480, 120);
		}

		private void MakeAliceCirnoTitlePicture(string title, int w, int h)
		{
			Canvas canvas = new Canvas(w, h);
			Canvas cText;

			{
				int MARGIN = 32;
				int FONT_SIZE = h * 3;
				string FONT_NAME = "メイリオ";

				cText = canvas.GetClone();
				cText.DrawString(
					title,
					FONT_SIZE,
					FONT_NAME,
					FontStyle.Italic | FontStyle.Bold,
					new I3Color(255, 255, 255),
					new I4Rect(MARGIN, MARGIN, w - MARGIN * 2, h - MARGIN * 2),
					3
					);
			}

			canvas.Fill(new I4Color(0, 0, 0, 0));
			canvas.DrawImage(cText, 0, 0, true);

			canvas = canvas.Blur(10);
			canvas.Deepen(2.0);
			canvas = canvas.Blur(10);
			canvas.Deepen(2.0);
			canvas = canvas.Blur(10);

			canvas.DrawImage(cText, 0, 0, true);
			canvas.FilterAllDot(dot => { dot.A = SCommon.ToInt(dot.A * 0.85); return dot; });
			canvas.Save(SCommon.NextOutputPath() + ".png");
		}
	}
}
