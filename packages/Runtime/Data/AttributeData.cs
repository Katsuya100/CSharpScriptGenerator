using System.Collections.Generic;

namespace Katuusagi.CSharpScriptGenerator
{
    public class AttributeData
    {
        public ITypeNameData Type = null;
        public List<IStatementData> Args = new List<IStatementData>();
    }
}
