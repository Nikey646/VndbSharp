using System;
using System.Linq;
using VndbSharp.Extensions;
using VndbSharp.Filters;
using VndbSharp.Models;
using VndbSharp.Models.Common;

namespace VndbSharp
{
	// Not public yet
	/// <summary>
	/// Available Filters
	/// </summary>
	public class VndbFilters
	{
		/// <summary>
		/// Filters for Id
		/// </summary>
		public class Id : AbstractFilter<UInt32[]>
		{
			internal Id(UInt32[] value, FilterOperator filterOperator)
				: base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of valid operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.LessOrEqual, FilterOperator.LessThan,
				FilterOperator.GreaterOrEqual, FilterOperator.GreaterThan
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "id";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id Equals(params UInt32[] value) => new Id(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id NotEquals(params UInt32[] value) => new Id(value, FilterOperator.NotEqual);

			/// <summary>
			/// Greater Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id GreaterThan(UInt32 value) => new Id(new[] { value }, FilterOperator.GreaterThan);
			/// <summary>
			/// Greater or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id GreaterOrEqual(UInt32 value) => new Id(new[] { value }, FilterOperator.GreaterOrEqual);
			/// <summary>
			/// Less Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id LessThan(UInt32 value) => new Id(new[] { value }, FilterOperator.LessThan);
			/// <summary>
			/// Less Than or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Id LessOrEqual(UInt32 value) => new Id(new[] { value }, FilterOperator.LessOrEqual);

			/// <summary>
			/// Is the Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
			{
				if (this.Count > 1) // Only = and != are allowed when multiple values are passed
					return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
				return this.ValidOperators.Contains(this.Operator);
			}
		}

		/// <summary>
		/// Alias ID Filter
		/// </summary>
		public class AliasId : AbstractFilter<UInt32[]>
		{
			internal AliasId(UInt32[] value, FilterOperator filterOperator)
				: base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "id";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static AliasId Equals(params UInt32[] value) => new AliasId(value, FilterOperator.Equal);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
			{;
				return this.ValidOperators.Contains(this.Operator);
			}
		}

		/// <summary>
		/// UserId Filter
		/// </summary>
		public class UserId : AbstractFilter<UInt32>
		{
			private UserId(UInt32 value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Valid Operators Array
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "uid";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static UserId Equals(UInt32 value) => new UserId(value, FilterOperator.Equal);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.Operator == FilterOperator.Equal;
		}

		/// <summary>
		/// First Character Filter
		/// </summary>
		public class FirstChar : AbstractFilter<Char?>
		{
			private FirstChar(Char? value, FilterOperator filterOperator)
				: base(value ?? Char.ToLower(value.Value), filterOperator) // May cause problems?
			{
				this.CanBeNull = true;
			}

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = { FilterOperator.Equal, FilterOperator.NotEqual };

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "firstchar";

