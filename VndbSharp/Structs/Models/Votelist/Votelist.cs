using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models.Votelist
{
    public class Votelist
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("vote")]
        public Int32 Vote;
        [JsonProperty("added"), JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime TimeAdded;
    }
}
