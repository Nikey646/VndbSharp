using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Enums;
using VndbSharp.Structs.Models.VisualNovel;

namespace VndbSharp.Converters.VisualNovel
{
	internal class TagConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var result = new Tags
			{
				Id = array[0].Value<Int32>(),
				Score = array[1].Value<Single>(),
				SpoilerLevel = (SpoilerLevel) array[2].Value<Int32>(),
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
