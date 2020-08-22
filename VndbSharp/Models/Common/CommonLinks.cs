using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
    public class CommonLinks
	{
		[Obsolete]
		[JsonProperty("wikipedia")]
		public String Wikipedia { get; private set; }
	}
}
