using System;
using System.Linq;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterUsername : AbstractFilter<String[]>
	{
		private FilterUsername(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.Fuzzy
		};

		protected override String FilterName { get; } = "username";

		public static IFilter FromEquals(String[] value) => new FilterUsername(value, FilterOperator.Equal);
		public static IFilter FromEquals(String value) => new FilterUsername(new[] { value }, FilterOperator.Equal);
		public static IFilter FromNotEquals(String[] value) => new FilterUsername(value, FilterOperator.NotEqual);
		public static IFilter FromNotEquals(String value) => new FilterUsername(new[] { value }, FilterOperator.NotEqual);
		public static IFilter FromFuzzy(String[] value) => new FilterUsername(value, FilterOperator.Fuzzy);
		public static IFilter FromFuzzy(String value) => new FilterUsername(new[] {value}, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			if (this.Value.Length > 1)
				return this.Operator == FilterOperator.Equal;
			return this.ValidOperators.Contains(this.Operator);
		}
	}
}
