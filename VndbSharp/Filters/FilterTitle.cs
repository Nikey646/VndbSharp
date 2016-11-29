using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterTitle : IFilter
	{
		internal string Title;
		internal FilterOperator Operator;

		public FilterTitle(string title, FilterOperator filterOperator)
		{
			this.Title = title;
			this.Operator = filterOperator;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual or Fuzzy for Title.");
			return $"title {this.Operator} {this.Title}";
		}

		public Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
				   this.Operator == FilterOperator.Fuzzy;
		}
	}
}
