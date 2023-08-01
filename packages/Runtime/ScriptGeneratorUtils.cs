using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ScriptGenerator
{
    public static class ScriptGeneratorUtils
    {
        public static string GetModifierLabel(this ModifierType modifier)
        {
            string result = string.Empty;
            if (modifier.HasFlag(ModifierType.Public))
            {
                result += "public ";
            }
            else if (modifier.HasFlag(ModifierType.Protected))
            {
                result += "protected ";
            }
            else if (modifier.HasFlag(ModifierType.Private))
            {
                result += "private ";
            }
            else if (modifier.HasFlag(ModifierType.Internal))
            {
                result += "internal ";
            }

            if (modifier.HasFlag(ModifierType.Sealed))
            {
                result += "sealed ";
            }

            if (modifier.HasFlag(ModifierType.Static))
            {
                result += "static ";
            }

            if (modifier.HasFlag(ModifierType.Partial))
            {
                result += "partial ";
            }

            if (modifier.HasFlag(ModifierType.ReadOnly))
            {
                result += "readonly ";
            }

            if (modifier.HasFlag(ModifierType.Const))
            {
                result += "const ";
            }

            if (modifier.HasFlag(ModifierType.Virtual))
            {
                result += "virtual ";
            }

            if (modifier.HasFlag(ModifierType.Abstract))
            {
                result += "abstract ";
            }

            if (modifier.HasFlag(ModifierType.Override))
            {
                result += "override ";
            }

            if (modifier.HasFlag(ModifierType.Event))
            {
                result += "event ";
            }

            if (modifier.HasFlag(ModifierType.Class))
            {
                result += "class ";
            }

            if (modifier.HasFlag(ModifierType.Struct))
            {
                result += "struct ";
            }

            if (modifier.HasFlag(ModifierType.Enum))
            {
                result += "enum ";
            }

            if (modifier.HasFlag(ModifierType.Interface))
            {
                result += "interface ";
            }

            return result;
        }

        public static void Write(this List<GenericParameterData> self, ScriptBuilder builder)
        {
            if (!self.Any())
            {
                return;
            }

            builder.Append("<");
            foreach (var param in self)
            {
                param.Write(builder);
                builder.Append(", ");
            }

            builder.RemoveBack(2);
            builder.Append(">");
        }

        public static void Write(this List<ParameterData> self, ScriptBuilder builder)
        {
            builder.Append("(");
            if (self.Any())
            {
                foreach (var param in self)
                {
                    param.Write(builder);
                    builder.Append(", ");
                }

                builder.RemoveBack(2);
            }

            builder.Append(")");
        }

        public static void WriteIndexer(this List<ParameterData> self, ScriptBuilder builder)
        {
            if (!self.Any())
            {
                return;
            }

            builder.Append("[");
            foreach (var param in self)
            {
                param.Write(builder);
                builder.Append(", ");
            }

            builder.RemoveBack(2);
            builder.Append("]");
        }

        public static void WriteLine(this List<PreProcessData> self, ScriptBuilder builder)
        {
            if (!self.Any())
            {
                return;
            }

            PreProcessData prev = null;
            for (int i = 0; i < self.Count; ++i)
            {
                var current = self[i];

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

                            builder.AppendLine($"#if {current.Symbol}");
                        }
                        break;
                    case PreProcessType.ElseIf:
                        {
                            if (existSymbol)
                            {
                                builder.AppendLine($"#elif {current.Symbol}");
                            }
                            else
                            {
                                builder.AppendLine($"#else");
                            }
                        }
                        break;
                }

                current.WriteLine(builder);

                var nextType = i + 1 < self.Count ? self[i + 1].PreProcessType : PreProcessType.If;
                if (nextType == PreProcessType.If ||
                    (currentType == PreProcessType.ElseIf && !existSymbol))
                {
                    builder.AppendLine($"#endif");
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
