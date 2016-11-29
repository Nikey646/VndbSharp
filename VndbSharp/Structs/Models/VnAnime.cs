using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public string RomajiTitle;
		[JsonProperty("title_kanji")]
		public string KanjiTitle;
		[JsonProperty("year")]
		public DateTime? AirringYear;
		[JsonProperty("type")]
		public string Type; // ??

	}
}
