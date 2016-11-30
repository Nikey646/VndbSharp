using System;
using System.Collections;
using System.Linq;
using VndbSharp.Interfaces;
using VndbSharp.Structs;

namespace VndbSharp.Filters
{
	public abstract class AbstractFilter<T> : IFilter
	{
		protected abstract FilterOperator[] ValidOperators { get; }
		protected abstract String FilterName { get; }
		protected Boolean CanBeNull = false;

		protected readonly FilterOperator Operator;
		protected readonly T Value;

		/// <summary>
		///		If an array is passed, the number of items.
		/// </summary>
		protected readonly Int32? Count;

		private Type Type;

		protected AbstractFilter(T value, FilterOperator filterOperator)
		{
			this.Value = value;
			this.Operator = filterOperator;

			this.Type = typeof(T);

			var isArray = this.Type.BaseType == typeof(Array);

			if (this.Type.GetGenericArguments().Length <= 0 && !isArray)
				return;

			this.Type = isArray ? this.Type.GetElementType() : this.Type.GetGenericArguments()[0];
			this.Count = (this.Value as IList)?.Count;
		}

		public override String ToString()
		{
			if (!this.IsFilterValid()) // Cannot be in constructor if using abstract classes.
				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, $"Provided filter is not valid. Valid filters are {String.Join(", ", this.ValidOperators.Select(o => o.Name))}");

			var res = $"{this.FilterName} {this.Operator}";

			if (this.CanBeNull && (this.Value == null))
				return $"{res} null";

			var enumerableValue = this.Value as IList;
			if (enumerableValue == null)
				return this.Type == typeof(String) ? $"{res} \"{this.Value}\"" : $"{res} {this.Value}";

			if (enumerableValue.Count == 1)
				return this.Type == typeof(String) ? $"{res} \"{enumerableValue[0]}\"" : $"{res} {enumerableValue[0]}";

			// TODO: Convert using Json.Net JArray object.
			var values = this.Type == typeof(String) ? $"\"{String.Join("\",\"", enumerableValue)}\"" : String.Join(",", enumerableValue);
			return $"{res} [{values}]";
		}

		public abstract Boolean IsFilterValid();
	}
}
