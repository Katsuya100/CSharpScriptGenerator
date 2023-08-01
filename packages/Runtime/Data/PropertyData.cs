using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class PropertyData
    {
        public ModifierType Modifier = ModifierType.None;
        public string Name = string.Empty;
        public string Type = string.Empty;
        public List<AttributeData> Attributes = new List<AttributeData>();
        public List<ParameterData> Params = new List<ParameterData>();
        public PropertyMethodData Get = null;
        public PropertyMethodData Set = null;
        public CodeData Default = null;

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
            Params.WriteIndexer(builder);

            builder.AppendLine();

            builder.StartScope();
            Get?.WriteLine(builder);
            Set?.WriteLine(builder);
            builder.EndScope();

            if (!(Default?.IsEmpty ?? true))
            {
                builder.Append(" = ");
                Default.Write(builder);
                builder.AppendLine(";");
            }
        }
    }
}
