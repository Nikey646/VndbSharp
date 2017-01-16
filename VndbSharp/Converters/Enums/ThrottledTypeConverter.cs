using System;
using Newtonsoft.Json;
using VndbSharp.Enums;

namespace VndbSharp.Converters.Enums
{
	// There has to be a better way then this?
	internal class ThrottledTypeConverter : JsonConverter
	{
		public override Boolean CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = (String) reader.Value;
			if (String.IsNullOrWhiteSpace(val))
				return default(ThrottledType);

			// Try to parse
			ThrottledType throttledType;
			if (Enum.TryParse(val, true, out throttledType))
				return throttledType;

			if (val == "cmd")
				return ThrottledType.Command;
			return val == "sql" ? ThrottledType.Sql : default(ThrottledType);
		}

		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(ThrottledType);
		}
	}
}
