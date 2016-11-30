using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class VnLinks
	{
		[JsonProperty("wikipedia")]
		public String Wikipedia;
		[JsonProperty("encubed")]
		public String Encubed;
		[JsonProperty("renai")]
		public String Renai;
	}
}
