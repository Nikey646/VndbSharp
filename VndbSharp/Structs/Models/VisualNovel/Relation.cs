using System;
using Newtonsoft.Json;
using VndbSharp.Converters.VisualNovel;

namespace VndbSharp.Structs.Models.VisualNovel
{
	public class Relation
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("relation"), JsonConverter(typeof(RelationsConverter))]
		public Enums.VisualNovel.Relation RelationshipType;
		[JsonProperty("title")]
		public String Title;
		[JsonProperty("original")]
		public String Original;
		[JsonProperty("official")]
		public Boolean Official;

	}
}
