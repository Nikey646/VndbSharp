using System;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterOriginal : AbstractFilter<String>
	{
		public FilterOriginal(String value, FilterOperator filterOperator) : base(value, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual,
			FilterOperator.Fuzzy
		};

		protected override String FilterName { get; } = "original";

		public static IFilter FromEquals(String value) => new FilterOriginal(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(String value) => new FilterOriginal(value, FilterOperator.NotEqual);
		public static IFilter FromFuzzy(String value) => new FilterOriginal(value, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			if (this.Value == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
				   this.Operator == FilterOperator.Fuzzy;
		}
	}
}
