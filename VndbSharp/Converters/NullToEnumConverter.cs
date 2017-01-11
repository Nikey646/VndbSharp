using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace VndbSharp.Converters
{
	public class NullToEnumConverter<TEnum> : JsonConverter where TEnum : struct, IConvertible
	{
		public override Boolean CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null || reader.TokenType != JsonToken.Integer)
				return default(TEnum);

			var value = (Int64) reader.Value;
			return EnumConverter<TEnum>.Convert(value);
		}

		public override Boolean CanConvert(Type objectType)
		{
			return typeof(TEnum) == objectType;
		}

		// Credits for this amazing snippet to Raif Atef (http://stackoverflow.com/users/111830/raif-atef), from http://stackoverflow.com/a/26289874
		private static class EnumConverter<TInnerEnum> where TInnerEnum : struct, IConvertible
		{
			public static readonly Func<Int64, TInnerEnum> Convert = EnumConverter<TInnerEnum>.GenerateConverter();

			private static Func<Int64, TInnerEnum> GenerateConverter()
			{
				var paramter = Expression.Parameter(typeof(Int64));
				var dynamicMethod = Expression.Lambda<Func<Int64, TInnerEnum>>
					(Expression.ConvertChecked(paramter, typeof(TInnerEnum)), paramter);
				return dynamicMethod.Compile();
			}
		}
	}
}
