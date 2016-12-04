using System;
using Newtonsoft.Json;
using VndbSharp.Converters.Character;
using VndbSharp.Enums;

namespace VndbSharp.Structs.Models.Character
{
	[JsonConverter(typeof(TraitsConverter))]
	public class Traits
	{
		public Int32 Id;
		public SpoilerLevel SpoilerLevel;
	}
}
