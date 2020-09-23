using System;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.User
{
	/// <summary>
	/// User Wishlist
	/// </summary>
	public class Wishlist
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
		/// Wishlist Priority
		/// </summary>
		public Priority Priority { get; private set; }
		/// <summary>
		/// Added on Date
		/// </summary>
		[JsonProperty("added"), IsUnixTimestamp]
		public DateTime AddedOn { get; private set; }
	}
}
