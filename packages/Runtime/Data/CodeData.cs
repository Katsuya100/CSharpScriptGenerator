using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class CodeData
    {
        public List<string> Lines = new List<string>();
        public bool IsEmpty => Lines.Count <= 0;

        public void WriteLine(ScriptBuilder builder)
        {
            foreach (var line in Lines)
            {
                builder.AppendLine(line);
            }
        }

        public void Write(ScriptBuilder builder)
        {
            if (Lines.Any())
            {
                builder.Append(Lines.First());
            }
        }
    }
}
