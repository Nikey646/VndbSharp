using System;
using VndbSharp.Structs;

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

		public override Boolean IsFilterValid()
		{
			if (this.Value == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
				   this.Operator == FilterOperator.Fuzzy;
		}
	}
}
