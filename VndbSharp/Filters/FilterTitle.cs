using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterTitle : AbstractFilter<String>
	{
		public FilterTitle(String value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual,
			FilterOperator.Fuzzy
		};

		protected override String FilterName { get; } = "title";

		public static IFilter FromEquals(String value) => new FilterTitle(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(String value) => new FilterTitle(value, FilterOperator.NotEqual);
		public static IFilter FromFuzzy(String value) => new FilterTitle(value, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
				   this.Operator == FilterOperator.Fuzzy;
		}
	}
}
