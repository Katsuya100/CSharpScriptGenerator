# CSharpScriptGenerator
## 概要
本ライブラリ「CSharpScriptGenerator」はC#のスクリプトを生成するためのライブラリです。  
UPMに対応しているため、直接Unity内でScript生成に活用しても良いですし、SourceGeneratorの補助として使う事もできます。  

## 動作確認環境
|  環境  |  バージョン  |
| ---- | ---- |
| Unity | 2021.3.15f1, 2022.3.2f1 |
| .Net | 4.x, Standard 2.0, Standard 2.1 |

## インストール方法
### CSharpScriptGeneratorのインストール
1. [Window > Package Manager]を開く。
2. [+ > Add package from git url...]をクリックする。
3. `https://github.com/Katsuya100/CSharpScriptGenerator.git?path=packages`と入力し[Add]をクリックする。

#### うまくいかない場合
上記方法は、gitがインストールされていない環境ではうまく動作しない場合があります。
[Releases](https://github.com/Katsuya100/CSharpScriptGenerator/releases)から該当のバージョンの`com.katuusagi.csharpscriptgenerator.tgz`をダウンロードし
[Package Manager > + > Add package from tarball...]を使ってインストールしてください。

#### それでもうまくいかない場合
[Releases](https://github.com/Katsuya100/CSharpScriptGenerator/releases)から該当のバージョンの`Katuusagi.CSharpScriptGenerator.unitypackage`をダウンロードし
[Assets > Import Package > Custom Package]からプロジェクトにインポートしてください。

## 使い方
### 通常の使用法
以下の記法でC#のScriptを出力できます。  
```.cs
var root = new RootGenerator();
root.Generate(rg =>
{
    rg.Using.Generate("UnityEngine");

    rg.Namespace.Generate("Example.NameSpace", ng =>
    {
        ng.Type.Generate(ModifierType.Public | ModifierType.Class, "HelloWorld", tg =>
        {
            tg.Method.Generate(ModifierType.Public, "void", "Dump", mg =>
            {
                mg.Param.Generate("bool", "check");

                mg.Statement.Generate("if (check)", () =>
                {
                    mg.Statement.Generate("Debug.Log(\"HelloWorld\");");
                });
            });
        });
    });
});

var builder = new CSharpScriptBuilder();
builder.BuildAndNewLine(root.Result);
var script = builder.ToString();
File.WriteAllText("HelloWorld.cs", script);
```
#### 出力結果
```HelloWorld.cs
using UnityEngine;
namespace Example.NameSpace
{
    public class HelloWorld
    {
        public void Dump(bool check)
        {
            if (check)
            {
                Debug.Log("HelloWorld");
            }
        }
    }
}
```
