using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VndbSharp.Models
{
	/// <summary>
	/// Default Response from the API
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[JsonObject]
	public class VndbResponse<T> : IEnumerable<T>
	{
		// Disable publicly constructing the Response Object
		private VndbResponse() { }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
		public IEnumerator<T> GetEnumerator()
		{
			using (var iterator = this.Items.GetEnumerator())
				while (iterator.MoveNext())
					yield return iterator.Current;
		}

		/// <summary>
		/// If there are more items available
		/// </summary>
		[JsonProperty("more")]
		public Boolean HasMore { get; private set; }
		/// <summary>
		/// Amount of items received
		/// </summary>
		[JsonProperty("num")]
		public Int32 Count { get; private set; }
		/// <summary>
		/// Collection of entries. This is what holds the main data
		/// </summary>
		public ReadOnlyCollection<T> Items { get; private set; }
	}
}
