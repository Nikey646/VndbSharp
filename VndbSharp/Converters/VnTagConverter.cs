using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Enums;
using VndbSharp.Structs.Models;

namespace VndbSharp.Converters
{
	internal class VnTagConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var result = new VnTags
			{
				Id = array[0].Value<Int32>(),
				Score = array[1].Value<Single>(),
				SpoilerLevel = (VnSpoilerLevel) array[2].Value<Int32>(),
			};
			return result;
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
