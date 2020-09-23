using System;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Dumps
{
	/// <summary>
	/// Vote Object from the Dump
	/// </summary>
	public class Vote
	{
		internal Vote(VoteDumpVersion version, UInt32 visualNovelId, UInt32 userId, Byte value, SimpleDate addedOn)
		{
			this.Version = version;
			this.VisualNovelId = visualNovelId;
			this.UserID = userId;
			this.Value = value;
			this.AddedOn = addedOn;
		}

		/// <summary>
		/// Version of the Dump
		/// </summary>
		public VoteDumpVersion Version { get; }
		/// <summary>
		/// Visual Novel ID
		/// </summary>
		public UInt32 VisualNovelId { get; }
		/// <summary>
		/// User ID
		/// </summary>
		public UInt32 UserID { get; }
		/// <summary>
		/// Vote Value (Between 10 and 100)
		/// </summary>
		public Byte Value { get; }
		/// <summary>
		/// Date the vote was added on
		/// </summary>
		public SimpleDate AddedOn { get; }
	}
}
