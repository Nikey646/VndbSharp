using System;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;

namespace VndbSharp.Filters.Conditionals
{
	public class FilterAnd : IFilter
	{
		internal IFilter Filter1;
		internal IFilter Filter2;

		public FilterAnd(IFilter filter1, IFilter filter2)
		{
			filter1.ThrowIfNull();
			filter2.ThrowIfNull();
			this.Filter1 = filter1;
			this.Filter2 = filter2;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filters", "One of the provided filters are not valid.");
			return $"({this.Filter1} and {this.Filter2})";
		}

		public Boolean IsFilterValid()
		{
			return this.Filter1.IsFilterValid() && this.Filter2.IsFilterValid();
		}
	}
}
