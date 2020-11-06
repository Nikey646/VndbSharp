using System;

namespace VndbSharp.Interfaces
{
    public interface IVndbError
    {
        ErrorType Type { get; init; }
        String Message { get; init; }
    }
}
