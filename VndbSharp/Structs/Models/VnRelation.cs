using System;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models
{
	public class VnRelation
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("relation"), JsonConverter(typeof(VnRelationsConverter))]
		public Enums.VnRelation Relation;
		[JsonProperty("title")]
		public String Title;
		[JsonProperty("original")]
		public String Original;
		[JsonProperty("official")]
		public Boolean Official;

	}
}
