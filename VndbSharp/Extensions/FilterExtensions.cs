using System;
using VndbSharp.Filters.Conditionals;
using VndbSharp.Interfaces;

namespace VndbSharp.Extensions
{
	/// <summary>
	/// Filter Extensions
	/// </summary>
	public static class FilterExtensions
	{
		/// <summary>
		/// And Filter. Allows for Filter1 AND Filter2
		/// </summary>
		/// <param name="filterA"></param>
		/// <param name="filterB"></param>
		/// <returns></returns>
		public static FilterAnd And(this IFilter filterA, IFilter filterB) => new FilterAnd(filterA, filterB);
		/// <summary>
		/// Or Filter. Allows for Filter1 OR Filter2
		/// </summary>
		/// <param name="filterA"></param>
		/// <param name="filterB"></param>
		/// <returns></returns>
		public static FilterOr Or(this IFilter filterA, IFilter filterB) => new FilterOr(filterA, filterB);


		internal static void ThrowIfNull(this IFilter filter)
		{
			if (filter == null)
				throw new ArgumentNullException("The provided filter is null");
		}
	}
}
