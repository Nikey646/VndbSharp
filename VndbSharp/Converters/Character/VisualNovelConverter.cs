using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Enums;
using VndbSharp.Enums.Character;

namespace VndbSharp.Converters.Character
{
	public class VisualNovelConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);

			return new Structs.Models.Character.VisualNovel
			{
				Id = array[0].Value<Int32>(),
				ReleaseId = array[1].Value<Int32>(),
				SpoilerLevel = (SpoilerLevel)array[2].Value<Int32>(),
				Role = (Role)Enum.Parse(typeof(Role), array[3].Value<String>(), true),
			};
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
