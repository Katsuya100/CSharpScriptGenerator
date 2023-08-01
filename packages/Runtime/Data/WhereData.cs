using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class WhereData
    {
        public string Where = string.Empty;

        public void Write(ScriptBuilder builder)
        {
            builder.Append(Where);
        }
    }
}
