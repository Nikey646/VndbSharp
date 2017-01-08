using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterUserId : AbstractFilter<UInt32>
	{
		public FilterUserId(UInt32 value, FilterOperator filterOperator) : base(value, filterOperator)
		{ } 

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal
		};

		protected override String FilterName { get; } = "uid";

		public static IFilter FromEquals(UInt32 value) => new FilterUserId(value, FilterOperator.Equal);

		public override Boolean IsFilterValid()
			=> this.Operator == FilterOperator.Equal;
	}
}
