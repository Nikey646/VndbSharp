using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Character
{
	/// <summary>
	/// Metadata about a voice actor
	/// </summary>
	public class VoiceActorMetadata
	{
		/// <summary>
		/// Staff Id
		/// </summary>
		[JsonProperty("id")]
		public Int32 StaffId { get; private set; }
		/// <summary>
		/// Staff Alias ID
		/// </summary>
		[JsonProperty("aid")]
		public Int32 AliasId { get; private set; }
		/// <summary>
		/// Visual Novel ID
		/// </summary>
		[JsonProperty("vid")]
		public Int32 VisualNovelId { get; private set; }
		/// <summary>
		/// Notes
		/// </summary>
		public String Note { get; private set; }
	}
}
