using System;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterOrigLang : AbstractFilter<String[]>
	{
		private FilterOrigLang(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal, FilterOperator.NotEqual};

		protected override String FilterName { get; } = "orig_lang";

		public static IFilter FromEquals(String[] value) => new FilterOrigLang(value, FilterOperator.Equal);
		public static IFilter FromEquals(String value) => new FilterOrigLang(new[] { value }, FilterOperator.Equal);
		public static IFilter FromNotEquals(String[] value) => new FilterOrigLang(value, FilterOperator.NotEqual);
		public static IFilter FromNotEquals(String value) => new FilterOrigLang(new[] { value }, FilterOperator.NotEqual);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
