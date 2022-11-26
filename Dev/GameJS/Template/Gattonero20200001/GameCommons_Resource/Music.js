/*
	音楽
*/

function <Sound_t> @@_Load(<string> url)
{
	return LoadSound(url);
}

// ここから各種音楽

// 慣習的プリフィクス == M_

var<Sound_t> M_Muon = @@_Load(RESOURCE_General__muon_mp3);
