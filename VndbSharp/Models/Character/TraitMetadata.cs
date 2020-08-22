using System;
using Newtonsoft.Json.Linq;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Character
{
	/// <summary>
	/// Metadata about a particular Trait
	/// </summary>
	public class TraitMetadata
	{
		internal TraitMetadata(JArray array)
		{
			this.Id = array[0].Value<UInt32>();
			this.SpoilerLevel = (SpoilerLevel) array[1].Value<Int32>();
		}

		/// <summary>
		/// Trait ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Spoiler level of Trait
		/// </summary>
		public SpoilerLevel SpoilerLevel { get; private set; }
	}
}
