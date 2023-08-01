using System;
using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class WhereGenerator
    {
        public List<WhereData> Result { get; private set; } = new();

        public void Generate(string where)
        {
            var whereData = new WhereData()
            {
                Where = where,
            };
            Result.Add(whereData);
        }
    }
}
