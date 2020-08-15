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
		[Obsolete]
		[JsonProperty("nsfw")]
		public Boolean IsNsfw { get; private set; }
		[JsonProperty("flagging")]
		public ImageFlagging ImageFlagging { get; private set; }
		public Int32 Height { get; private set; }
		public Int32 Width { get; private set; }
	}
}
