using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class UsingGenerator
    {
        public List<UsingData> Result { get; private set; } = new ();

        public void Generate(string namespase)
        {
            var uzing = new UsingData()
            {
                NameSpace = namespase
            };
            Result.Add(uzing);
        }
    }
}
