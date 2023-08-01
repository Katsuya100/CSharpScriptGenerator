using System;
using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class GenericParameterGenerator
    {
        public List<GenericParameterData> Result { get; private set; } = new();

        public void Generate(string name, Action<Children> scope = null)
        {
            var gen = new Children()
            {
                Where = new WhereGenerator(),
                Attribute = new AttributeGenerator(),
            };
            scope?.Invoke(gen);

            var parameter = new GenericParameterData()
            {
                Name = name,
                Wheres = gen.Where.Result,
                Attributes = gen.Attribute.Result,
            };
            Result.Add(parameter);
        }

        public struct Children
        {
            public AttributeGenerator Attribute;
            public WhereGenerator Where;
        }
    }
}
