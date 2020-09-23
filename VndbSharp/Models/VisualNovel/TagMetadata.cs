using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Tag Metadata
	/// </summary>
	public class TagMetadata
	{
		internal TagMetadata(JArray array)
		{
			this.Id = array[0].Value<UInt32>();
			this.Score = array[1].Value<Single>();
			this.SpoilerLevel = (SpoilerLevel) array[2].Value<Int32>();
		}

		/// <summary>
		/// Tag Id
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Tag Score
		/// </summary>
		public Single Score { get; private set; }
		/// <summary>
		/// Tag Spoiler Level
		/// </summary>
		[JsonProperty("spoiler")]
		public SpoilerLevel SpoilerLevel { get; private set; }
	}
}
