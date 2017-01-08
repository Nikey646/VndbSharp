using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;
using VndbSharp.Enums.VnList;

namespace VndbSharp.Structs.Models.VnList
{
    public class VnList
    {
        [JsonProperty("vn")]
        public Int32 VisualNovelId;
        [JsonProperty("status")]
        public Status Status;
        [JsonProperty("added"), JsonConverter(typeof(UnixTimestampConverter))]
        public Int32 TimeAdded;
        [JsonProperty("notes")]
        public Int32 Notes;
    }
}
