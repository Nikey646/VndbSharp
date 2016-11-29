using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
