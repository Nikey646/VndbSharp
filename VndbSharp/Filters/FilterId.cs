using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterId : IFilter
	{
		internal Int32[] Ids;

		internal FilterOperator Operator;

		public FilterId(Int32 id, FilterOperator filterOperator)
		{
			this.Ids = new[] {id};
			this.Operator = filterOperator;
		}

		public FilterId(Int32[] ids, FilterOperator filterOperator)
		{
			this.Ids = ids;
			this.Operator = filterOperator;
		}

		public FilterId(params Int32[] ids)
		{
			this.Ids = ids;
			this.Operator = FilterOperator.Equal;
		}

		public void SetFilterOperator(FilterOperator filterOperator) => this.Operator = filterOperator;

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator was not valid. When searching multiple integers, you may only use Equal and NotEqual.");

			if (this.Ids.Length == 1)
				return $"id {this.Operator} {this.Ids[0]}";

			return $"id {this.Operator} [{String.Join(",", this.Ids)}]";
		}

		public Boolean IsFilterValid()
		{
			if (this.Operator == FilterOperator.Fuzzy)
				return false;
			if (this.Ids.Length > 1)
				return (this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual);
			return true;
		}
	}
}
