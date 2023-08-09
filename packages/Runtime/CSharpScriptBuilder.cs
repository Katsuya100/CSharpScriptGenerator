using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.CSharpScriptGenerator
{
    public class CSharpScriptBuilder : ScriptBuilderBase
    {
        public void BuildAndNewLine(RootData data)
        {
            if (data == null)
            {
                return;
            }

            BuildAndNewLine(data.PreProcesses);

            foreach (var uzing in data.Usings)
            {
                BuildAndNewLine(uzing);
            }

            foreach (var namespase in data.Namespaces)
            {
                BuildAndNewLine(namespase);
            }

            foreach (var type in data.Types)
            {
                BuildAndNewLine(type);
            }
        }

        public void BuildAndNewLine(PreProcessData data)
        {
            if (data == null)
            {
                return;
            }

            BuildAndNewLine(data.PreProcesses);

            foreach (var uzing in data.Usings)
            {
                BuildAndNewLine(uzing);
            }

            foreach (var namespase in data.Namespaces)
            {
                BuildAndNewLine(namespase);
            }

            foreach (var field in data.Fields)
            {
                BuildAndNewLine(field);
            }

            foreach (var property in data.Properties)
            {
                BuildAndNewLine(property);
            }

            foreach (var method in data.Methods)
            {
                BuildAndNewLine(method);
            }

            foreach (var type in data.Types)
            {
                BuildAndNewLine(type);
            }
        }

        public void BuildAndNewLine(UsingData data)
        {
            if (data == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(data.NameSpace))
            {
                AppendLine($"using {data.NameSpace};");
            }
        }

        public void BuildAndNewLine(NamespaceData data)
        {
            if (data == null)
            {
                return;
            }

            Append("namespace ");
            AppendLine(data.Name);
            StartScope();

            BuildAndNewLine(data.PreProcesses);

            foreach (var uzing in data.Usings)
            {
                BuildAndNewLine(uzing);
            }

            foreach (var namespase in data.Namespaces)
            {
                BuildAndNewLine(namespase);
            }

            foreach (var type in data.Types)
            {
                BuildAndNewLine(type);
            }

            EndScope();
        }

        public void BuildAndNewLine(TypeData data)
        {
            if (data == null)
            {
                return;
            }

            var isPartialStruct = data.Modifier.HasFlag(ModifierType.Struct) && data.Modifier.HasFlag(ModifierType.Partial);
            if (isPartialStruct)
            {
                AppendLine("#pragma warning disable CS0282");
            }

            foreach (var attribute in data.Attributes)
            {
                BuildAndNewLine(attribute);
            }

            Append(data.Modifier.GetModifierLabel());
            Append(data.Name);
            Build(data.GenericParams);
            if (data.BaseTypes.Any())
            {
                Append(":");
                for (int i = 0; i < data.BaseTypes.Count; ++i)
                {
                    var baseType = data.BaseTypes[i];
                    Build(baseType);
                    Append(", ");
                }
                RemoveBack(2);
            }

            AppendLine();

            foreach (var genericParam in data.GenericParams)
            {
                BuildAndNewLineWhere(genericParam);
            }

            if (isPartialStruct)
            {
                AppendLine("#pragma warning restore CS0282");
            }

            StartScope();

            BuildAndNewLine(data.PreProcesses);

            foreach (var field in data.Fields)
            {
                BuildAndNewLine(field);
            }

            foreach (var prop in data.Properties)
            {
                BuildAndNewLine(prop);
            }

            foreach (var method in data.Methods)
            {
                BuildAndNewLine(method);
            }

            foreach (var type in data.Types)
            {
                BuildAndNewLine(type);
            }
            EndScope();
        }

        public void Build(BaseTypeData data)
        {
            if (data == null)
            {
                return;
            }

            Append(data.Name);
        }

        public void Build(GenericParameterData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                Build(attribute);
            }

            Append(data.Name);
        }

        public void BuildAndNewLineWhere(GenericParameterData data)
        {
            if (data == null ||
                !data.Wheres.Any())
            {
                return;
            }

            Append($"where {data.Name}: ");
            foreach (var where in data.Wheres)
            {
                Build(where);
                Append(", ");
            }

            RemoveBack(2);
            AppendLine();
        }

        public void Build(WhereData data)
        {
            if (data == null)
            {
                return;
            }

            Append(data.Where);
        }

        public void BuildAndNewLine(AttributeData data)
        {
            if (data == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(data.Attribute))
            {
                AppendLine($"[{data.Attribute}]");
            }
        }

        public void Build(AttributeData data)
        {
            if (data == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(data.Attribute))
            {
                Append($"[{data.Attribute}]");
            }
        }

        public void BuildAndNewLine(FieldData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                BuildAndNewLine(attribute);
            }

            Append(data.Modifier.GetModifierLabel());
            Append(data.Type);
            Append(" ");
            Append(data.Name);
            if (!(data.Default?.IsEmpty ?? true))
            {
                Append(" = ");
                Build(data.Default);
            }

            AppendLine(";");
        }

        public void BuildAndNewLine(PropertyData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                BuildAndNewLine(attribute);
            }

            Append(data.Modifier.GetModifierLabel());
            Append(data.Type);
            Append(" ");
            Append(data.Name);
            BuildIndexer(data.Params);

            AppendLine();

            StartScope();
            BuildAndNewLine(data.Get);
            BuildAndNewLine(data.Set);
            EndScope();

            if (!(data.Default?.IsEmpty ?? true))
            {
                Append(" = ");
                Build(data.Default);
                AppendLine(";");
            }
        }

        public void BuildAndNewLine(PropertyMethodData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                BuildAndNewLine(attribute);
            }
            Append(data.Modifier.GetModifierLabel());
            Append(data.Name);

            if (!(data.Code?.IsEmpty ?? true))
            {
                AppendLine(string.Empty);
                StartScope();
                BuildAndNewLine(data.Code);
                EndScope();
            }
            else
            {
                AppendLine(";");
            }
        }

        public void BuildAndNewLine(MethodData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                BuildAndNewLine(attribute);
            }

            Append(data.Modifier.GetModifierLabel());
            Append(data.Type);
            if (!string.IsNullOrEmpty(data.Type))
            {
                Append(" ");
            }
            Append(data.Name);

            Build(data.GenericParams);
            Build(data.Params);

            if ((!data.Code?.IsEmpty ?? true) ||
                (data.Modifier != ModifierType.None &&
                !data.Modifier.HasFlag(ModifierType.Abstract)))
            {
                AppendLine(string.Empty);
                foreach (var genericParam in data.GenericParams)
                {
                    BuildAndNewLineWhere(genericParam);
                }
                StartScope();
                BuildAndNewLine(data.Code);
                EndScope();
            }
            else
            {
                AppendLine(";");
            }
        }

        public void Build(ParameterData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var attribute in data.Attributes)
            {
                Build(attribute);
            }

            Append(data.Type);
            Append(" ");
            Append(data.Name);
            if (!(data.Default?.IsEmpty ?? true))
            {
                Append(" = ");
                Build(data.Default);
            }
        }

        public void BuildAndNewLine(CodeData data)
        {
            if (data == null)
            {
                return;
            }

            foreach (var line in data.Lines)
            {
                AppendLine(line);
            }
        }

        public void Build(CodeData data)
        {
            if (data == null)
            {
                return;
            }

            if (data.Lines.Any())
            {
                Append(data.Lines.First());
            }
        }

        public void Build(List<GenericParameterData> data)
        {
            if (data == null ||
                !data.Any())
            {
                return;
            }

            Append("<");
            foreach (var param in data)
            {
                Build(param);
                Append(", ");
            }

            RemoveBack(2);
            Append(">");
        }

        public void Build(List<ParameterData> data)
        {
            Append("(");
            if (data != null &&
                data.Any())
            {
                foreach (var param in data)
                {
                    Build(param);
                    Append(", ");
                }

                RemoveBack(2);
            }

            Append(")");
        }

        public void BuildIndexer(List<ParameterData> data)
        {
            if (data == null ||
                !data.Any())
            {
                return;
            }

            Append("[");
            foreach (var param in data)
            {
                Build(param);
                Append(", ");
            }

            RemoveBack(2);
            Append("]");
        }

        public void BuildAndNewLine(List<PreProcessData> data)
        {
            if (data == null ||
                !data.Any())
            {
                return;
            }

            PreProcessData prev = null;
            for (int i = 0; i < data.Count; ++i)
            {
                var current = data[i];

                var currentType = current.PreProcessType;
                if (prev == null)
                {
                    currentType = PreProcessType.If;
                }

                var existSymbol = !string.IsNullOrEmpty(current.Symbol);
                switch (currentType)
                {
                    case PreProcessType.If:
                        {
                            if (!existSymbol)
                            {
                                continue;
                            }

                            AppendLine($"#if {current.Symbol}");
                        }
                        break;
                    case PreProcessType.ElseIf:
                        {
                            if (existSymbol)
                            {
                                AppendLine($"#elif {current.Symbol}");
                            }
                            else
                            {
                                AppendLine($"#else");
                            }
                        }
                        break;
                }

                BuildAndNewLine(current);

                var nextType = i + 1 < data.Count ? data[i + 1].PreProcessType : PreProcessType.If;
                if (nextType == PreProcessType.If ||
                    (currentType == PreProcessType.ElseIf && !existSymbol))
                {
                    AppendLine($"#endif");
                    prev = null;
                }
                else
                {
                    prev = current;
                }
            }
        }
    }
}
