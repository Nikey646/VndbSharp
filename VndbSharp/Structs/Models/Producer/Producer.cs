using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Converters;

namespace VndbSharp.Structs.Models.Producer
{
    public class Producer
    {
        [JsonProperty("id")]
        public Int32 Id;
        [JsonProperty("name")]
        public String Name;
        [JsonProperty("original")]
        public String Original;
        [JsonProperty("type")]
        public String Type;
        [JsonProperty("language")]
        public String Language;
        [JsonProperty("links")]
        public Links Links;
        [JsonProperty("aliases"), JsonConverter(typeof(AliasesConverter))]
        public String[] Aliases;
        [JsonProperty("description")]
        public String Description;
        [JsonProperty("relations")]
        public Relations[] Relations;
    }
}
