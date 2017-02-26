using System;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public class FilterFirstChar : AbstractFilter<Char?>
	{
		private FilterFirstChar(Char? value, FilterOperator filterOperator) : base(value, filterOperator)
		{
			this.CanBeNull = true;
		}

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal, FilterOperator.NotEqual};

		protected override String FilterName { get; } = "firstchar";

		public static IFilter FromEquals(Char? value) => new FilterFirstChar(value, FilterOperator.Equal);
		public static IFilter FromEquals(Char value) => new FilterFirstChar(value, FilterOperator.Equal);
		public static IFilter FromNotEquals(Char? value) => new FilterFirstChar(value, FilterOperator.NotEqual);
		public static IFilter FromNotEquals(Char value) => new FilterFirstChar(value, FilterOperator.NotEqual);

		public override Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
