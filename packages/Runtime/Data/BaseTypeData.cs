namespace Katuusagi.ScriptGenerator
{
    public class BaseTypeData
    {
        public string Name = string.Empty;
        public void Write(ScriptBuilder builder)
        {
            builder.Append(Name);
        }
    }
}
