using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class AttributeGenerator
    {
        public List<AttributeData> Result { get; private set; } = new();

        public void Generate(string attribute)
        {
            var attr = new AttributeData()
            {
                Attribute = attribute
            };
            Result.Add(attr);
        }
    }
}
