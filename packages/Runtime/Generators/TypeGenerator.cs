using System;
using System.Collections.Generic;

namespace Katuusagi.ScriptGenerator
{
    public class TypeGenerator
    {
        public List<TypeData> Result { get; private set; } = new();

        public void Generate(ModifierType modifier, string name, Action<Children> scope)
        {
            var gen = new Children()
            {
                PreProcess = new PreProcessGenerator(),
                Attribute = new AttributeGenerator(),
                GenericParam = new GenericParameterGenerator(),
                BaseType = new BaseTypeGenerator(),
                Field = new FieldGenerator(),
                Property = new PropertyGenerator(),
                Method = new MethodGenerator(),
                Type = new TypeGenerator(),
            };
            scope?.Invoke(gen);

            var type = new TypeData()
            {
                Modifier = modifier,
                Name = name,
                PreProcesses = gen.PreProcess.Result,
                Attributes = gen.Attribute.Result,
                GenericParams = gen.GenericParam.Result,
                BaseTypes = gen.BaseType.Result,
                Fields = gen.Field.Result,
                Properties = gen.Property.Result,
                Methods = gen.Method.Result,
                Types = gen.Type.Result,
            };
            Result.Add(type);
        }

        public struct Children
        {
            public PreProcessGenerator PreProcess;
            public AttributeGenerator Attribute;
            public GenericParameterGenerator GenericParam;
            public BaseTypeGenerator BaseType;
            public FieldGenerator Field;
            public PropertyGenerator Property;
            public MethodGenerator Method;
            public TypeGenerator Type;
        }
    }
}
