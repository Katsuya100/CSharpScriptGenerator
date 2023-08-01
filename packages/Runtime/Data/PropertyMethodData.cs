using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class PropertyMethodData
    {
        public ModifierType Modifier = ModifierType.None;
        public string Name = string.Empty;
        public List<AttributeData> Attributes = new List<AttributeData>();
        public CodeData Code = null;

        public void WriteLine(ScriptBuilder builder)
        {
            foreach (var attribute in Attributes)
            {
                attribute.WriteLine(builder);
            }
            builder.Append(Modifier.GetModifierLabel());
            builder.Append(Name);

            if (!(Code?.IsEmpty ?? true))
            {
                builder.AppendLine(string.Empty);
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
