using System;

namespace Katuusagi.ScriptGenerator
{
    public class RootGenerator
    {
        public RootData Result { get; private set; } = new ();

        public void Generate(Action<Children> scope)
        {
            var gen = new Children()
            {
                PreProcess = new PreProcessGenerator(),
                Using = new UsingGenerator(),
                Namespace = new NamespaceGenerator(),
                Type = new TypeGenerator(),
            };
            scope?.Invoke(gen);

            Result.PreProcesses = gen.PreProcess.Result;
            Result.Usings = gen.Using.Result;
            Result.Namespaces = gen.Namespace.Result;
            Result.Types = gen.Type.Result;
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
