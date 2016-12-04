using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class OmniError
	{

		[JsonProperty("id")]
		public String Id;

		[JsonProperty("msg")]
		public String Message;

	}
}
