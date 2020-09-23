using System;
using System.Collections.ObjectModel;
using VndbSharp.Models.Common;
using VndbSharp.Attributes;

namespace VndbSharp.Models.Producer
{
	/// <summary>
	/// Producer Information
	/// </summary>
	public class Producer : ProducerCommon
	{
		/// <summary>
		/// Primary Language
		/// </summary>
		public String Language { get; private set; }
		/// <summary>
		/// Producer Links
		/// </summary>
		public ProducerLinks Links { get; private set; }
		/// <summary>
		/// List of alternative names
		/// </summary>
		[IsCsv]
		public ReadOnlyCollection<String> Aliases { get; private set; }
		/// <summary>
		/// Description/notes of the producer, can contain formatting codes
		/// </summary>
		public String Description { get; private set; }
		/// <summary>
		/// List of related producers
		/// </summary>
		public ReadOnlyCollection<Relationship> Relations { get; private set; }
	}
}
