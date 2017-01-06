using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterSearch : AbstractFilter<String>
	{
		public FilterSearch(String value) : this(value, FilterOperator.Fuzzy)
		{ }

		public FilterSearch(String value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Fuzzy};

		protected override String FilterName { get; } = "search";

		public static IFilter FromFuzzy(String value) => new FilterSearch(value, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Fuzzy;
		}
	}
}
