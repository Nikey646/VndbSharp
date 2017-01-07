using System;
using VndbSharp.Interfaces;
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

		public static IFilter FromEquals(Int32 value) => new FilterId(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(Int32 value) => new FilterId(value, FilterOperator.NotEqual);
		public static IFilter FromGreaterThan(Int32 value) => new FilterId(value, FilterOperator.GreaterThan);
		public static IFilter FromGreaterOrEqual(Int32 value) => new FilterId(value, FilterOperator.GreaterOrEqual);
		public static IFilter FromLessThan(Int32 value) => new FilterId(value, FilterOperator.LessThan);
		public static IFilter FromLessOrEqual(Int32 value) => new FilterId(value, FilterOperator.LessOrEqual);

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
