using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class MethodData
    {
        public ModifierType Modifier = ModifierType.None;
        public string Type = string.Empty;
        public string Name = string.Empty;
        public List<AttributeData> Attributes = new List<AttributeData>();
        public List<GenericParameterData> GenericParams = new List<GenericParameterData>();
        public List<ParameterData> Params = new List<ParameterData>();
        public CodeData Code = null;

        public void WriteLine(ScriptBuilder builder)
        {
            foreach (var attribute in Attributes)
            {
                attribute.WriteLine(builder);
            }

            builder.Append(Modifier.GetModifierLabel());
            builder.Append(Type);
            if (!string.IsNullOrEmpty(Type))
            {
                builder.Append(" ");
            }
            builder.Append(Name);

            GenericParams.Write(builder);
            Params.Write(builder);

            if ((!Code?.IsEmpty ?? true) ||
                (Modifier != ModifierType.None &&
                !Modifier.HasFlag(ModifierType.Abstract)))
            {
                builder.AppendLine(string.Empty);
                foreach (var GenericParam in GenericParams)
                {
                    GenericParam?.WriteLineWhere(builder);
                }
                builder.StartScope();
                Code.WriteLine(builder);
                builder.EndScope();
            }
            else
            {
                builder.AppendLine(";");
            }
        }
    }
}
