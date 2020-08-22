using System;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Character
{
	/// <summary>
	/// List of instances of a character
	/// </summary>
	public class CharacterInstances
	{
		/// <summary>
		/// Character Id
		/// </summary>
		public Int32 Id { get; private set; }
		/// <summary>
		/// Spoiler level
		/// </summary>
		public SpoilerLevel Spoiler { get; private set; }
		/// <summary>
		/// Character's Name
		/// </summary>
		public String Name { get; private set; }
		/// <summary>
		/// Character's Original/Japanese Name
		/// </summary>
		[JsonProperty("original")]
		public String Kanji { get; private set; }
	}
}
