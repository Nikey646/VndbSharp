using System;
using Newtonsoft.Json;
using VndbSharp.Converters;
using VndbSharp.Enums;

namespace VndbSharp.Structs.Models
{
	[JsonConverter(typeof(VnTagConverter))]
	public class VnTags
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("score")]
		public Single Score; // Convert to an Enum? Number between 0 and 3?
		[JsonProperty("spoiler")]
		public VnSpoilerLevel SpoilerLevel;
	}
}
