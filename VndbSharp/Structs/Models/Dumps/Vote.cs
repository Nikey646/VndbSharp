using System;
using VndbSharp.Enums;

namespace VndbSharp.Structs.Models.Dumps
{
	public class Vote
	{
		public VotesDumpVersion Version;
		public UInt32 VisualNovelId;
		public UInt32 UserId;
		public Byte VoteValue;
		public DateTime? AddedOn;
	}
}
