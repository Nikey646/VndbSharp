using System;

namespace VndbSharp.Models
{
	/// <summary>
	/// Available filter operators
	/// </summary>
	public class FilterOperator : IEquatable<FilterOperator>
	{
		internal readonly String Operator;
		internal readonly String Name;

		/// <summary>
		///		= Operator
		/// </summary>
		public static FilterOperator Equal { get; } = new FilterOperator("=", "Equals");

		/// <summary>
		///		!= Operator
		/// </summary>
		public static FilterOperator NotEqual { get; } = new FilterOperator("!=", "NotEquals");

		/// <summary>
		///		> Operator
		/// </summary>
		public static FilterOperator GreaterThan { get; } = new FilterOperator(">", "GreaterThan");

		/// <summary>
		///		&lt; Operator
		/// </summary>
		public static FilterOperator LessThan { get; } = new FilterOperator("<", "LessThan");

		/// <summary>
		///		>= Operator
		/// </summary>
		public static FilterOperator GreaterOrEqual { get; } = new FilterOperator(">=", "GreaterThanOrEqual");

		/// <summary>
		///		&lt;= Operator
		/// </summary>
		public static FilterOperator LessOrEqual { get; } = new FilterOperator("<=", "LessThanOrEqual");

		/// <summary>
		///		~ Operator
		/// </summary>
		public static FilterOperator Fuzzy { get; } = new FilterOperator("~", "Fuzzy");


		internal FilterOperator(String value, String name)
		{
			this.Operator = value;
			this.Name = name;
		}

		/// <summary>
		/// Checks if the first filter equals the second filter
		/// </summary>
		/// <param name="filter1">The left IFilter</param>
		/// <param name="filter2">The right IFilter</param>
		/// <returns></returns>
		public static Boolean operator ==(FilterOperator filter1, FilterOperator filter2) => filter1?.Operator == filter2?.Operator;
		/// <summary>
		/// Checks if the first filter is NOT equal to the second filter
		/// </summary>
		/// <param name="filter1">The left IFilter</param>
		/// <param name="filter2">The right IFilter</param>
		/// <returns></returns>
		public static Boolean operator !=(FilterOperator filter1, FilterOperator filter2) => !(filter1 == filter2);
		Boolean IEquatable<FilterOperator>.Equals(FilterOperator other) => this.Operator == other?.Operator;

		/// <summary>
		/// Checks if the 2 objects are equal
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override Boolean Equals(Object obj)
		{
			if (Object.ReferenceEquals(null, obj))
				return false;
			if (Object.ReferenceEquals(this, obj))
				return true;
			return obj.GetType() == this.GetType() && this == (FilterOperator) obj;
		}

		/// <summary>
		/// Converts filter to string
		/// </summary>
		/// <returns></returns>
		public override String ToString() => this.Operator;
		/// <summary>
		/// Gets hash code of Filter
		/// </summary>
		/// <returns></returns>
		public override Int32 GetHashCode() => this.Operator.GetHashCode();
	}
}
