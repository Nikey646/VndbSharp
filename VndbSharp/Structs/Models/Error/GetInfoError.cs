using System;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models.Error
{
	public class GetInfoError : BasicError
	{
		/// <summary>
		///	How did you even...what? Black magic! Witch!!
		/// </summary>
		[JsonProperty("flag")]
		public String Flag { get; internal set; }
	}
}
