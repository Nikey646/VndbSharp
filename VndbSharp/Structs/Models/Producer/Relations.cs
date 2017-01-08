using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Producer
{
    public class Relations
    {
        [JsonProperty("id")]
        public Int32 Id;
        [JsonProperty("relation")]
        public String Relation;
        [JsonProperty("name")]
        public String Name;
        [JsonProperty("original")]
        public String Original;
    }
}
