using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndbSharp.Interfaces;

namespace VndbSharp.Models
{
	/// <summary>
	/// Default RequestOptions For use when sending commands to the API
	/// </summary>
	public class RequestOptions : IRequestOptions
	{
		/// <summary>
		/// What Page to get
		/// </summary>
		public Int32? Page { get; set; }
		/// <summary>
		/// How many entries to get. Most commands are limited at 25, except for votelist/vnlist/wishlist/ulist, which returns at most 100 results.
		/// </summary>
		public Int32? Count { get; set; }
		/// <summary>
		/// The field to order the results by
		/// </summary>
		public String Sort { get; set; }
		/// <summary>
		/// Reverses the order of the entries
		/// </summary>
		public Boolean? Reverse { get; set; }
	}
}
