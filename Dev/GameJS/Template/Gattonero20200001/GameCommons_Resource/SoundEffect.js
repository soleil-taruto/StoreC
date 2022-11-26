/*
	効果音
*/

function <SE_t> @@_Load(<string> url)
{
	return LoadSE(url);
}

// ここから各種効果音

// 慣習的プリフィクス == S_

var<SE_t> S_Coin04 = @@_Load(RESOURCE_KomoriTaira__coin04_mp3);
