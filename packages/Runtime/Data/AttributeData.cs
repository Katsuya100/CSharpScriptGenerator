namespace Katuusagi.ScriptGenerator
{
    public class AttributeData
    {
        public string Attribute = string.Empty;
        public void WriteLine(ScriptBuilder builder)
        {
            if (!string.IsNullOrEmpty(Attribute))
            {
                builder.AppendLine($"[{Attribute}]");
            }
        }
        public void Write(ScriptBuilder builder)
        {
            if (!string.IsNullOrEmpty(Attribute))
            {
                builder.Append($"[{Attribute}]");
            }
        }
    }
}
