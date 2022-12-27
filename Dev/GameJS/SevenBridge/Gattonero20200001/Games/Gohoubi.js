/*
	GohoubiMain
*/

function* <generatorForTask> GohoubiMain()
{
	FreezeInput();

	for (; ; )
	{
		if (GetMouseDown() == -1)
		{
			break;
		}

		ClearScreen();

		SetColor("#ff00ff");
		SetFSize(60);
		SetPrint(100, 100, 100);

		PrintLine("クリア画面");
		PrintLine("(試作版につき未実装)");
		PrintLine("画面をタップして下さい...");

		yield 1;
	}
	FreezeInput();
}
