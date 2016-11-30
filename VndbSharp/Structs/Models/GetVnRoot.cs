using System;
using System.Collections;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	[JsonObject]
	public class GetVnRoot : IEnumerable
	{
		[JsonProperty("more")]
		public Boolean HasMore;

		[JsonProperty("num")]
		public Int32 Count;

		[JsonProperty("items")]
		public VisualNovel[] Items;
		
		public IEnumerator GetEnumerator() => this.Items.GetEnumerator();
	}
}
