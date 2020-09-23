using System;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.User
{
	/// <summary>
	/// List of VNs on a user's list
	/// </summary>
	public class VisualNovelList
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
		/// Visual Novel Status
		/// </summary>
		public Status Status { get; private set; }
		/// <summary>
		/// Added on Date
		/// </summary>
		[JsonProperty("added"), IsUnixTimestamp]
		public DateTime AddedOn { get; private set; }
		/// <summary>
		/// Notes
		/// </summary>
		public String Notes { get; private set; }
	}
}
