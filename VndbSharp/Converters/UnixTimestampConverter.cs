using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Converters
{
    public class UnixTimestampConverter : JsonConverter
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return UnixTimestampConverter._epoch.AddSeconds((Int64)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - UnixTimestampConverter._epoch).TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
        }
    }
}
