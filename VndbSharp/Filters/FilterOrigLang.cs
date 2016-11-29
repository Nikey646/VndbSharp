using System;
using System.Text;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterOrigLang : IFilter
	{
		internal string[] OrigLangs;
		internal FilterOperator Operator;

		public FilterOrigLang(string origLang, FilterOperator filterOperator)
		{
			this.OrigLangs = new [] {origLang};
			this.Operator = filterOperator;
		}

		public FilterOrigLang(string[] origLangs, FilterOperator filterOperator)
		{
			this.OrigLangs = origLangs;
			this.Operator = filterOperator;
		}

		public FilterOrigLang(params string[] origLangs)
		{
			this.OrigLangs = origLangs;
			this.Operator = FilterOperator.Equal;
		}

		public void SetFilterOperator(FilterOperator filterOperator) => this.Operator = filterOperator;

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual for OrigLang.");

			var res = new StringBuilder($"orig_lang {this.Operator} ");

			switch (this.OrigLangs.Length)
			{
				case 1:
					res.Append(this.OrigLangs[0]);
					break;
				default:
					res.Append($"[\"{string.Join("\",\"", this.OrigLangs)}\"]");
					break;
			}

			return res.ToString();
		}

		public Boolean IsFilterValid()
		{
			return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
		}
	}
}
