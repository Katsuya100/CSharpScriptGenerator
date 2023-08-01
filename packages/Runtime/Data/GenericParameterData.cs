using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public class GenericParameterData
    {
        public string Name = string.Empty;
        public List<AttributeData> Attributes = new List<AttributeData>();
        public List<WhereData> Wheres = new List<WhereData>();

        public void Write(ScriptBuilder builder)
        {
            foreach (var attribute in Attributes)
            {
                attribute.Write(builder);
            }

            builder.Append(Name);
        }

        public void WriteLineWhere(ScriptBuilder builder)
        {
            if (!Wheres.Any())
            {
                return;
            }

            builder.Append($"where {Name}: ");
            foreach (var where in Wheres)
            {
                where.Write(builder);
                builder.Append(", ");
            }

            builder.RemoveBack(2);
            builder.AppendLine();
        }
    }
}
