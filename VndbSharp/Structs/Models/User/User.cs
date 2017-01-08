using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.User
{
    public class User
    {
        [JsonProperty("id")]
        public Int32 Id;
        [JsonProperty("username")]
        public String Username;
    }
}
