using System;
using Newtonsoft.Json;
using VndbSharp.Enums.VisualNovel;

namespace VndbSharp.Converters.VisualNovel
{
	internal class RelationsConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = reader.Value.ToString();
			
			// Try to parse
			Relation relation;
			if (Enum.TryParse(val, true, out relation))
				return relation;

			switch (val)
			{
				case "seq":
					return Relation.Sequel;
				case "preq":
					return Relation.Prequel;
				case "set":
					return Relation.SameSetting;
				case "alt":
					return Relation.AlternativeVersion;
				case "char":
					return Relation.SharesCharacters;
				case "side":
					return Relation.SideStory;
				case "par":
					return Relation.ParentStory;
				case "ser":
					return Relation.SameSeries;
				case "fan":
					return Relation.Fandisc;
				default:
					return Relation.OriginalGame;
			}
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
