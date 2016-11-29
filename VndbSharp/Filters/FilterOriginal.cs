using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterOriginal : IFilter
	{
		internal string Original;
		internal FilterOperator Operator;

		public FilterOriginal(string original, FilterOperator filterOperator)
		{
			this.Original = original;
			this.Operator = filterOperator;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual when null, Equal, NotEqual or Fuzzy when not null for Original.");
			return $"original {this.Operator} {this.Original ?? "null"}";
		}

		public Boolean IsFilterValid()
		{
			if (this.Original == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
				   this.Operator == FilterOperator.Fuzzy;
		}
	}
}
