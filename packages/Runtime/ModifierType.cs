using System;

namespace Katuusagi.CSharpScriptGenerator
{
    [Flags]
    public enum ModifierType : uint
    {
        None = 0,
        Private     = 1 << 0,
        Protected   = 1 << 1,
        Public      = 1 << 2,
        Internal    = 1 << 3,
        Partial     = 1 << 4,
        Static      = 1 << 5,
        Sealed      = 1 << 6,
        Virtual     = 1 << 7,
        Abstract    = 1 << 8,
        Override    = 1 << 9,
        Class       = 1 << 10,
        Struct      = 1 << 11,
        Record      = 1 << 12,
        Enum        = 1 << 13,
        ReadOnly    = 1 << 14,
        Const       = 1 << 15,
        Event       = 1 << 16,
        Interface   = 1 << 17,
        Ref         = 1 << 18,
        Unsafe      = 1 << 19,
    }
}
