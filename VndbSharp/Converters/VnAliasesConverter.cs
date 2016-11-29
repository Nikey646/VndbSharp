using System;
using Newtonsoft.Json;

namespace VndbSharp.Converters
{
	internal class VnAliasesConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var values = reader.Value?.ToString().Split('\n');
			return values;
		}

		public override Boolean CanWrite => false;

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}
	}
}
