using System;
using System.Text;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public class FilterPlatforms : IFilter
	{
		internal string[] Platforms;
		internal FilterOperator Operator;

		public FilterPlatforms(string platform, FilterOperator filterOperator)
		{
			this.Platforms = new [] { platform };
			this.Operator = filterOperator;
		}

		public FilterPlatforms(string[] platforms, FilterOperator filterOperator)
		{
			this.Platforms = platforms;
			this.Operator = filterOperator;
		}

		public FilterPlatforms(params string[] platforms)
		{
			this.Platforms = platforms;
			this.Operator = FilterOperator.Equal;
		}

		public void SetFilterOperator(FilterOperator filterOperator) => this.Operator = filterOperator;

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual for Languages.");
			var res = new StringBuilder($"released {this.Operator} ");

			switch (this.Platforms.Length)
			{
				case 0:
					res.Append("null");
					break;
				case 1:
					res.Append(this.Platforms[0]);
					break;
				default:
					res.Append($"[\"{string.Join("\",\"", this.Platforms)}\"]");
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
