using System;
using System.Collections;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class RootObject<T>
	{
		[JsonProperty("more")]
		public Boolean HasMore;

		[JsonProperty("num")]
		public Int32 Count;

		[JsonProperty("items")]
		public T[] Items;

		public IEnumerator GetEnumerator() => this.Items.GetEnumerator();
	}
}
