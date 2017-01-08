using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models.Votelist
{
    [JsonObject]
    public class Votelist
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("vote")]
        public Int32 Vote;
        [JsonProperty("added"), JsonConverter(typeof(UnixTimestampConverter))]
        public Int32 TimeAdded; //: TODO: Make a converter from the UNIX time into more manageable time format
    }
}
