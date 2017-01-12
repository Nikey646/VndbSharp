using System;
using Newtonsoft.Json;

namespace VndbSharp.Converters
{
	// These names are getting silly... lol
	internal class DurationToDateTimeConverter : JsonConverter
	{
		public override Boolean CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = (Double) reader.Value;
			// Should this use UtcNow or Now?
			return DateTime.Now.Add(TimeSpan.FromSeconds(val));
		}

		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}
	}
}
