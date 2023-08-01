using System;

namespace Katuusagi.ScriptGenerator
{
    public class CodeGenerator
    {
        public CodeData Result { get; private set; } = new();
        private string _indent = "";

        public void Generate(string line)
        {
            Result.Lines.Add($"{_indent}{line}");
        }

        public void Generate(string line, Action scope)
        {
            Generate(line);
            Generate("{");
            _indent += "    ";
            scope?.Invoke();
            _indent = _indent.Remove(_indent.Length - 4);
            Generate("}");
        }
    }
}