using System;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterLanguages : AbstractFilter<String[]>
	{
		private FilterLanguages(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = { FilterOperator.Equal, FilterOperator.NotEqual };

		protected override String FilterName { get; } = "languages";

		public static IFilter FromEquals(String[] value) => new FilterLanguages(value, FilterOperator.Equal);
		public static IFilter FromEquals(String value) => new FilterLanguages(new[] { value }, FilterOperator.Equal);
		public static IFilter FromNotEquals(String[] value) => new FilterLanguages(value, FilterOperator.NotEqual);
		public static IFilter FromNotEquals(String value) => new FilterLanguages(new[] { value }, FilterOperator.NotEqual);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
