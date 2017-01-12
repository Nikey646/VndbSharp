using System;
using Newtonsoft.Json;
using VndbSharp.Converters;
using VndbSharp.Converters.Enums;
using VndbSharp.Enums;

namespace VndbSharp.Structs.Models.Error
{
	public class ThrottledError : BasicError
	{
		[JsonProperty("type"), JsonConverter(typeof(ThrottledTypeConverter))]
		public ThrottledType ThrottledType { get; internal set; }
		/// <summary>
		///		A DateTime.Now object, with the seconds required to wait added.
		///		If you compare this against a fresh DateTime.Now, and this is less then .Now, you are safe to continue.
		/// </summary>
		[JsonProperty("minwait"), JsonConverter(typeof(DurationToDateTimeConverter))]
		public DateTime MinimumWait { get; internal set; }
		/// <summary>
		///		A DateTime.Now object, with the seconds required to wait added.
		///		If you compare this against a fresh DateTime.Now, and this is less then .Now, you are safe to continue.
		/// </summary>
		[JsonProperty("fullwait"), JsonConverter(typeof(DurationToDateTimeConverter))]
		public DateTime FullWait { get; internal set; }
	}
}
