using Newtonsoft.Json;
using VndbSharp.Converters.Character;

namespace VndbSharp.Enums.Character
{
	[JsonConverter(typeof(GenderConverter))]
	public enum Gender
	{
		Male,
		Female,
		Both
	}
}