using System;
using Newtonsoft.Json;
using VndbSharp.Converters.VisualNovel;
using VndbSharp.Enums;

namespace VndbSharp.Structs.Models.VisualNovel
{
	[JsonConverter(typeof(TagConverter))]
	public class Tags
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("score")]
		public Single Score;
		[JsonProperty("spoiler")]
		public SpoilerLevel SpoilerLevel;
	}
}
