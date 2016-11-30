using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterOrigLang : AbstractFilter<String[]>
	{
		public FilterOrigLang(String value, FilterOperator filterOperator) : this(new [] {value}, filterOperator)
		{ }

		public FilterOrigLang(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal, FilterOperator.NotEqual};

		protected override String FilterName { get; } = "orig_lang";

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
