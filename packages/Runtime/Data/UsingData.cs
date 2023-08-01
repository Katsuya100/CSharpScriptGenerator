namespace Katuusagi.ScriptGenerator
{
    public class UsingData
    {
        public string NameSpace = string.Empty;

        public void WriteLine(ScriptBuilder builder)
        {
            if (!string.IsNullOrEmpty(NameSpace))
            {
                builder.AppendLine($"using {NameSpace};");
            }
        }
    }
}
