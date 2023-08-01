using System;
using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class NamespaceGenerator
    {
        public List<NamespaceData> Result { get; private set; } = new();

        public void Generate(string name, Action<Children> scope)
        {
            var gen = new Children()
            {
                PreProcess = new PreProcessGenerator(),
                Using = new UsingGenerator(),
                Namespace = new NamespaceGenerator(),
                Type = new TypeGenerator(),
            };
            scope?.Invoke(gen);

            var namespase = new NamespaceData()
            {
                Name = name,
                PreProcesses = gen.PreProcess.Result,
                Usings = gen.Using.Result,
                Namespaces = gen.Namespace.Result,
                Types = gen.Type.Result,
            };
            Result.Add(namespase);
        }

        public struct Children
        {
            public PreProcessGenerator PreProcess;
            public UsingGenerator Using;
            public NamespaceGenerator Namespace;
            public TypeGenerator Type;
        }
    }
}
