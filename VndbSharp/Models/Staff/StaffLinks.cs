using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Staff
{
    public class StaffLinks: CommonLinks
    {
		[JsonProperty("homepage")]
		public String Homepage { get; private set; }
        [JsonProperty("twitter")]
        public String Twitter { get; private set; }
        [JsonProperty("anidb")]
        public String Anib { get; private set; }
	}
}
