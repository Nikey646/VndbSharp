using System;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;

namespace VndbSharp.Filters.Conditionals
{
	/// <summary>
	/// Combines two filters with the And pattern
	/// </summary>
	public class FilterAnd : IFilter
	{
		/// <summary>
		/// Default constructor for AND Filter
		/// </summary>
		/// <param name="leftFilter">The left IFilter</param>
		/// <param name="rightFilter">The right IFilter</param>
		public FilterAnd(IFilter leftFilter, IFilter rightFilter)
		{
			leftFilter.ThrowIfNull();
			rightFilter.ThrowIfNull();
			this.LeftFilter = leftFilter;
			this.RightFilter = rightFilter;
		}

		/// <summary>
		/// Converts Left and Right Filter to String
		/// </summary>
		/// <returns>The IFilter represented as a String</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filters", "One of the provided filters are not valid.");
			return $"({this.LeftFilter} and {this.RightFilter})";
		}

		/// <summary>
		///		Called when constructing the filter of a request, to check that the Operator can be performed with the provided Value(s)
		/// </summary>
		/// <returns>True the current Operator can be used with the current Value(s)</returns>
		public Boolean IsFilterValid()
		{
			return this.LeftFilter.IsFilterValid() && this.RightFilter.IsFilterValid();
		}

		/// <summary>
		///		Equivlant to IFilter.And(IFilter)
		/// </summary>
		public static FilterAnd operator &(FilterAnd leftFilter, IFilter rightFilter)
			=> leftFilter.And(rightFilter);

		/// <summary>
		///		Equivlant to IFilter.Or(IFilter)
		/// </summary>
		public static FilterOr operator |(FilterAnd leftFilter, IFilter rightFilter)
			=> leftFilter.Or(rightFilter);

		/// <summary>
		///		The Filter on the Left, or First Condition
		/// </summary>
		public IFilter LeftFilter { get; }
		/// <summary>
		///		The Filter on the Right, or Last Condition
		/// </summary>
		public IFilter RightFilter { get; }
	}
}
