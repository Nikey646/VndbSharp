using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Release
{
	/// <summary>
	/// Release Information
	/// </summary>
	public class Release
	{
		/// <summary>
		/// Release ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Release Name
		/// </summary>
		[JsonProperty("title")]
		public String Name { get; private set; }
		/// <summary>
		/// Release Original Name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
		/// <summary>
		/// Date of Release
		/// </summary>
		public SimpleDate Released { get; private set; }
		/// <summary>
		/// Release Type
		/// </summary>
		public ReleaseType Type { get; private set; }
		/// <summary>
		/// Is the Release a patch
		/// </summary>
		[JsonProperty("patch")]
		public Boolean IsPatch { get; private set; }
		/// <summary>
		/// Is the Release freeware
		/// </summary>
		[JsonProperty("freeware")]
		public Boolean IsFreeware { get; private set; }
		/// <summary>
		/// Is the Release a doujin
		/// </summary>
		[JsonProperty("doujin")]
		public Boolean IsDoujin { get; private set; }
		/// <summary>
		/// List of languages
		/// </summary>
		public ReadOnlyCollection<String> Languages { get; private set; }
		/// <summary>
		/// Release Website
		/// </summary>
		public String Website { get; private set; }
		/// <summary>
		/// Release Notes
		/// </summary>
		public String Notes { get; private set; } // Possibly rename to description
		/// <summary>
		/// Minimum age
		/// </summary>
		[JsonProperty("minage")]
		public UInt32? MinimumAge { get; private set; }
		/// <summary>
		///		JAN/UPC/EAN code.
		/// </summary>
		public String Gtin { get; private set; }
		/// <summary>
		/// Catalog Number
		/// </summary>
		public String Catalog { get; private set; }
		/// <summary>
		/// Resolution of Release
		/// </summary>
		public String Resolution { get; private set; }
		/// <summary>
		/// Voiced Type
		/// </summary>
		public Voiced Voiced { get; private set; }
		/// <summary>
		///		The array has two integer members, the first one indicating the story animations, the second the ero scene animations. Both members can be null if unknown or not applicable.
		/// </summary>
		public ReadOnlyCollection<Animated> Animation { get; set; }
		/// <summary>
		/// Release Platforms
		/// </summary>
		public ReadOnlyCollection<String> Platforms { get; private set; }
		/// <summary>
		/// Release Media
		/// </summary>
		public ReadOnlyCollection<Media> Media { get; private set; }
		/// <summary>
		/// Related Visual Novels
		/// </summary>
		[JsonProperty("vn")]
		public ReadOnlyCollection<VisualNovelMetadata> VisualNovels { get; private set; }
		/// <summary>
		/// Related Producers
		/// </summary>
		public ReadOnlyCollection<ProducerRelease> Producers { get; private set; }
	}
}
