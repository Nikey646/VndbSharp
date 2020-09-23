using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Common
{
	/// <summary>
	/// Common Producer properties
	/// </summary>
	public class ProducerCommon
	{
		/// <summary>
		/// Producer ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Producer's Name
		/// </summary>
		public String Name { get; private set; }
		/// <summary>
		/// Producer's Original/Official Name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
		/// <summary>
		/// Type of the producer
		/// </summary>
		[JsonProperty("type")]
		public String ProducerType { get; private set; } // Enum? Valid values - https://g.blicky.net/vndb.git/tree/util/sql/all.sql#n20 , real values???
	}
}
