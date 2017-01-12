using System;
using VndbSharp.Enums;

namespace VndbSharp.Interfaces
{
	public interface IVndbError
	{
		ErrorType Type { get; }
		String Message { get; }
	}
}