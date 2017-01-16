using System;
using Newtonsoft.Json;
using VndbSharp.Enums.Dumps;

namespace VndbSharp.Converters.Enums
{
	public class TagCategoryConverter : JsonConverter
	{
		public override Boolean CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = (String)reader.Value;
			if (String.IsNullOrWhiteSpace(val))
				return default(TagCategory);

			// TODO: Do this on all the enum converters
			// Try to parse
			TagCategory tagCat;
			if (Enum.TryParse(val, true, out tagCat))
				return tagCat;

			// Resort to vndb responses
			switch (val)
			{
				case "cont":
					return TagCategory.Content;
				case "ero":
					return TagCategory.Sexual;
				case "tech":
					return TagCategory.Technical;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(TagCategory);
		}
	}
}
