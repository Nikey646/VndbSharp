using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models
{
	[JsonObject]
	public class VisualNovel
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("title")]
		public string Title;
		[JsonProperty("original")]
		public string Original;
		[JsonProperty("released")]
		public DateTime? Released;
		[JsonProperty("languages")]
		public string[] Languages;
		[JsonProperty("orig_lang")]
		public string[] OriginalLanauges;
		[JsonProperty("platforms")]
		public string[] Platforms;
		[JsonProperty("aliases"), JsonConverter(typeof(VnAliasesConverter))]
		public string[] Aliases;
		[JsonProperty("length")]
		public Int32? Length; // TODO: Convert to Enum w/ DescriptionAttribute(s)
		[JsonProperty("description")]
		public string Description;
		[JsonProperty("links")]
		public VnLinks Links;
		[JsonProperty("image")]
		public string Image;
		[JsonProperty("image_nsfw")]
		public Boolean IsImageNsfw;
		[JsonProperty("anime")]
		public VnAnime[] Anime;
		[JsonProperty("relations")]
		public VnRelation[] Relations;
		[JsonProperty("tags")]
		public VnTags[] Tags;
		[JsonProperty("popularity")]
		public Single Popularity;
		[JsonProperty("rating")]
		public Single Rating;
		[JsonProperty("votecount")]
		public Int32 VoteCount;
		[JsonProperty("screens")]
		public VnScreens[] Screens;
	}
}
