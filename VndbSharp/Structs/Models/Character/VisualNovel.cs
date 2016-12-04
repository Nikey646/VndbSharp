using System;
using Newtonsoft.Json;
using VndbSharp.Converters.Character;
using VndbSharp.Enums;
using VndbSharp.Enums.Character;

namespace VndbSharp.Structs.Models.Character
{
	[JsonConverter(typeof(VisualNovelConverter))]
	public class VisualNovel
	{
		public Int64 Id;
		public Int64 ReleaseId;
		public SpoilerLevel SpoilerLevel;
		public Role Role;
	}
}
