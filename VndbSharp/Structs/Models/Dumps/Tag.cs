using System;
using Newtonsoft.Json;
using VndbSharp.Converters.Enums;
using VndbSharp.Enums.Dumps;

namespace VndbSharp.Structs.Models.Dumps
{
	public class Tag
	{
		[JsonProperty("id")]
		public UInt32 Id;
		[JsonProperty("name")]
		public String Name;
		[JsonProperty("description")]
		public String Description;
		[JsonProperty("vns")]
		public UInt32 VisualNovels;
		[JsonProperty("cat"), JsonConverter(typeof(TagCategoryConverter))]
		public TagCategory Category;
		[JsonProperty("aliases")]
		public String[] Aliases;
		[JsonProperty("parents")]
		public UInt32[] Parents;
		[JsonProperty("meta")]
		public Boolean IsMeta;
	}
}
