using System;
using Newtonsoft.Json;

namespace VndbSharp.Models
{
	/// <summary>
	/// Stats about the VNDB Database
	/// </summary>
	public class DatabaseStats
	{
		/// <summary>
		/// AMount of Users in the DB
		/// </summary>
		[Obsolete("This no longer is used (Returns 0) This will be removed in a later version of the API")]
		public UInt32 Users { get; private set; }
		/// <summary>
		/// Amount of Threads in the DB
		/// </summary>
		[Obsolete("This no longer is used (Returns 0) This will be removed in a later version of the API")]
		public UInt32 Threads { get; private set; }
		/// <summary>
		/// Amount of Tags in the DB
		/// </summary>
		public UInt32 Tags { get; private set; }
		/// <summary>
		/// AMount of Releases in the DB
		/// </summary>
		public UInt32 Releases { get; private set; }
		/// <summary>
		/// Amount of Producers in the DB
		/// </summary>
		public UInt32 Producers { get; private set; }
		/// <summary>
		/// Amount of Characters in the DB
		/// </summary>
		[JsonProperty("chars")]
		public UInt32 Characters { get; private set; }
		/// <summary>
		/// Amount of Posts in the DB
		/// </summary>
		[Obsolete("This no longer is used (Returns 0) This will be removed in a later version of the API")]
		public UInt32 Posts{ get; private set; }
		/// <summary>
		/// Amount of VNs in the DB
		/// </summary>
		[JsonProperty("vn")]
		public UInt32 VisualNovels { get; private set; }
		/// <summary>
		/// Amount of Traits in the DB
		/// </summary>
		public UInt32 Traits { get; private set; }
	}
}
