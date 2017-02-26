using System;
using System.Collections.Generic;
using System.Linq;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterId : AbstractFilter<UInt32[]>
	{
		internal FilterId(UInt32[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.LessOrEqual, FilterOperator.LessThan,
			FilterOperator.GreaterOrEqual, FilterOperator.GreaterThan
		};

		protected override String FilterName { get; } = "id";

		public static IFilter FromEquals(UInt32 value) => new FilterId(new []{value}, FilterOperator.Equal);
		public static IFilter FromNotEquals(UInt32 value) => new FilterId(new[] { value }, FilterOperator.NotEqual);
		public static IFilter FromGreaterThan(UInt32 value) => new FilterId(new[] { value }, FilterOperator.GreaterThan);
		public static IFilter FromGreaterOrEqual(UInt32 value) => new FilterId(new[] { value }, FilterOperator.GreaterOrEqual);
		public static IFilter FromLessThan(UInt32 value) => new FilterId(new[] { value }, FilterOperator.LessThan);
		public static IFilter FromLessOrEqual(UInt32 value) => new FilterId(new[] { value }, FilterOperator.LessOrEqual);

		public static IFilter FromEquals(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.Equal);
		public static IFilter FromNotEquals(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.NotEqual);
		public static IFilter FromGreaterThan(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.GreaterThan);
		public static IFilter FromGreaterOrEqual(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.GreaterOrEqual);
		public static IFilter FromLessThan(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.LessThan);
		public static IFilter FromLessOrEqual(IEnumerable<UInt32> value) => new FilterId(value.ToArray(), FilterOperator.LessOrEqual);

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
