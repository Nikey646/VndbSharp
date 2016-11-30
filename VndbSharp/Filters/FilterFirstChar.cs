using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterFirstChar : AbstractFilter<Char?>
	{
		public FilterFirstChar(Char? value, FilterOperator filterOperator) : base(value, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal, FilterOperator.NotEqual};

		protected override String FilterName { get; } = "firstchar";

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
