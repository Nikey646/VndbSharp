using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class OmniError
	{

		[JsonProperty("id")]
		public String Id;

		[JsonProperty("msg")]
		public String Message;

	    [JsonProperty("type")]
        public String Type;

        [JsonProperty("minwait")]
        public Double? MinimumWait;

        [JsonProperty("fullwait")]
        public Double? MaximumWait;
    }
}
