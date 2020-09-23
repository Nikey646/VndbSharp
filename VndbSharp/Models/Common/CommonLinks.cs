using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
    /// <summary>
    /// Used for adding common links to link collections
    /// </summary>
    public class CommonLinks
	{
		/// <summary>
		/// Name of the related article on the English Wikipedia
		/// </summary>
		[Obsolete("Use WikiData instead")]
		[JsonProperty("wikipedia")]
		public String Wikipedia { get; private set; }
		/// <summary>
		/// Wikidata identifier
		/// </summary>
		[JsonProperty("wikidata")]
		public String Wikidata { get; private set; }
	}
}
