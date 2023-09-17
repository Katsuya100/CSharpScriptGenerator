# CSharpScriptGenerator
[日本語](README_ja.md)

## Summary
This library "CSharpScriptGenerator" is a library for generating C# scripts.  
Since it supports UPM, you can utilize it directly for script generation in Unity, or you can use it as a supplement to SourceGenerator.  

## System Requirements
|  Environment  |  Version  |
| ---- | ---- |
| Unity | 2021.3.15f1, 2022.3.2f1 |
| .Net | 4.x, Standard 2.0, Standard 2.1 |

### Installing CSharpScriptGenerator
1. Open [Window > Package Manager].
2. click [+ > Add package from git url...].
3. Type `https://github.com/Katsuya100/CSharpScriptGenerator.git?path=packages` and click [Add].

#### If it doesn't work
The above method may not work well in environments where git is not installed.  
Download the appropriate version of `com.katuusagi.csharpscriptgenerator.tgz` from [Releases](https://github.com/Katsuya100/CSharpScriptGenerator/releases), and then [Package Manager > + > Add package from tarball...] Use [Package Manager > + > Add package from tarball...] to install the package.

#### If it still doesn't work
Download the appropriate version of `Katuusagi.CSharpScriptGenerator.unitypackage` from [Releases](https://github.com/Katsuya100/CSharpScriptGenerator/releases) and Import it into your project from [Assets > Import Package > Custom Package].

## How to Use
### Normal usage
The following notation can be used to output C# Script.  
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
#### Result
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
