using System;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterPlatforms : AbstractFilter<String[]>
	{
		public FilterPlatforms(String value, FilterOperator filterOperator) : this(new[] { value }, filterOperator)
		{ }

		public FilterPlatforms(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = { FilterOperator.Equal, FilterOperator.NotEqual };

		protected override String FilterName { get; } = "platforms";

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
