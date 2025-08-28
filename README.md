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
