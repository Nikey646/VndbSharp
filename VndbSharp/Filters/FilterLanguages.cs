using System;
using System.Text;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterLanguages : IFilter
	{
		internal string[] Languages;
		internal FilterOperator Operator;

		public FilterLanguages(string language, FilterOperator filterOperator)
		{
			this.Languages = new [] { language };
			this.Operator = filterOperator;
		}

		public FilterLanguages(string[] languages, FilterOperator filterOperator)
		{
			this.Languages = languages;
			this.Operator = filterOperator;
		}

		public FilterLanguages(params string[] languages)
		{
			this.Languages = languages;
			this.Operator = FilterOperator.Equal;
		}

		public void SetFilterOperator(FilterOperator filterOperator) => this.Operator = filterOperator;

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equals, NotEqual for Platforms.");
			var res = new StringBuilder($"languages {this.Operator} ");

			switch (this.Languages.Length)
			{
				case 0:
					res.Append("null");
					break;
				case 1:
					res.Append(this.Languages[0]);
					break;
				default:
					res.Append($"[\"{string.Join("\",\"", this.Languages)}\"]");
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
