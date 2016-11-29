using System;

namespace VndbSharp.Structs
{
	public class FilterOperator : IEquatable<FilterOperator>
	{
		internal readonly string Operator;

		/// <summary>
		///		= Operator
		/// </summary>
		public static FilterOperator Equal { get; } = new FilterOperator("=");

		/// <summary>
		///		!= Operator
		/// </summary>
		public static FilterOperator NotEqual { get; } = new FilterOperator("!=");

		/// <summary>
		///		> Operator
		/// </summary>
		public static FilterOperator GreaterThan { get; } = new FilterOperator(">");

		/// <summary>
		///		&lt; Operator
		/// </summary>
		public static FilterOperator LessThan { get; } = new FilterOperator("<");

		/// <summary>
		///		>= Operator
		/// </summary>
		public static FilterOperator GreaterOrEqual { get; } = new FilterOperator(">=");

		/// <summary>
		///		&lt;= Operator
		/// </summary>
		public static FilterOperator LessOrEqual { get; } = new FilterOperator("<=");

		/// <summary>
		///		~ Operator
		/// </summary>
		public static FilterOperator Fuzzy { get; } = new FilterOperator("~");


		internal FilterOperator(string value)
		{
			this.Operator = value;
		}

		public static Boolean operator ==(FilterOperator filter1, FilterOperator filter2) => filter1?.Operator == filter2?.Operator;
		public static Boolean operator !=(FilterOperator filter1, FilterOperator filter2) => !(filter1 == filter2);
		Boolean IEquatable<FilterOperator>.Equals(FilterOperator other) => this.Operator == other?.Operator;

		public override Boolean Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			return obj.GetType() == this.GetType() && this == (FilterOperator)obj;
		}

		public override String ToString() => this.Operator;
		public override int GetHashCode() => this.Operator.GetHashCode();
	}
}
