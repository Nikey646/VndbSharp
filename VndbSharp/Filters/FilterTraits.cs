using System;
using System.Linq;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	// So kindly stolen from http://vndb.org/d11
	/// <summary>
	///		<para>Find chars by traits. When providing an array of ints, the '=' filter will return chars that are linked to any (not all) of the given traits, the '!=' filter will return chars that are not linked to any of the given traits. You can combine multiple trait filters with 'and' and 'or' to get the exact behavior you need.</para>
	///		<para>This filter may used cached data, it may take up to 24 hours before a char entry will have its traits updated with respect to this filter.</para> 
	///		<para>Chars that are linked to childs of the given trait are also included.</para>
	///		<para>Be warned that this filter ignores spoiler settings, fetch the traits associated with the returned char to verify the spoiler level.</para>
	/// </summary> 
	public class FilterTraits : AbstractFilter<UInt32[]>
	{
		private FilterTraits(UInt32[] value, FilterOperator filterOperator) : base(value, filterOperator)
		{ }

		protected override FilterOperator[] ValidOperators { get; } = {FilterOperator.Equal, FilterOperator.NotEqual};

		protected override String FilterName { get; } = "traits";

		public static FilterTraits Equals(params UInt32[] value) => new FilterTraits(value, FilterOperator.Equal);
		public static FilterTraits NotEquals(params UInt32[] value) => new FilterTraits(value, FilterOperator.NotEqual);

		public override Boolean IsFilterValid()
			=> this.ValidOperators.Contains(this.Operator);
	}
}
