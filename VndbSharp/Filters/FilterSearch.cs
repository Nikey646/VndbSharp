using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterSearch : AbstractFilter<String>
	{
		public FilterSearch(String value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Fuzzy};

		protected override String FilterName { get; } = "search";

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Fuzzy;
		}
	}
}
