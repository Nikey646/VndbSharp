using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Enums;
using VndbSharp.Structs.Models.Character;

namespace VndbSharp.Converters.Character
{
	internal class TraitsConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);

			return new Traits()
			{
				Id = array[0].Value<Int32>(),
				SpoilerLevel = (SpoilerLevel) array[1].Value<Int32>()
			};
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
