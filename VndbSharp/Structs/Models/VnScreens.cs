using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class VnScreens
	{
		[JsonProperty("image")]
		public String Url;
		[JsonProperty("rid")]
		public String ReleaseId; // ??
		[JsonProperty("nsfw")]
		public Boolean IsNsfw;
		[JsonProperty("height")]
		public Int32 Height;
		[JsonProperty("width")]
		public Int32 Width;
	}
}
