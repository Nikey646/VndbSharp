using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;
using VndbSharp.Enums.Wishlist;

namespace VndbSharp.Structs.Models.Wishlist
{
    public class Wishlist
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("priority")]
        public Priority Priority;
        [JsonProperty("added"), JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime TimeAdded;
    }
}
