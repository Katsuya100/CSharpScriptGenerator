using System;
using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class PreProcessGenerator
    {
        public List<PreProcessData> Result { get; private set; } = new();

        public void Generate(Action<Children> scope)
        {
            Generate(PreProcessType.ElseIf, string.Empty, scope);
        }

        public void Generate(PreProcessType preProcessType, string symbol, Action<Children> scope)
        {
            var gen = new Children()
            {
                PreProcess = new PreProcessGenerator(),
                Using = new UsingGenerator(),
                Namespace = new NamespaceGenerator(),
                Field = new FieldGenerator(),
                Property = new PropertyGenerator(),
                Method = new MethodGenerator(),
                Type = new TypeGenerator(),
            };
            scope?.Invoke(gen);

            var preProcess = new PreProcessData()
            {
                PreProcessType = preProcessType,
                Symbol = symbol,
                PreProcesses = gen.PreProcess.Result,
                Usings = gen.Using.Result,
                Namespaces = gen.Namespace.Result,
                Fields = gen.Field.Result,
                Properties = gen.Property.Result,
                Methods = gen.Method.Result,
                Types = gen.Type.Result,
            };
            Result.Add(preProcess);
        }

        public struct Children
        {
            public PreProcessGenerator PreProcess;
            public UsingGenerator Using;
            public NamespaceGenerator Namespace;
            public FieldGenerator Field;
            public PropertyGenerator Property;
            public MethodGenerator Method;
            public TypeGenerator Type;
        }
    }
}
