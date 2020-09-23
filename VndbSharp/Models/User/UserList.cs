using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.User
{
	/// <summary>
	/// User Lists
	/// </summary>
	public class UserList
	{
		/// <summary>
		/// User ID
		/// </summary>
		[JsonProperty("uid")]
		public UInt32 UserId { get; private set; }
		/// <summary>
		/// Visual Novel ID
		/// </summary>
		[JsonProperty("vn")]
		public UInt32 VisualNovelId { get; private set; }
		/// <summary>
		/// Added on date
		/// </summary>
		[JsonProperty("added"), IsUnixTimestamp]
		public DateTime AddedOn { get; private set; }
		/// <summary>
		/// Last modified date
		/// </summary>
		[JsonProperty("lastmod"), IsUnixTimestamp]
		public DateTime LastModified { get; private set; }
		/// <summary>
		/// Voted on date
		/// </summary>
		[JsonProperty("voted"), IsUnixTimestamp]
		public DateTime? VotedOn { get; private set; }
		/// <summary>
		/// Current vote (between 10 and 100)
		/// </summary>
		public UInt32? Vote { get; private set; }
		/// <summary>
		/// Notes
		/// </summary>
		public String Notes { get; private set; }
		/// <summary>
		/// Started playing date
		/// </summary>
		public SimpleDate Started { get; private set; }
		/// <summary>
		/// Finished playing date
		/// </summary>
		public SimpleDate Finished { get; private set; }
		/// <summary>
		/// Collection of User Labels
		/// </summary>
		public ReadOnlyCollection<UserLabels> Labels { get; private set; }

	}
}
