using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Interfaces
{
	public interface IRequestOptions
	{
		Int32? Page { get; }
		Int32? Results { get; }
		string Sort { get; }
		Boolean? Reverse { get; }
	}
}
