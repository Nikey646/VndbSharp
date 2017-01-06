using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.DatabaseStats
{
    [JsonObject]
    public class DatabaseStats
    {
        [JsonProperty("users")]
        public Int32 Users;
        [JsonProperty("threads")]
        public Int32 Threads;
        [JsonProperty("tags")]
        public Int32 Tags;
        [JsonProperty("releases")]
        public Int32 Releases;
        [JsonProperty("producers")]
        public Int32 Producers;
        [JsonProperty("chars")]
        public Int32 Characters;
        [JsonProperty("posts")]
        public Int32 Posts;
        [JsonProperty("vn")]
        public Int32 VisualNovels;
        [JsonProperty("traits")]
        public Int32 Traits;
    }
}
