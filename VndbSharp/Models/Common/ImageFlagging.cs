using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
	public class ImageFlagging
	{
		[JsonProperty("votecount")]
		public int VoteCount { get; private set; }
		[JsonProperty("sexual_avg")]
		public double SexualAvg { get; private set; }
		[JsonProperty("violence_avg")]
		public double ViolenceAvg { get; private set; }
	}
}
