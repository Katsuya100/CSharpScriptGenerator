using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class RootData
    {
        public List<PreProcessData> PreProcesses = new List<PreProcessData>();
        public List<UsingData> Usings = new List<UsingData>();
        public List<NamespaceData> Namespaces = new List<NamespaceData>();
        public List<TypeData> Types = new List<TypeData>();

        public void WriteLine(ScriptBuilder builder)
        {
            PreProcesses.WriteLine(builder);

            foreach (var uzing in Usings)
            {
                uzing.WriteLine(builder);
            }

            foreach (var namespase in Namespaces)
            {
                namespase.WriteLine(builder);
            }

            foreach (var type in Types)
            {
                type.WriteLine(builder);
            }
        }
    }
}
