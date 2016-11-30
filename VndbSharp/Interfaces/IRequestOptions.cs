using System;

namespace VndbSharp.Interfaces
{
	public interface IRequestOptions
	{
		Int32? Page { get; }
		Int32? Results { get; }
		String Sort { get; }
		Boolean? Reverse { get; }
	}
}
