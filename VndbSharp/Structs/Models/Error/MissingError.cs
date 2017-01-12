using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Error
{
	public class MissingError : BasicError
	{
		[JsonProperty("field")]
		public String Field { get; internal set; }
	}
}
