using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Visual Novel Info
	/// </summary>
	public class VisualNovel
	{
		private VisualNovel() { }

		/// <summary>
		/// Visual Novel ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Vn Name
		/// </summary>
		[JsonProperty("title")]
		public String Name { get; private set; }
		/// <summary>
		/// Vn Original Name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
		/// <summary>
		/// Release Date
		/// </summary>
		public SimpleDate Released { get; private set; } // Release or Released?
		/// <summary>
		/// List of available languages
		/// </summary>
		public ReadOnlyCollection<String> Languages { get; private set; }
		/// <summary>
		/// languages of the first release
		/// </summary>
		[JsonProperty("orig_lang")]
		public ReadOnlyCollection<String> OriginalLanguages { get; private set; }
		/// <summary>
		/// List of platforms released on
		/// </summary>
		public ReadOnlyCollection<String> Platforms { get; private set; }
		/// <summary>
		/// List of aliases for the game
		/// </summary>
		[IsCsv]
		public ReadOnlyCollection<String> Aliases { get; private set; }
		/// <summary>
		/// Estimated length of the game
		/// </summary>
		public VisualNovelLength? Length { get; private set; }
		/// <summary>
		/// Description of the game. Can include formatting codes
		/// </summary>
		public String Description { get; private set; }
		/// <summary>
		/// Links related to this game
		/// </summary>
		[JsonProperty("links")]
		public VisualNovelLinks VisualNovelLinks { get; private set; }
		/// <summary>
		/// Cover Image URL
		/// </summary>
		public String Image { get; private set; }
		/// <summary>
		/// Is Image NSFW
		/// </summary>
		[Obsolete("NSFW Flag is no longer being updated. Use ImageRating instead")]
		[JsonProperty("image_nsfw")]
		public Boolean IsImageNsfw { get; private set; }
		/// <summary>
		/// Violence/Sexual rating of the cover image
		/// </summary>
		[JsonProperty("image_flagging")]
		public ImageRating ImageRating { get; private set; }
		/// <summary>
		/// List of related Anime
		/// </summary>
		public ReadOnlyCollection<AnimeMetadata> Anime { get; private set; }
		/// <summary>
		/// List of related games
		/// </summary>
		public ReadOnlyCollection<VisualNovelRelation> Relations { get; private set; }
		/// <summary>
		/// List of associated Tags
		/// </summary>
		public ReadOnlyCollection<TagMetadata> Tags { get; private set; }
		/// <summary>
		/// Popularity of the game (between 0 and 100)
		/// </summary>
		public Single Popularity { get; private set; }
		/// <summary>
		/// Bayesian rating of the game (between 1 and 10)
		/// </summary>
		public double Rating { get; private set; }
		/// <summary>
		/// List of associated Screenshots
		/// </summary>
		[JsonProperty("screens")]
		public ReadOnlyCollection<ScreenshotMetadata> Screenshots { get; private set; }
		/// <summary>
		/// List of associated Staff
		/// </summary>
		public ReadOnlyCollection<StaffMetadata> Staff { get; private set; }
	}
}
