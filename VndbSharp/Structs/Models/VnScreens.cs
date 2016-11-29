using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class VnScreens
	{
		[JsonProperty("image")]
		public string Url;
		[JsonProperty("rid")]
		public string ReleaseId; // ??
		[JsonProperty("nsfw")]
		public Boolean IsNsfw;
		[JsonProperty("height")]
		public Int32 Height;
		[JsonProperty("width")]
		public Int32 Width;
	}
}
