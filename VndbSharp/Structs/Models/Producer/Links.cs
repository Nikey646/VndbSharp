using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Producer
{
    public class Links
    {
        [JsonProperty("homepage")]
        public String Homepage;
        [JsonProperty("wikipedia")]
        public String Wikipedia;

    }
}
