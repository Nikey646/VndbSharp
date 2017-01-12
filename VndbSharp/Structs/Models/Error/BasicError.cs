using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Converters.Enums;
using VndbSharp.Enums;
using VndbSharp.Interfaces;

namespace VndbSharp.Structs.Models.Error
{
	public abstract class BasicError : IVndbError
	{
		[JsonProperty("id"), JsonConverter(typeof(ErrorTypeConverter))]
		public ErrorType Type { get; internal set; }
		[JsonProperty("msg")]
		public String Message { get; internal set; }

		internal static IVndbError Build<T>(JObject jObj)
		{
			var result = (IVndbError) new JsonSerializer().Deserialize<T>(new JTokenReader(jObj));
			return result;
		}
	}
}
