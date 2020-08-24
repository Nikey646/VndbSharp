using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.Producer
{
	/// <summary>
	/// Producer Relation info
	/// </summary>
	public class Relationship
	{
		/// <summary>
		/// Producer ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Relation to the current producer
		/// </summary>
		public String Relation { get; private set; } // TODO: Enum?
		/// <summary>
		/// Producer name
		/// </summary>
		public String Name { get; private set; }
		/// <summary>
		/// Original name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
	}
}