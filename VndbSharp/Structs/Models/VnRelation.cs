using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
		public string Title;
		[JsonProperty("original")]
		public string Original;
		[JsonProperty("official")]
		public Boolean Official;

	}
}
