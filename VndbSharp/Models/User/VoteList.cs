using System;
using Newtonsoft.Json;
using VndbSharp.Attributes;

namespace VndbSharp.Models.User
{
    public class VoteList
    {
		[JsonProperty("vn")]
	    public UInt32 Id { get; private set; }
	    public UInt32 Vote { get; private set; }
		[JsonProperty("added"), IsUnixTimestamp]
	    public DateTime AddedOn { get; private set; }
    }
}
