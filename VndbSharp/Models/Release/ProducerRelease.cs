using System;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Release
{
	/// <summary>
	/// Producer Involved in the Release
	/// </summary>
	public class ProducerRelease : ProducerCommon
	{
		/// <summary>
		/// Is a developer
		/// </summary>
		[JsonProperty("developer")]
		public Boolean IsDeveloper { get; private set; }
		/// <summary>
		/// Is a publisher
		/// </summary>
		[JsonProperty("publisher")]
		public Boolean IsPublisher { get; private set; }
	}
}
