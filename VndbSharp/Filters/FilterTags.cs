using System;
using System.Text;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	/// <summary>
	///		Find VNs by tag. When providing an array of ints, the '=' filter will return VNs that are linked to any (not all) of the given tags, the '!=' filter will return VNs that are not linked to any of the given tags. You can combine multiple tags filters with 'and' and 'or' to get the exact behavior you need.
	///		This filter may used cached data, it may take up to 24 hours before a VN will have its tag updated with respect to this filter.
	///  	Be warned that this filter ignores spoiler settings, fetch the tags associated with the returned VN to verify the spoiler level.
	/// </summary>
	public class FilterTags : IFilter
	{
		internal Int32[] Tags;
		internal FilterOperator Operator;

		public FilterTags(Int32 tag, FilterOperator filterOperator)
		{
			this.Tags = new[] { tag };
			this.Operator = filterOperator;
		}

		public FilterTags(Int32[] tags, FilterOperator filterOperator)
		{
			this.Tags = tags;
			this.Operator = filterOperator;
		}

		public FilterTags(params Int32[] tags)
		{
			this.Tags = tags;
			this.Operator = FilterOperator.Equal;
		}

		public void SetFilterOperator(FilterOperator filterOperator) => this.Operator = filterOperator;

		public override String ToString()
		{
			if (!this.IsFilterValid())
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, "filterOperator must be Equal, NotEqual for OrigLang.");

			var res = new StringBuilder($"tags {this.Operator} ");

			switch (this.Tags.Length)
			{
				case 1:
					res.Append(this.Tags[0]);
					break;
				default:
					res.Append($"[{string.Join(",", this.Tags)}]");
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
