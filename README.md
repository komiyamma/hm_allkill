# HmAllKill

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/komiyamma/hm_allkill)](https://github.com/komiyamma/hm_allkill/releases/latest)
[![CC0](https://img.shields.io/badge/license-CC0-blue.svg?style=flat)](LICENSE.txt)
実行中のすべての「秀丸エディタ」プロセス（`hidemaru.exe`）を一括終了させるコマンドラインツールです。

## 概要

`HmAllKill.exe` は、まず「秀丸エディタ」プロセスのウィンドウに対して `WM_CLOSE` メッセージを送信し、自然終了を試みます。約600ms（3回）待機後もプロセスが残っている場合は、強制終了（Kill）を実行します。

これにより、開かれているすべての秀丸エディタのウィンドウや、タスクトレイ常駐の秀丸エディタもまとめて終了できます。

## 主な用途

- 秀丸エディタのバージョンアップや設定ファイル更新時の自動化バッチの先頭で実行し、ファイル更新の失敗を防止
- 複数PCの秀丸環境統一や、管理用スクリプトでの一括終了

## 動作環境

- Microsoft .NET Framework 4.8 以上（.NET 4.8でビルド済み）
- Windows 10/11

## 使い方

1. ダウンロードした `HmAllKill.exe` を任意の場所に配置します。
2. コマンドプロンプトやバッチファイル等から以下のように実行します。

```shell
HmAllKill.exe
```

実行すると、確認なしに即座にすべての秀丸エディタが終了します。作業中のファイルがある場合は保存されませんのでご注意ください。

## ビルド方法

このプロジェクトは C# で書かれており、**Visual Studio 2022** でビルドできます。

1. `HmAllKill.src/HmAllKill.sln` を Visual Studio 2022 で開きます。
2. 「ソリューションのビルド」を実行します。
3. `HmAllKill.src/HmAllKill/bin/Release/` に `HmAllKill.exe` が生成されます。
# HmAllKill

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/komiyamma/hm_allkill)](https://github.com/komiyamma/hm_allkill/releases/latest)
[![CC0](https://img.shields.io/badge/license-CC0-blue.svg?style=flat)](LICENSE.txt)

実行中のすべての「秀丸エディタ」および「秀丸常駐エディタ」を瞬時に終了させるためのコマンドラインツールです。

## 概要

`HmAllKill.exe` は、プロセス名 `hidemaru` を持つすべてのプロセスを検索し、強制的に終了させます。これにより、開かれているすべての秀丸エディタのウィンドウと、タスクトレイに常駐している秀丸エディタを一括で閉じることができます。

## 主な用途

秀丸エディタ本体のバージョンアップや設定ファイルの更新などを、バッチファイルやスクリプトで自動化する際に役立ちます。

例えば、企業内で複数のPCの秀丸エディタ環境を統一したい場合、サーバー上の新しいプログラム群を各PCに配布・更新するスクリプトを組むことがあります。その際、更新対象となる秀丸エディタのプロセスが実行中だと、ファイルの置き換えに失敗する可能性があります。

`HmAllKill` をスクリプトの最初に実行することで、すべての秀丸関連プロセスを確実に終了させ、安全なファイル更新を保証します。

## 動作環境

*   Microsoft .NET Framework 4.0 以上

## 使い方

ダウンロードした `HmAllKill.exe` を任意の場所に配置し、コマンドプロンプトやバッチファイルから実行してください。

```shell
HmAllKill.exe
```

実行すると、確認なしに即座にすべての秀丸エディタが終了しますので、ご注意ください。

## ビルド方法

このプロジェクトは C# で書かれており、Visual Studio 2017 以降でビルドすることができます。

1.  `HmAllKill.src/HmAllKill.sln` を Visual Studio で開きます。
2.  ビルドメニューから「ソリューションのビルド」を選択します。
3.  `HmAllKill.src/HmAllKill/bin/Release/` ディレクトリ内に `HmAllKill.exe` が生成されます。

## ライセンス

このプロジェクトは **CC0 1.0 Universal (パブリックドメイン)** です。詳細は [LICENSE.txt](LICENSE.txt) をご覧ください。

---

- **配布元:** [https://秀丸マクロ.net/?page=nobu_tool_hm_allkill](https://秀丸マクロ.net/?page=nobu_tool_hm_allkill)
- **ソースコード:** [https://github.com/komiyamma/hm_allkill](https://github.com/komiyamma/hm_allkill)
