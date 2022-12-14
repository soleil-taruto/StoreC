/*
	画像
*/

function <Picture_t> @@_Load(<string> url)
{
	return LoadPicture(url);
}

// ここから各種画像

// プリフィクス
// P_ ... 画像

var<Picture_t> P_Dummy = @@_Load(RESOURCE_General__Dummy_png);
var<Picture_t> P_WhiteBox = @@_Load(RESOURCE_General__WhiteBox_png);
var<Picture_t> P_WhiteCircle = @@_Load(RESOURCE_General__WhiteCircle_png);

// ★ここまで固定 -- 持ち回り_共通 -- サンプルとしてキープ

var<Picture_t> P_GameStartButton = @@_Load(RESOURCE_Picture__GameStartButton_png);
var<Picture_t> P_ExplodePiece = @@_Load(RESOURCE_Picture__光る星20_png);

// ====
// 背景画像ここから
// ====

// P_Bg_XXX [ Jikantai_e ]

var<Picture_t[]> P_Bg_PC室 =
[
	@@_Load(RESOURCE_背景__PC室a_jpg),
	@@_Load(RESOURCE_背景__PC室b_jpg),
	@@_Load(RESOURCE_背景__PC室c_jpg),
	@@_Load(RESOURCE_背景__PC室d_jpg),
];

var<Picture_t[]> P_Bg_廊下 =
[
	@@_Load(RESOURCE_背景__廊下a_jpg),
	@@_Load(RESOURCE_背景__廊下b_jpg),
	@@_Load(RESOURCE_背景__廊下c_jpg),
	@@_Load(RESOURCE_背景__廊下d_jpg),
];

var<Picture_t[]> P_Bg_教室L =
[
	@@_Load(RESOURCE_背景__教室La_jpg),
	@@_Load(RESOURCE_背景__教室Lb_jpg),
	@@_Load(RESOURCE_背景__教室Lc_jpg),
	@@_Load(RESOURCE_背景__教室Ld_jpg),
];

var<Picture_t[]> P_Bg_教室M =
[
	@@_Load(RESOURCE_背景__教室Ma_jpg),
	@@_Load(RESOURCE_背景__教室Mb_jpg),
	@@_Load(RESOURCE_背景__教室Mc_jpg),
	@@_Load(RESOURCE_背景__教室Md_jpg),
];

var<Picture_t[]> P_Bg_教室R =
[
	@@_Load(RESOURCE_背景__教室Ra_jpg),
	@@_Load(RESOURCE_背景__教室Rb_jpg),
	@@_Load(RESOURCE_背景__教室Rc_jpg),
	@@_Load(RESOURCE_背景__教室Rd_jpg),
];

var<Picture_t[]> P_Bg_教室空 =
[
	@@_Load(RESOURCE_背景__教室空a_jpg),
	@@_Load(RESOURCE_背景__教室空b_jpg),
	@@_Load(RESOURCE_背景__教室空c_jpg),
	@@_Load(RESOURCE_背景__教室空d_jpg),
];

var<Picture_t[]> P_Bg_校舎裏 =
[
	@@_Load(RESOURCE_背景__校舎裏a_jpg),
	@@_Load(RESOURCE_背景__校舎裏b_jpg),
	@@_Load(RESOURCE_背景__校舎裏c_jpg),
	@@_Load(RESOURCE_背景__校舎裏d_jpg),
];

var<Picture_t[]> P_Bg_校門 =
[
	@@_Load(RESOURCE_背景__校門a_jpg),
	@@_Load(RESOURCE_背景__校門b_jpg),
	@@_Load(RESOURCE_背景__校門c_jpg),
	@@_Load(RESOURCE_背景__校門d_jpg),
];

var<Picture_t[]> P_Bg_玄関 =
[
	@@_Load(RESOURCE_背景__玄関a_jpg),
	@@_Load(RESOURCE_背景__玄関b_jpg),
	@@_Load(RESOURCE_背景__玄関c_jpg),
	@@_Load(RESOURCE_背景__玄関d_jpg),
];

var<Picture_t[]> P_Bg_階段 =
[
	@@_Load(RESOURCE_背景__階段a_jpg),
	@@_Load(RESOURCE_背景__階段b_jpg),
	@@_Load(RESOURCE_背景__階段c_jpg),
	@@_Load(RESOURCE_背景__階段d_jpg),
];

var<Picture_t[]> P_Bg_階段上 =
[
	@@_Load(RESOURCE_背景__階段上a_jpg),
	@@_Load(RESOURCE_背景__階段上b_jpg),
	@@_Load(RESOURCE_背景__階段上c_jpg),
	@@_Load(RESOURCE_背景__階段上d_jpg),
];

// ====
// 背景画像ここまで
// ====
