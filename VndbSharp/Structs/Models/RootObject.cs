using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VndbSharp.Structs.Models
{
	public class RootObject<T> : IEnumerable<T>
	{
		[JsonProperty("more")]
		public Boolean HasMore;

		[JsonProperty("num")]
		public Int32 Count;

		[JsonProperty("items")]
		public T[] Items;

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			for (var i = 0; i < this.Count; i++)
				yield return this.Items[i];
		}
	}
}
