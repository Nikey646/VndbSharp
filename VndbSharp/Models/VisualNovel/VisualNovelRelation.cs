using System;
using Newtonsoft.Json;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Visual Novel Relations
	/// </summary>
	public class VisualNovelRelation
	{
		/// <summary>
		/// Visual Novel Id
		/// </summary>
		public Int32 Id { get; private set; }
		/// <summary>
		/// Relation Type
		/// </summary>
		[JsonProperty("relation")]
		public RelationType Type { get; private set; }
		/// <summary>
		/// Title
		/// </summary>
		public String Title { get; private set; }
		/// <summary>
		/// Original Title
		/// </summary>
		public String Original { get; private set; }
		/// <summary>
		/// Is Official relation
		/// </summary>
		public Boolean Official { get; private set; }
	}
}
