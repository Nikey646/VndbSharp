using System;
using Newtonsoft.Json;
using VndbSharp.Enums.Character;

namespace VndbSharp.Converters.Character
{
	public class GenderConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = reader.Value.ToString();

			// Try to parse
			Gender gender;
			if (Enum.TryParse(val, true, out gender))
				return gender;

			switch (val)
			{
				case "m":
					return Gender.Male;
				case "f":
					return Gender.Female;
				case "b":
					return Gender.Both;
				default:
					return null;
			}
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
