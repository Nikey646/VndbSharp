using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterId : AbstractFilter<Int32>
	{
		public FilterId(Int32 value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.LessOrEqual, FilterOperator.LessThan,
			FilterOperator.GreaterOrEqual, FilterOperator.GreaterThan
		};

		protected override String FilterName { get; } = "id";

		public override Boolean IsFilterValid()
		{
			if (this.Operator == FilterOperator.Fuzzy) // Only banned operator
				return false;
			if (this.Count > 1) // Only = and != are allowed when multiple values are passed
				return (this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual);
			return true;
		}
	}
}
