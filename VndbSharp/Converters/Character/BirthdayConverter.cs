using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VndbSharp.Converters.Character
{
	public class BirthdayConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);

			return new DateTime(DateTime.UtcNow.Year, array[1].Value<Int32>(), array[0].Value<Int32>());
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
