using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterVisualNovel : AbstractFilter<Int32[]>
	{
		public FilterVisualNovel(Int32 value) : this(new[] {value}, FilterOperator.Equal)
		{ }

		public FilterVisualNovel(Int32[] value) : this(value, FilterOperator.Equal)
		{ }

		public FilterVisualNovel(Int32[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal};

		protected override String FilterName { get; } = "vn";

		public static IFilter FromEquals(Int32[] value) => new FilterVisualNovel(value, FilterOperator.Equal);
		public static IFilter FromEquals(Int32 value) => new FilterVisualNovel(value);

		public override Boolean IsFilterValid() => this.Operator == FilterOperator.Equal;
	}
}
