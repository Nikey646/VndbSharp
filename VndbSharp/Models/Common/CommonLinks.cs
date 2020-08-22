using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
    public class CommonLinks
	{
		[Obsolete("Use WikiData instead")]
		[JsonProperty("wikipedia")]
		public String Wikipedia { get; private set; }
	}
}
