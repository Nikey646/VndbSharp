using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterReleased : AbstractFilter<Int32?>
	{
		public FilterReleased(DateTime? value, FilterOperator filterOperator) : base(value?.Year, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual,
			FilterOperator.Fuzzy
		};

		protected override String FilterName { get; } = "released";

		public override Boolean IsFilterValid()
		{
			if (this.Value == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator != FilterOperator.Fuzzy;
		}
	}
}
