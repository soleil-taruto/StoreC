/*
	壁紙 - Simple
*/

var<int> WallKind_Simple = @(AUTO);

function <Wall_t> CreateWall_Simple(<Picture_t> picture)
{
	var ret =
	{
		// ここから固有

		<Picture_t> Picture: picture,
	};

	ret.Draw = @@_Draw(ret);

	return ret;
}

function* <generatorForTask> @@_Draw(<Wall_t> wall)
{
	var<double> SLIDE_RATE = 0.1;

	var<Picture_t> wallImg = wall.Picture;
	var<int> wallImg_w = GetPicture_W(wallImg);
	var<int> wallImg_h = GetPicture_H(wallImg);

	var<int> cam_w = Map.W * TILE_W - Screen_W;
	var<int> cam_h = Map.H * TILE_H - Screen_H;

	var<double> slide_w = cam_w * SLIDE_RATE;
	var<double> slide_h = cam_h * SLIDE_RATE;

	var<double> wall_w = slide_w + Screen_W;
	var<double> wall_h = slide_h + Screen_H;

	var<D4Rect_t> wallRect = AdjustRectExterior(
		CreateD2Size(wallImg_w, wallImg_h),
		CreateD4Rect(0.0, 0.0, wall_w, wall_h)
		);

	for (; ; )
	{
		var<double> x = cam_w == 0 ? 0.0 : Camera.X / cam_w;
		var<double> y = cam_h == 0 ? 0.0 : Camera.Y / cam_h;

		x *= slide_w;
		y *= slide_h;

		var<D4Rect_t> drRect = CreateD4Rect(
			wallRect.L - x,
			wallRect.T - y,
			wallRect.W,
			wallRect.H
			);

		var<double> dx = drRect.L + drRect.W / 2.0;
		var<double> dy = drRect.T + drRect.H / 2.0;
		var<double> dz = drRect.W / wallImg_w;
//		var<double> dz = drRect.H / wallImg_h;

		Draw(wallImg, dx, dy, 1.0, 0.0, dz);

		DrawCurtain(-0.5);

		yield 1;
	}
}
