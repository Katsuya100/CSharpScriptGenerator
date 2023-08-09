using System;
using System.Collections.Generic;

namespace Katuusagi.CSharpScriptGenerator
{
    public class PreProcessTypeGenerator
    {
        public List<PreProcessData> Result { get; private set; } = new List<PreProcessData>();

        public void Generate(Action<Children> scope)
        {
            Generate(PreProcessType.ElseIf, string.Empty, scope);
        }

        public void Generate(PreProcessType preProcessType, string symbol, Action<Children> scope)
        {
            var gen = new Children()
            {
                PreProcess = new PreProcessTypeGenerator(),
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
                Fields = gen.Field.Result,
                Properties = gen.Property.Result,
                Methods = gen.Method.Result,
                Types = gen.Type.Result,
            };
            Result.Add(preProcess);
        }

        public struct Children
        {
            public PreProcessTypeGenerator PreProcess;
            public FieldGenerator Field;
            public PropertyGenerator Property;
            public MethodGenerator Method;
            public TypeGenerator Type;
        }
    }
}
