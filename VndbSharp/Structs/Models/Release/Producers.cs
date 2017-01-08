using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Release
{
    public class Producers
    {
        [JsonProperty("id")]
        public Int32 Id;
        [JsonProperty("developer")]
        public Boolean Developer;
        [JsonProperty("publisher")]
        public Boolean Publisher;
        [JsonProperty("name")]
        public String Name;
        [JsonProperty("original")]
        public String OriginalName;
        [JsonProperty("type")]
        public String ProducerType;
    }
}