			/// <summary>
			/// Equality Filter, supports null
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static FirstChar Equals(Char? value) => new FirstChar(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter, supports null
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static FirstChar NotEquals(Char? value) => new FirstChar(value, FilterOperator.NotEqual);

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static FirstChar Equals(Char value) => new FirstChar(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static FirstChar NotEquals(Char value) => new FirstChar(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Released Filter
		/// </summary>
		public class Released : AbstractFilter<String>
		{
			private Released(SimpleDate value, FilterOperator filterOperator)
				: base(value.ToString(), filterOperator)
			{
				this.CanBeNull = true;
			}

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.LessOrEqual, FilterOperator.LessThan,
				FilterOperator.GreaterOrEqual, FilterOperator.GreaterThan
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "released";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released Equals(SimpleDate value) => new Released(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released NotEquals(SimpleDate value) => new Released(value, FilterOperator.NotEqual);
			/// <summary>
			/// Greater Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released GreaterThan(SimpleDate value) => new Released(value, FilterOperator.LessOrEqual);
			/// <summary>
			/// Greater than or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released GreaterOrEqual(SimpleDate value) => new Released(value, FilterOperator.LessOrEqual);
			/// <summary>
			/// Less Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released LessThan(SimpleDate value) => new Released(value, FilterOperator.LessOrEqual);
			/// <summary>
			/// Less Than Or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Released LessOrEqual(SimpleDate value) => new Released(value, FilterOperator.LessOrEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
			{
				if (this.Value == null)
					return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
				return this.Operator != FilterOperator.Fuzzy;
			}
		}

		/// <summary>
		/// Languages Filter
		/// </summary>
		public class Languages : AbstractFilter<String[]>
		{
			private Languages(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{
				this.CanBeNull = true;
			}

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "languages";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Languages Equals(params String[] value) => new Languages(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Languages NotEquals(params String[] value) => new Languages(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Original Name Filter
		/// </summary>
		public class OriginalName : AbstractFilter<String>
		{
			/// <summary>
			/// Original Name Filter
			/// </summary>
			/// <param name="value"></param>
			/// <param name="filterOperator"></param>
			public OriginalName(String value, FilterOperator filterOperator) : base(value, filterOperator)
			{
				this.CanBeNull = true;
			}

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.Fuzzy
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "original";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static OriginalName Equals(String value) => new OriginalName(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static OriginalName NotEquals(String value) => new OriginalName(value, FilterOperator.NotEqual);
			/// <summary>
			/// Fuzzy Search Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static OriginalName Fuzzy(String value) => new OriginalName(value, FilterOperator.Fuzzy);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
			{
				if (this.Value == null)
					return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual;
				return this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual ||
					   this.Operator == FilterOperator.Fuzzy;
			}
		}

		/// <summary>
		/// Original Languge Filter
		/// </summary>
		public class OriginalLanguage : AbstractFilter<String[]>
		{
			private OriginalLanguage(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "orig_lang";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static OriginalLanguage Equals(params String[] value) => new OriginalLanguage(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static OriginalLanguage NotEquals(params String[] value) => new OriginalLanguage(value, FilterOperator.NotEqual);
			
			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Platforms Filter
		/// </summary>
		public class Platforms : AbstractFilter<String[]>
		{
			private Platforms(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{
				this.CanBeNull = true;
			}

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "platforms";
			
			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Platforms Equals(params String[] value) => new Platforms(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Platforms NotEquals(params String[] value) => new Platforms(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Search FIlter
		/// </summary>
		public class Search : AbstractFilter<String>
		{
			private Search(String value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Fuzzy
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "search";

			/// <summary>
			/// Fuzzy Search
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Search Fuzzy(String value) => new Search(value, FilterOperator.Fuzzy);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.Operator == FilterOperator.Fuzzy;
		}

		/// <summary>
		/// Tags Filter
		/// </summary>
		public class Tags : AbstractFilter<Int32[]>
		{
			private Tags(Int32[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "tags";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Tags Equals(params Int32[] value) => new Tags(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Tags NotEquals(params Int32[] value) => new Tags(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		// So kindly stolen from http://vndb.org/d11
		/// <summary>
		///		<para>Find chars by traits. When providing an array of ints, the '=' filter will return chars that are linked to any (not all) of the given traits, the '!=' filter will return chars that are not linked to any of the given traits. You can combine multiple trait filters with 'and' and 'or' to get the exact behavior you need.</para>
		///		<para>This filter may used cached data, it may take up to 24 hours before a char entry will have its traits updated with respect to this filter.</para>
		///		<para>Chars that are linked to childs of the given trait are also included.</para>
		///		<para>Be warned that this filter ignores spoiler settings, fetch the traits associated with the returned char to verify the spoiler level.</para>
		/// </summary>
		public class Traits : AbstractFilter<UInt32[]>
		{
			private Traits(UInt32[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "traits";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Traits Equals(params UInt32[] value) => new Traits(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Traits NotEquals(params UInt32[] value) => new Traits(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Title Filter
		/// </summary>
		public class Title : AbstractFilter<String>
		{
			private Title(String value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.Fuzzy
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "title";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Title Equals(String value) => new Title(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equal Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Title NotEquals(String value) => new Title(value, FilterOperator.NotEqual);
			/// <summary>
			/// Fuzzy Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Title Fuzzy(String value) => new Title(value, FilterOperator.Fuzzy);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Name Filter
		/// </summary>
		public class Name : AbstractFilter<String>
		{
			private Name(String value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.Fuzzy
			};

			/// <summary>
			/// Valid Operators
			/// </summary>
			protected override String FilterName { get; } = "name";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Name Equals(String value) => new Name(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Name NotEquals(String value) => new Name(value, FilterOperator.NotEqual);
			/// <summary>
			/// Fuzzy Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Name Fuzzy(String value) => new Name(value, FilterOperator.Fuzzy);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Username Filter
		/// </summary>
		public class Username : AbstractFilter<String[]>
		{
			private Username(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.Fuzzy
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "username";
			
			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Username Equals(params String[] value) => new Username(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Username NotEquals(params String[] value) => new Username(value, FilterOperator.NotEqual);
			/// <summary>
			/// Fuzzy Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Username Fuzzy(params String[] value) => new Username(value, FilterOperator.Fuzzy);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
			{
				if (this.Value.Length > 1)
					return this.Operator == FilterOperator.Equal;
				return this.ValidOperators.Contains(this.Operator);
			}
		}

		/// <summary>
		/// Visual Novel Filter
		/// </summary>
		public class VisualNovel : AbstractFilter<UInt32[]>
		{
			private VisualNovel(UInt32[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual, FilterOperator.LessOrEqual, FilterOperator.LessThan,
				FilterOperator.GreaterOrEqual, FilterOperator.GreaterThan
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "vn";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel Equals(params UInt32[] value) => new VisualNovel(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel NotEquals(params UInt32[] value) => new VisualNovel(value, FilterOperator.NotEqual);

			/// <summary>
			/// Greater Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel GreaterThan(UInt32 value) => new VisualNovel(new[] { value }, FilterOperator.GreaterThan);
			/// <summary>
			/// Greater Or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel GreaterOrEqual(UInt32 value) => new VisualNovel(new[] { value }, FilterOperator.GreaterOrEqual);
			/// <summary>
			/// Less Than Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel LessThan(UInt32 value) => new VisualNovel(new[] { value }, FilterOperator.LessThan);
			/// <summary>
			/// Less Than Or Equal To Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static VisualNovel LessOrEqual(UInt32 value) => new VisualNovel(new[] { value }, FilterOperator.LessOrEqual);

			// This may fail on filters where vn is only =...
			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.Count > 1
					? this.Operator == FilterOperator.Equal || this.Operator == FilterOperator.NotEqual
					: this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Platform Filter
		/// </summary>
		public class Platform : AbstractFilter<String[]>
		{
			private Platform(String[] value, FilterOperator filterOperator) : base(value, filterOperator)
			{ }

			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = {
				FilterOperator.Equal, FilterOperator.NotEqual
			};

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; } = "platforms";

			/// <summary>
			/// Equality Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Platform Equals(params String[] value) => new Platform(value, FilterOperator.Equal);
			/// <summary>
			/// Not Equals Filter
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static Platform NotEquals(params String[] value) => new Platform(value, FilterOperator.NotEqual);

			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid()
				=> this.ValidOperators.Contains(this.Operator);
		}

		/// <summary>
		/// Raw Filter
		/// </summary>
		public class Raw : AbstractFilter<String>
		{
			private Raw(String name, String value, FilterOperator filterOperator)
				: base(value, filterOperator)
			{
				this.FilterName = name;
				this.CanBeNull = true;
			}

			// This being blank should be fine, since we won't be using it.
			/// <summary>
			/// Array of Valid Operators
			/// </summary>
			protected override FilterOperator[] ValidOperators { get; } = { };

			/// <summary>
			/// Filter Name
			/// </summary>
			protected override String FilterName { get; }

			/// <summary>
			/// Create Filter
			/// </summary>
			/// <param name="name"></param>
			/// <param name="value"></param>
			/// <param name="filterOperator"></param>
			/// <returns></returns>
			public static Raw Create(String name, String value, FilterOperator filterOperator) 
				=> new Raw(name, value, filterOperator);

			// This is a filter we will rely on vndb yelling at us about.
			/// <summary>
			/// Is Filter Valid
			/// </summary>
			/// <returns></returns>
			public override Boolean IsFilterValid() 
				=> true;
		}
	}
}
