/*
	描画
*/

// 画像の幅を取得する。
function <int> GetPicture_W(<Picture_t> picture)
{
	return picture.Handle.naturalWidth;
}

// 画像の高さを取得する。
function <int> GetPicture_H(<Picture_t> picture)
{
	return picture.Handle.naturalHeight;
}

// スクリーンのクリア
function <void> ClearScreen()
{
	Context.clearRect(0, 0, Screen_W, Screen_H);
}

var<double> DrawSlide_X = 0.0;
var<double> DrawSlide_Y = 0.0;

/*
	描画

	x: 画像の中心とする X-座標
	y: 画像の中心とする Y-座標
	a: 不透明度 (0.0 透明 〜 1.0 不透明)
	r: 回転
		0.0 == 回転無し
		2*PI == 時計回りに1回転
		-2*PI == 反時計回りに1回転
	z: 拡大率
		1.0 == 等倍
		2.0 == 2倍
		0.5 == 0.5倍
*/
function <void> Draw(<Picture_t> picture, <double> x, <double> y, <double> a, <double> r, <double> z)
{
	Draw2(picture, x, y, a, r, z, z);
}

function <void> Draw2(<Picture_t> picture, <double> x, <double> y, <double> a, <double> r, <double> zw, <double> zh)
{
	x += DrawSlide_X;
	y += DrawSlide_Y;

	var<int> w = GetPicture_W(picture);
	var<int> h = GetPicture_H(picture);

	w *= zw;
	h *= zh;

	var<double> l = x - w / 2;
	var<double> t = y - h / 2;

	Context.translate(x, y);
	Context.rotate(r);
	Context.translate(-x, -y);
	Context.globalAlpha = a;

	Context.drawImage(picture.Handle, l, t, w, h);

	// restore
	Context.translate(x, y);
	Context.rotate(-r);
	Context.translate(-x, -y);
	Context.globalAlpha = 1.0;

	@@_CheckHover(picture, CreateD4Rect(l, t, w, h));
}

var<Picture_t> HoveredPicture = null;
var<Picture_t> @@_CH_CurrHoveredPicture = null;
var<int> @@_CH_LastProcFrame = 0;

function <void> @@_CheckHover(<Picture_t> picture, <D4Rect_t> pictureRect)
{
	if (@@_CH_LastProcFrame != ProcFrame)
	{
		HoveredPicture = @@_CH_CurrHoveredPicture;
		@@_CH_CurrHoveredPicture = null;
		@@_CH_LastProcFrame = ProcFrame;
	}

	var<D2Point_t> mousePt = CreateD2Point(GetMouseX(), GetMouseY());

	if (!IsOut(mousePt, pictureRect, 0.0))
	{
		@@_CH_CurrHoveredPicture = picture;
	}
}
