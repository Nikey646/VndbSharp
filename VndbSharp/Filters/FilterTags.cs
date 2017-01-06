using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterTags : AbstractFilter<Int32[]>
	{
		public FilterTags(Int32[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = { FilterOperator.Equal, FilterOperator.NotEqual };

		protected override String FilterName { get; } = "tags";

		public static IFilter FromEquals(Int32[] value) => new FilterTags(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(Int32[] value) => new FilterTags(value, FilterOperator.NotEqual);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
