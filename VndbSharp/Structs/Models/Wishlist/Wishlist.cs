using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models.Wishlist
{
    public class Wishlist
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("priority")] //TODO: possibly also make this a Byte, sinc only 4 values are used?
        public Int32 Priority;
        [JsonProperty("added"), JsonConverter(typeof(UnixTimestampConverter))]
        public Int32 TimeAdded;
    }
}
