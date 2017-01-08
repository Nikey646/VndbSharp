using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Wishlist
{
    [JsonObject]
    public class Wishlist
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("priority")] //TODO: possibly also make this a Byte, sinc only 4 values are used?
        public Int32 Priority;
        [JsonProperty("added")]
        public Int32 TimeAdded;
    }
}
