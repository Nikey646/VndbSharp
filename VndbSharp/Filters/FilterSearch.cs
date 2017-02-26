using System;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterSearch : AbstractFilter<String>
	{
		private FilterSearch(String value, FilterOperator filterOperator) : base(value, filterOperator)
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
