using System;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models.VisualNovel
{
	[JsonObject]
	public class VisualNovel
	{
		[JsonProperty("id")]
		public Int32 Id;
		[JsonProperty("title")]
		public String Title;
		[JsonProperty("original")]
		public String Original;
		[JsonProperty("released")]
		public DateTime? Released;
		[JsonProperty("languages")]
		public String[] Languages;
		[JsonProperty("orig_lang")]
		public String[] OriginalLanauges;
		[JsonProperty("platforms")]
		public String[] Platforms;
		[JsonProperty("aliases"), JsonConverter(typeof(AliasesConverter))]
		public String[] Aliases;
		[JsonProperty("length")]
		public Int32? Length; // TODO: Convert to Enum w/ DescriptionAttribute(s)
		[JsonProperty("description")]
		public String Description;
		[JsonProperty("links")]
		public Links Links;
		[JsonProperty("image")]
		public String Image;
		[JsonProperty("image_nsfw")]
		public Boolean IsImageNsfw;
		[JsonProperty("anime")]
		public Anime[] Anime;
		[JsonProperty("relations")]
		public Relation[] Relations;
		[JsonProperty("tags")]
		public Tags[] Tags;
		[JsonProperty("popularity")]
		public Single Popularity;
		[JsonProperty("rating")]
		public Single Rating;
		[JsonProperty("votecount")]
		public Int32 VoteCount;
		[JsonProperty("screens")]
		public Screenshots[] Screens;
	}
}
