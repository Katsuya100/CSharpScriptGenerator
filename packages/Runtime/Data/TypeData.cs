using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
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

        public void WriteLine(ScriptBuilder builder)
        {
            var isPartialStruct = Modifier.HasFlag(ModifierType.Struct) && Modifier.HasFlag(ModifierType.Partial);
            if (isPartialStruct)
            {
                builder.AppendLine("#pragma warning disable CS0282");
            }

            foreach (var attribute in Attributes)
            {
                attribute.WriteLine(builder);
            }

            builder.Append(Modifier.GetModifierLabel());
            builder.Append(Name);
            GenericParams.Write(builder);
            if (BaseTypes.Any())
            {
                builder.Append(":");
                for (int i = 0; i < BaseTypes.Count; ++i)
                {
                    var baseType = BaseTypes[i];
                    baseType.Write(builder);
                }
                builder.RemoveBack(2);
            }

            builder.AppendLine();

            foreach (var genericParam in GenericParams)
            {
                genericParam.WriteLineWhere(builder);
            }

            if (isPartialStruct)
            {
                builder.AppendLine("#pragma warning restore CS0282");
            }

            builder.StartScope();

            PreProcesses.WriteLine(builder);

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
            builder.EndScope();
        }
    }
}
