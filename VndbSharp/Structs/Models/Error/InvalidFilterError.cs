using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Error
{
	public class InvalidFilterError : BasicError
	{
		[JsonProperty("field")]
		public String Field { get; internal set; }
		[JsonProperty("op")]
		public String Operator { get; internal set; }
		[JsonProperty("value")]
		public String Value { get; internal set; }
	}
}
