using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Release
{
    public class Media
    {
        [JsonProperty("medium")]
        public String Medium;
        [JsonProperty("qty")]
        public Int32? Quantity;
    }
}
