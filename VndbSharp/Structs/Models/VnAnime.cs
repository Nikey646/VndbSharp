using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class VnAnime
	{
		[JsonProperty("id")]
		public Int32 AniDbId;
		[JsonProperty("ann_id")]
		public Int32 AnimeNewsNetworkId;
		[JsonProperty("nfo_id")]
		public Int32 AnimeNfoId;
		[JsonProperty("romaji_title")]
		public String RomajiTitle;
		[JsonProperty("title_kanji")]
		public String KanjiTitle;
		[JsonProperty("year")]
		public DateTime? AirringYear;
		[JsonProperty("type")]
		public String Type; // ??

	}
}
