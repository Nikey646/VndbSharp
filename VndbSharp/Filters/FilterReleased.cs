using System;
using VndbSharp.Interfaces;
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

		public static IFilter FromEquals(DateTime? value) => new FilterReleased(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(DateTime? value) => new FilterReleased(value, FilterOperator.NotEqual);
		public static IFilter FromFuzzy(DateTime? value) => new FilterReleased(value, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			if (this.Value == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator != FilterOperator.Fuzzy;
		}
	}
}
