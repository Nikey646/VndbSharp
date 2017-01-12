using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Error
{
	public class BadArgumentError : BasicError
	{
		[JsonProperty("field")]
		public String Field { get; internal set; }
	}
}
