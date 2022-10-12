using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;
using Charlotte.Tests;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4(ar);
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			// -- choose one --

			Main4(new ArgsReader(new string[] { }));
			//new Test0001().Test01();
			//new Test0002().Test01();
			//new Test0003().Test01();

			// --

			SCommon.Pause();
		}

		private void Main4(ArgsReader ar)
		{
			try
			{
				Main5(ar);
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);

				MessageBox.Show("" + ex, Path.GetFileNameWithoutExtension(ProcMain.SelfFile) + " / エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//Console.WriteLine("Press ENTER key. (エラーによりプログラムを終了します)");
				//Console.ReadLine();
			}
		}

		private string WRootDir;

		private void Main5(ArgsReader ar)
		{
			if (!Directory.Exists(Consts.R_ROOT_DIR))
				throw new Exception("no R_ROOT_DIR");

			WRootDir = GetWRootDir();

			if (!Directory.Exists(WRootDir))
				throw new Exception("no WRootDir");

			Console.WriteLine("< " + Consts.R_ROOT_DIR);
			Console.WriteLine("> " + WRootDir);

			// 出力先クリア
			SCommon.DeletePath(WRootDir);
			SCommon.CreateDir(WRootDir);

			Queue<string[]> q = new Queue<string[]>();

			q.Enqueue(new string[] { Consts.R_ROOT_DIR });

			while (1 <= q.Count)
			{
				foreach (string dir in q.Dequeue())
				{
					if (IsProjectDir(dir))
					{
						CopySourceDir(dir);
					}
					else
					{
						q.Enqueue(Directory.GetDirectories(dir));
					}
				}
			}
			Console.WriteLine("done!");
		}

		private static string GetWRootDir()
		{
			foreach (char alpha in SCommon.ALPHA)
			{
				string dir = Consts.W_ROOT_DIR_BASE;

				dir = dir.Replace('?', alpha);

				if (Directory.Exists(dir))
					return dir;
			}
			throw new Exception("no W_ROOT_DIR");
		}

		private bool IsProjectDir(string dir)
		{
			return Consts.SRC_LOCAL_DIRS.Any(v => Directory.Exists(Path.Combine(dir, v)));
		}

		private void CopySourceDir(string projectDir)
		{
			foreach (string srcLocalDir in Consts.SRC_LOCAL_DIRS)
			{
				string rDir = Path.Combine(projectDir, srcLocalDir);

				if (Directory.Exists(rDir))
				{
					string wDir = SCommon.ChangeRoot(rDir, Consts.R_ROOT_DIR, WRootDir);

					ProcMain.WriteLog("< " + rDir);
					ProcMain.WriteLog("> " + wDir);

					SCommon.CopyDir(rDir, wDir);

					ProcMain.WriteLog("done");
				}
			}
		}
	}
}
