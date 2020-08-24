using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Release
{
	/// <summary>
	/// Visual Novel Info related to Release
	/// </summary>
	public class VisualNovelMetadata
	{
		/// <summary>
		/// Visual Novel ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Visual Novel Name
		/// </summary>
		[JsonProperty("title")]
		public String Name { get; private set; }
		/// <summary>
		/// Visaul Novel Original Name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
	}
}
