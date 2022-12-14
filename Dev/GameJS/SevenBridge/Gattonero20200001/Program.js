/*
	アプリケーション用メインモジュール
*/

setTimeout(Main, 0);

function <void> Main()
{
	@@_Loading();
}

function <void> @@_Loading()
{
	if (1 <= Loading)
	{
		PrintGameLoading();
		setTimeout(@@_Loading, 100);
	}
	else
	{
		PrintGameLoaded();
		@@_Loaded();
	}
}

function <void> @@_Loaded()
{
	ProcMain(@@_Main());
}

function* <generatorForTask> @@_Main()
{
	if (DEBUG)
	{
		// -- choose one --

//		yield* Test01();
//		yield* Test02();
//		yield* Test03();
//		yield* Test04();
//		yield* Test05();
		yield* @@_Main2();

		// --
	}
	else
	{
		yield* @@_Main2();
	}
}

function* <generatorForTask> @@_Main2()
{
	yield* EntranceMain();
}
