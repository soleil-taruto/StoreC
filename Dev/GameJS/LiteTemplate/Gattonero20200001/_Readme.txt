============
LiteTemplate
============


JSゲームの軽量テンプレート


----
環境構築手順

1. プロジェクトの展開

	本プロジェクト LiteTemplate を任意の場所に展開する。

	★以降、展開先パスを <LiteTemplate> と表記します。

2. JSJoin をインストールする。

	以下のリンクから JSJoin.zip をダウンロードする。
	http://ornithopter.ccsp.mydns.jp/HPStore/Program/JSJoin.zip

	JSJoin.zip を任意の場所に展開する。

	<LiteTemplate>\Debug.bat と <LiteTemplate>\Release.bat の JSJoin.exe へのパスを今し方展開した場所へ振り直す。


----
ビルド手順

デバッグ用にビルドする場合：

	<LiteTemplate>\Debug.bat を実行する。

	ビルドに成功すると <LiteTemplate>\out\index.html が作成されます。

リリース用にビルドする場合：

	<LiteTemplate>\Release.bat を実行する。

	ビルドに成功すると <LiteTemplate>\out\index.html が作成されます。


----
フォルダ構成

<LiteTemplate>
│
│  Clean.bat           出力先フォルダをクリアするバッチ
│  Debug.bat           デバッグ用にビルドするバッチ
│  Release.bat         リリース用にビルドするバッチ
│
├─Gattonero20200001   ソースフォルダ
│  │
│  └─ ...
│
├─out                 出力先フォルダ
│
└─res                 リソースフォルダ
    │
    └─ ...


----
ソースフォルダ・ファイル構成

<LiteTemplate>\Gattonero20200001
│
│  00_Consts.js                      画面サイズに関する定数
│  Entrance.js                       ゲームの入り口画面
│  Loading.js                        ロード中画面
│  Program.js                        エントリーポイント
│  tags                              秀丸用タグファイル
│  _index_Debug.html.js              デバッグ用 index.html のテンプレート
│  _index_Release.html.js            リリース用 index.html のテンプレート
│  _Readme.txt                       このファイル
│
├─GameCommons                       ゲーム用共通機能
│      Draw.js                       描画
│      Engine.js                     コアな部分
│      Mouse.js                      マウス・タッチ操作
│      Music.js                      音楽
│      Resource.js                   リソース用
│      Resource_LoadPicture.js       リソース・画像
│      Resource_LoadSound.js         リソース・音楽
│      Resource_LoadSoundEffect.js   リソース・効果音
│      SoundEffect.js                効果音
│
├─GameCommons_Resource              リソースを変数として定義しているところ
│      Music.js                      音楽
│      Picture.js                    画像
│      SoundEffect.js                効果音
│
└─Games                             このゲーム固有の機能
        Game.js                       ゲームの中身


このゲームの中身は <LiteTemplate>\Games\Game.js に記述します。基本的にこのファイル (及び <LiteTemplate>Games の配下) を
いじってゲームを構築します。

ゲームが開始されると <LiteTemplate>\Games\Game.js の GameMain 関数が呼び出されます。
GameMain はジェネレータ関数で yield 1; するたびに画面のリフレッシュ(次のフレーム)を待ちます。
GameMain は関数を終了 (return) してはなりません。

それ以外のファイル (<LiteTemplate>\Games 以外) は基本的に触りません。
必要に応じて修正します。


----
ソースファイルのプレーンJSとの相違点 (固有の記述内容)

TODO


----
画像リソースの追加方法

TODO


----
音楽リソースの追加方法

TODO


----
効果音リソースの追加方法

TODO

