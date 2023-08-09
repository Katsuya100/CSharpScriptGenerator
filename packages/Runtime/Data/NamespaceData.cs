using System.Collections.Generic;

namespace Katuusagi.CSharpScriptGenerator
{
    public class NamespaceData
    {
        public string Name = string.Empty;
        public List<PreProcessData> PreProcesses = new List<PreProcessData>();
        public List<UsingData> Usings = new List<UsingData>();
        public List<NamespaceData> Namespaces = new List<NamespaceData>();
        public List<TypeData> Types = new List<TypeData>();
    }
}
