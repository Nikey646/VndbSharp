using System;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Anime Metadata
	/// </summary>
	public class AnimeMetadata
	{
		/// <summary>
		/// AniDb ID
		/// </summary>
		[JsonProperty("id")]
		public Int32? AniDbId { get; private set; }
		/// <summary>
		/// AnimeNewsNetwork ID
		/// </summary>
		[JsonProperty("ann_id")]
		public Int32? AnimeNewsNetworkId { get; private set; }
		/// <summary>
		/// AnimeNfo ID
		/// </summary>
		[JsonProperty("nfo_id")]
		public String AnimeNfoId { get; private set; }
		/// <summary>
		/// English Title
		/// </summary>
		[JsonProperty("title_romaji")]
		public String RomajiTitle { get; private set; }
		/// <summary>
		/// Japanese Title
		/// </summary>
		[JsonProperty("title_kanji")]
		public String KanjiTitle { get; private set; }
		/// <summary>
		/// Year anime aired
		/// </summary>
		[JsonProperty("year")]
		public SimpleDate AiringYear { get; private set; }
		/// <summary>
		/// Anime Type
		/// </summary>
		[JsonProperty("type")]
		public String Type { get; private set; } // ??
	}
}
