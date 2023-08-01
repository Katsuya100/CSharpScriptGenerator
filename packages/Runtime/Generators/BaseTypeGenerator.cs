using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class BaseTypeGenerator
    {
        public List<BaseTypeData> Result { get; private set; } = new();

        public void Generate(string name)
        {
            var baseType = new BaseTypeData()
            {
                Name = name,
            };
            Result.Add(baseType);
        }
    }
}
