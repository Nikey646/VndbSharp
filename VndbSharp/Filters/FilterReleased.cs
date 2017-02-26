using System;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;
using VndbSharp.Models;
using VndbSharp.Models.Common;

namespace VndbSharp.Filters
{
	public class FilterReleased : AbstractFilter<String>
	{
		private FilterReleased(SimpleDate value, FilterOperator filterOperator) : base(value.ToString().Quote(), filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = {
			FilterOperator.Equal, FilterOperator.NotEqual,
			FilterOperator.Fuzzy
		};

		protected override String FilterName { get; } = "released";

		public static IFilter FromEquals(SimpleDate value) => new FilterReleased(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(SimpleDate value) => new FilterReleased(value, FilterOperator.NotEqual);
		public static IFilter FromFuzzy(SimpleDate value) => new FilterReleased(value, FilterOperator.Fuzzy);

		public override Boolean IsFilterValid()
		{
			if (this.Value == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator != FilterOperator.Fuzzy;
		}
	}
}
