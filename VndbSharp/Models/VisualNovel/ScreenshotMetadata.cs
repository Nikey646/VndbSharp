using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	public class ScreenshotMetadata
	{
		[JsonProperty("image")]
		public String Url { get; private set; }
		[JsonProperty("rid")]
		public String ReleaseId { get; private set; }
		[Obsolete("NSFW Flag is no longer being updated. Use ImageRating instead")]
		[JsonProperty("nsfw")]
		public Boolean IsNsfw { get; private set; }
		[JsonProperty("flagging")]
		public ImageRating ImageRating { get; private set; }
		public Int32 Height { get; private set; }
		public Int32 Width { get; private set; }
	}
}
