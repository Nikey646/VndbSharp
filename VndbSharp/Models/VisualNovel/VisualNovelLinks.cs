using System;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Visual Novel Links
	/// </summary>
	public class VisualNovelLinks : CommonLinks
	{
		/// <summary>
		/// Encubed Link
		/// </summary>
		[JsonProperty("encubed")]
		public String Encubed { get; private set; }
		/// <summary>
		/// Renai Link
		/// </summary>
		[JsonProperty("renai")]
		public String Renai { get; private set; }
	}
}
