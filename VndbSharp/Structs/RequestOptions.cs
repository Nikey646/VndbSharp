using System;
using Newtonsoft.Json;
using VndbSharp.Interfaces;

namespace VndbSharp.Structs
{
	public class RequestOptions : IRequestOptions
	{
		[JsonProperty("page")]
		public Int32? Page { get; set; } = null;
		[JsonProperty("results")]
		public Int32? Results { get; set; } = null;
		[JsonProperty("sort")]
		public String Sort { get; set; } = null;
		[JsonProperty("reverse")]
		public Boolean? Reverse { get; set; } = null;
	}
}
