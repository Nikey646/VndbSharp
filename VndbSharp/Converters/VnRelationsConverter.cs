using System;
using Newtonsoft.Json;
using VndbSharp.Enums;

namespace VndbSharp.Converters
{
	internal class VnRelationsConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			switch (reader.Value.ToString())
			{
				case "seq":
					return VnRelation.Sequel;
				case "preq":
					return VnRelation.Prequel;
				case "set":
					return VnRelation.SameSetting;
				case "alt":
					return VnRelation.AlternativeVersion;
				case "char":
					return VnRelation.SharesCharacters;
				case "side":
					return VnRelation.SideStory;
				case "par":
					return VnRelation.ParentStory;
				case "ser":
					return VnRelation.SameSeries;
				case "fan":
					return VnRelation.Fandisc;
				default:
					return VnRelation.OriginalGame;
			}
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
