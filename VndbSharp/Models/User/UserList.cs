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
	public class UserList
	{
		[JsonProperty("uid")]
		public UInt32 UserId { get; private set; }
		[JsonProperty("vn")]
		public UInt32 VisualNovelId { get; private set; }
		[JsonProperty("added"), IsUnixTimestamp]
		public DateTime AddedOn { get; private set; }
		[JsonProperty("lastmod"), IsUnixTimestamp]
		public DateTime LastModified { get; private set; }

		//BUG:THIS CURRENTLY CAUSES A CRASH IF ENABLED
		//[JsonProperty("voted"), IsUnixTimestamp]
		//public DateTime? VotedOn { get; private set; }

		public UInt32? Vote { get; private set; }
		public String Notes { get; private set; }
		public SimpleDate Started { get; private set; }
		public SimpleDate Finished { get; private set; }
		public ReadOnlyCollection<UserLabels> Labels { get; private set; }

	}
}
