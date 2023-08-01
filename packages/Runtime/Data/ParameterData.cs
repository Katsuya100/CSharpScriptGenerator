using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class ParameterData
    {
        public string Type = string.Empty;
        public string Name = string.Empty;
        public List<AttributeData> Attributes = new List<AttributeData>();
        public CodeData Default = null;

        public void Write(ScriptBuilder builder)
        {
            foreach (var attribute in Attributes)
            {
                attribute.Write(builder);
            }

            builder.Append(Type);
            builder.Append(" ");
            builder.Append(Name);
            if (!(Default?.IsEmpty ?? true))
            {
                builder.Append(" = ");
                Default.Write(builder);
            }
        }
    }
}
