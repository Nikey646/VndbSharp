using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Release
{
    public class VisualNovel
    {
        [JsonProperty("id")]
        public Int32 Id;
        [JsonProperty("title")]
        public String Title;
        [JsonProperty("original")]
        public String Original;
    }
}
