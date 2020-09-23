using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
	/// <summary>
	/// Rating of the image (sexual and violence levels)
	/// </summary>
	public class ImageRating
	{
		/// <summary>
		/// Amount of votes for the rating
		/// </summary>
		[JsonProperty("votecount")]
		public Int32 VoteCount { get; private set; }
		/// <summary>
		/// Average of sexual rating, score between 0 and 2
		/// Levels are 0(Safe), 1(Suggestive), and 3(Explicit)
		/// </summary>
		[JsonProperty("sexual_avg")]
		public Double? SexualAvg { get; private set; }
		/// <summary>
		/// Average of violence rating, score between 0 and 2
		/// Levels are 0(Tame), 1(Violent), and 3(Brutal)
		/// </summary>
		[JsonProperty("violence_avg")]
		public Double? ViolenceAvg { get; private set; }
	}
}
