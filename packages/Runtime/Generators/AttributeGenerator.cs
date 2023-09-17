using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.CSharpScriptGenerator
{
    public class AttributeGenerator
    {
        public List<AttributeData> Result { get; private set; } = new List<AttributeData>();

        public void Generate(string type)
        {
            Generate(g =>
            {
                g.Type.Generate(type);
            });
        }

        public void Generate(Action<Children> scope)
        {
            var gen = new Children()
            {
                Type = new TypeNameGenerator(),
                Arg = new StatementGenerator(),
            };
            scope?.Invoke(gen);

            var data = new AttributeData()
            {
                Type = gen.Type.Result.LastOrDefault(),
                Args = gen.Arg.Result,
            };
            Result.Add(data);
        }

        public struct Children
        {
            public TypeNameGenerator Type;
            public StatementGenerator Arg;
        }
    }
}
