using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Screenshot Metadata
	/// </summary>
	public class ScreenshotMetadata
	{
		/// <summary>
		/// Image URL
		/// </summary>
		[JsonProperty("image")]
		public String Url { get; private set; }
		/// <summary>
		/// Release ID
		/// </summary>
		[JsonProperty("rid")]
		public String ReleaseId { get; private set; }
		/// <summary>
		/// Is Image NSFW
		/// </summary>
		[Obsolete("NSFW Flag is no longer being updated. Use ImageRating instead")]
		[JsonProperty("nsfw")]
		public Boolean IsNsfw { get; private set; }
		/// <summary>
		/// Violence/Sexual rating of Image
		/// </summary>
		[JsonProperty("flagging")]
		public ImageRating ImageRating { get; private set; }
		/// <summary>
		/// Image height in pixels
		/// </summary>
		public Int32 Height { get; private set; }
		/// <summary>
		/// Image width in pixels
		/// </summary>
		public Int32 Width { get; private set; }
	}
}
