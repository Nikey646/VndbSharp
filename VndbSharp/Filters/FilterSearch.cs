using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterSearch : IFilter
	{
		internal string Search;
		internal FilterOperator Operator;

		public FilterSearch(string query)
		{
			this.Search = query;
			this.Operator = FilterOperator.Fuzzy;
		}

		public override String ToString()
		{
			return $"search ~ \"{this.Search}\"";
		}

		public Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Fuzzy;
		}
	}
}
