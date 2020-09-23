using System;
using Newtonsoft.Json;
using VndbSharp.Attributes;

namespace VndbSharp.Models.User
{
    /// <summary>
    /// User VoteList
    /// </summary>
    public class VoteList
    {
		/// <summary>
		/// Visual Novel ID
		/// </summary>
		[JsonProperty("vn")]
	    public UInt32 VisualNovelId { get; private set; }
	    /// <summary>
	    /// User ID
	    /// </summary>
	    [JsonProperty("uid")]
	    public UInt32 UserId { get; private set; }
		/// <summary>
		/// Current Vote (between 10 and 100)
		/// </summary>
		public UInt32 Vote { get; private set; }
		/// <summary>
		/// Added on Date
		/// </summary>
		[JsonProperty("added"), IsUnixTimestamp]
	    public DateTime AddedOn { get; private set; }
    }
}
