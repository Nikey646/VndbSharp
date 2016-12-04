using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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

			return array.Select(vn => (JArray)vn).Select(vn => new Structs.Models.Character.VisualNovel
			{
				Id = vn[0].Value<Int32>(),
				ReleaseId = vn[1].Value<Int32>(),
				SpoilerLevel = (SpoilerLevel)vn[2].Value<Int32>(),
				Role = (Role)Enum.Parse(typeof(Role), vn[3].Value<String>(), true),
			}).ToArray();

			// Dead code incase ^ doesn't work
			var visualNovels = new List<Structs.Models.Character.VisualNovel>();

			foreach (var vns in array)
			{
				var vn = (JArray) vns;

				visualNovels.Add(new Structs.Models.Character.VisualNovel
				{
					Id = vn[0].Value<Int32>(),
					ReleaseId = vn[1].Value<Int32>(),
					SpoilerLevel = (SpoilerLevel)vn[2].Value<Int32>(),
					Role = (Role)Enum.Parse(typeof(Role), vn[3].Value<String>(), true),
				});
			}
			
			return visualNovels;
		}

		public override Boolean CanConvert(Type objectType)
		{
			return true;
		}

		public override Boolean CanWrite { get; } = false;
	}
}
