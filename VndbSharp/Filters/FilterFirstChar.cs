using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterFirstChar : IFilter
	{
		internal char? Character;
		internal FilterOperator Operator;

		public FilterFirstChar(char? character, FilterOperator filterOperator)
		{
			this.Character = character;
			this.Operator = filterOperator;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual for FirstChar.");
			return $"firstchar {this.Operator} {this.Character?.ToString() ?? "null"}";
		}

		public Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
