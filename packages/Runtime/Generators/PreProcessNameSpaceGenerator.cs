using System;
using System.Collections.Generic;

namespace Katuusagi.CSharpScriptGenerator
{
    public class PreProcessNameSpaceGenerator
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
                PreProcess = new PreProcessNameSpaceGenerator(),
                Using = new UsingGenerator(),
                Namespace = new NamespaceGenerator(),
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
                Types = gen.Type.Result,
            };
            Result.Add(preProcess);
        }

        public struct Children
        {
            public PreProcessNameSpaceGenerator PreProcess;
            public UsingGenerator Using;
            public NamespaceGenerator Namespace;
            public TypeGenerator Type;
        }
    }
}
