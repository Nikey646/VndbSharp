using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Release
{
    [JsonObject]
    public class Release
    {
        [JsonProperty("id")]
        public Int32 ReleaseId;
        [JsonProperty("title")]
        public String Title;
        [JsonProperty("original")]
        public String Original;
        [JsonProperty("released")]
        public DateTime? Released;
        [JsonProperty("type")]
        public String Type;
        [JsonProperty("patch")]
        public Boolean Patch;
        [JsonProperty("freeware")]
        public Boolean Freeware;
        [JsonProperty("doujin")]
        public Boolean Doujin;
        [JsonProperty("languages")]
        public String[] Languages;

        [JsonProperty("website")]
        public String Website;
        [JsonProperty("notes")]
        public String Notes;
        [JsonProperty("minage")]
        public Int32? MinAge;
        [JsonProperty("gtin")]
        public String Gtin;
        [JsonProperty("catalog")]
        public String Catalog;
        [JsonProperty("platforms")]
        public String[] Platforms;
        [JsonProperty("media")]
        public Media[] Media;

        [JsonProperty("vn")]
        public VisualNovel[] VisualNovels;

        [JsonProperty("producer")]
        public Producers[] Producers;
    }
}
