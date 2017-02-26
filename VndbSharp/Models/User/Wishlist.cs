using System;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.User
{
	public class Wishlist
	{
		[JsonProperty("vn")]
		public UInt32 Id { get; private set; }
		public Priority Priority { get; private set; }
		[JsonProperty("added"), IsUnixTimestamp]
		public DateTime AddedOn { get; private set; }
	}
}
