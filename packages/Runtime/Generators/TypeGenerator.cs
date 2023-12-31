using System;
using System.Collections.Generic;

namespace Katuusagi.CSharpScriptGenerator
{
    public class TypeGenerator
    {
        public List<TypeData> Result { get; private set; } = new List<TypeData>();

        public void Generate(ModifierType modifier, string name, Action<Children> scope)
        {
            var gen = new Children()
            {
                BaseType = new TypeNameGenerator(),
                PreProcess = new PreProcessTypeGenerator(),
                Attribute = new AttributeGenerator(),
                GenericParam = new GenericParameterGenerator(),
                Event = new EventGenerator(),
                Field = new FieldGenerator(),
                Property = new PropertyGenerator(),
                Method = new MethodGenerator(),
                Delegate = new DelegateGenerator(),
                Enum = new EnumGenerator(),
                Type = new TypeGenerator(),
            };
            scope?.Invoke(gen);

            var type = new TypeData()
            {
                Modifier = modifier,
                Name = name,
                BaseTypes = gen.BaseType.Result,
                PreProcesses = gen.PreProcess.Result,
                Attributes = gen.Attribute.Result,
                GenericParams = gen.GenericParam.Result,
                Events = gen.Event.Result,
                Fields = gen.Field.Result,
                Properties = gen.Property.Result,
                Methods = gen.Method.Result,
                Delegates = gen.Delegate.Result,
                Enums = gen.Enum.Result,
                Types = gen.Type.Result,
            };
            Result.Add(type);
        }

        public struct Children
        {
            public TypeNameGenerator BaseType;
            public PreProcessTypeGenerator PreProcess;
            public AttributeGenerator Attribute;
            public GenericParameterGenerator GenericParam;
            public EventGenerator Event;
            public FieldGenerator Field;
            public PropertyGenerator Property;
            public MethodGenerator Method;
            public DelegateGenerator Delegate;
            public EnumGenerator Enum;
            public TypeGenerator Type;
        }
    }
}
