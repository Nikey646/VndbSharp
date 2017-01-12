using System;
using Newtonsoft.Json;
using VndbSharp.Enums;

namespace VndbSharp.Converters.Enums
{
	// There has to be a better way then this?
	internal class ErrorTypeConverter : JsonConverter
	{
		public override Boolean CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var val = (String)reader.Value;
			if (String.IsNullOrWhiteSpace(val))
				return default(ErrorType);

			switch (val)
			{
				case "parse":
					return ErrorType.Parse;
				case "missing":
					return ErrorType.Missing;
				case "badarg":
					return ErrorType.BadArgument;
				case "needlogin":
					return ErrorType.LoginRequired;
				case "throttled":
					return ErrorType.Throttled;
				case "auth":
					return ErrorType.BadAuthentication;
				case "loggedin":
					return ErrorType.LoggedIn;
				case "gettype":
					return ErrorType.GetType;
				case "getinfo":
					return ErrorType.GetInfo;
				case "filter":
					return ErrorType.InvalidFilter;
				case "settype":
					return ErrorType.SetType;
				default:
					return ErrorType.Unknown;
			}
		}

		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(ErrorType);
		}
	}
}
