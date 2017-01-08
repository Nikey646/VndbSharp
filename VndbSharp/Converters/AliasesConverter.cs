using System;
using Newtonsoft.Json;
using System.Linq;

namespace VndbSharp.Converters
{
	internal class AliasesConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

        //have to check for both sperating values
        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            var data = reader.Value?.ToString();
            if (data != null && data.Contains('\n'))
            {
                var values = data.Split('\n');
                return values;
            }
            if (data == null || !data.Contains(',')) return data;
            {
                var values = data.Split(',');
                return values;
            }
        }

        public override Boolean CanWrite => false;

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}
	}
}
