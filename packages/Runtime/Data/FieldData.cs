using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class FieldData
    {
        public ModifierType Modifier = ModifierType.None;
        public string Type = string.Empty;
        public string Name = string.Empty;
        public CodeData Default = null;
        public List<AttributeData> Attributes = null;

        public void WriteLine(ScriptBuilder builder)
        {
            foreach (var attribute in Attributes)
            {
                attribute.WriteLine(builder);
            }

            builder.Append(Modifier.GetModifierLabel());
            builder.Append(Type);
            builder.Append(" ");
            builder.Append(Name);
            if (!(Default?.IsEmpty ?? true))
            {
                builder.Append(" = ");
                Default.Write(builder);
            }

            builder.AppendLine(";");
        }
    }
}
