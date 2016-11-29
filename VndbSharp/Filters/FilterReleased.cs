using System;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	/// <summary>
	///		Note that matching on partial dates (released = "2009") doesn't do what you want, use ranges instead, e.g. (released > "2008" and released &lt;= "2009").
	///		P.S: Currently only supports year.
	/// </summary>
	public class FilterReleased : IFilter
	{
		internal DateTime? Date;
		internal FilterOperator Operator;

		public FilterReleased(DateTime? date, FilterOperator filterOperator)
		{
			this.Date = date;
			this.Operator = filterOperator;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual when null, or not fuzzy when not-null for Date.");
			return $"released {this.Operator} {this.Date?.Year.ToString() ?? "null"}";
		}

		public Boolean IsFilterValid()
		{
			if (this.Date == null)
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
			return this.Operator != FilterOperator.Fuzzy;
		}
	}
}
