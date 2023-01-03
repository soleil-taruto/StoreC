/*
	壁紙 - None
*/

var<int> WallKind_None = @(AUTO);

function <Wall_t> CreateWall_None()
{
	var ret =
	{
		// ここから固有
	};

	ret.Draw = @@_Draw(ret);

	return ret;
}

function* <generatorForTask> @@_Draw(<Wall_t> wall)
{
	for (; ; )
	{
		// noop

		yield 1;
	}
}
