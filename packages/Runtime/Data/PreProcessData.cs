using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class PreProcessData
    {
        public PreProcessType PreProcessType = PreProcessType.If;
        public string Symbol = string.Empty;
        public List<PreProcessData> PreProcesses = new List<PreProcessData>();
        public List<UsingData> Usings = new List<UsingData>();
        public List<NamespaceData> Namespaces = new List<NamespaceData>();
        public List<FieldData> Fields = new List<FieldData>();
        public List<PropertyData> Properties = new List<PropertyData>();
        public List<MethodData> Methods = new List<MethodData>();
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

            foreach (var field in Fields)
            {
                field.WriteLine(builder);
            }

            foreach (var prop in Properties)
            {
                prop.WriteLine(builder);
            }

            foreach (var method in Methods)
            {
                method.WriteLine(builder);
            }

            foreach (var type in Types)
            {
                type.WriteLine(builder);
            }

            foreach (var type in Types)
            {
                type.WriteLine(builder);
            }
        }
    }
}
