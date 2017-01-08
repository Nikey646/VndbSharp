using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.VnList
{
    [JsonObject]
    public class VnList
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("status")]// : TODO: Possibly change this to a byte, since only 4 values will be returned?
        public Int32 Status;
        [JsonProperty("added")]
        public Int32 TimeAdded;
        [JsonProperty("notes")]
        public Int32 Notes;
    }
}
