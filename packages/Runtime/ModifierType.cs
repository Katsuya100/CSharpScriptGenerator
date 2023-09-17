using System;

namespace Katuusagi.CSharpScriptGenerator
{
    [Flags]
    public enum ModifierType : uint
    {
        None = 0,
        Public      = 1 << 0,
        Private     = 1 << 1,
        Protected   = 1 << 2,
        Internal    = 1 << 3,
        Unsafe      = 1 << 4,
        Sealed      = 1 << 5,
        Static      = 1 << 6,
        Partial     = 1 << 7,
        ReadOnly    = 1 << 8,
        This        = 1 << 9,
        Ref         = 1 << 10,
        In          = 1 << 11,
        Out         = 1 << 12,
        Params      = 1 << 13,
        Const       = 1 << 14,
        Volatile    = 1 << 15,
        Extern      = 1 << 16,
        Abstract    = 1 << 17,
        Virtual     = 1 << 18,
        Override    = 1 << 19,
        New         = 1 << 20,
        Async       = 1 << 21,
        Record      = 1 << 22,
        Class       = 1 << 23,
        Struct      = 1 << 24,
        Interface   = 1 << 25,
    }
}
