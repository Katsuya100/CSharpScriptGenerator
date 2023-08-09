using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.CSharpScriptGenerator
{
    public class TypeData
    {
        public ModifierType Modifier = ModifierType.None;
        public string Name = string.Empty;
        public List<PreProcessData> PreProcesses = new List<PreProcessData>();
        public List<AttributeData> Attributes = new List<AttributeData>();
        public List<GenericParameterData> GenericParams = null;
        public List<BaseTypeData> BaseTypes = new List<BaseTypeData>();
        public List<FieldData> Fields = new List<FieldData>();
        public List<PropertyData> Properties = new List<PropertyData>();
        public List<MethodData> Methods = new List<MethodData>();
        public List<TypeData> Types = new List<TypeData>();
    }
}
