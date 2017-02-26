using System;
using System.Collections;
using System.Reflection;
using System.Text;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp.Filters
{
	public abstract class AbstractFilter<T> : IFilter
	{
		protected AbstractFilter(T value, FilterOperator filterOperator)
		{
			this.Value = value;
			this.Operator = filterOperator;

			this.Type = typeof(T);

			var isArray = this.Type.GetTypeInfo().BaseType == typeof(Array);

			if (this.Type.GetTypeInfo().GenericTypeArguments.Length <= 0 && !isArray)
				return;

			this.Type = isArray ? this.Type.GetElementType() : this.Type.GetTypeInfo().GenericTypeArguments[0];
			this.Count = (this.Value as IList)?.Count;
		}

		public override String ToString()
		{
//			if (!this.IsFilterValid()) // Cannot be in constructor if using abstract classes.
//				throw new ArgumentOutOfRangeException("filterOperator", this.Operator, $"Provided filter is not valid. Valid filters are {String.Join(", ", this.ValidOperators.Select(o => o.Name))}");

			var res = $"{this.FilterName} {this.Operator}";

			if (this.CanBeNull && (this.Value == null))
				return $"{res} null";

			var valueList = this.Value as IList;
			if (valueList == null)
				return this.Type == typeof(String) ? $"{res} \"{this.Value}\"" : $"{res} {this.Value}";

			if (valueList.Count == 1)
				return this.Type == typeof(String) ? $"{res} \"{valueList[0]}\"" : $"{res} {valueList[0]}";

			var values = new StringBuilder();
			if (this.Type == typeof(String))
			{
				values.Append($"\"{String.Join("\",\"", valueList)}\"");
			}
			else
			{
				// TODO: Improve?
				for (var i = 0; i < valueList.Count; i++)
				{
					values.Append(valueList[i]);
					if (i+1 != valueList.Count)
						values.Append(",");
				}
			}

			return $"{res} [{values}]";
		}

		/// <summary>
		///		Equivlant to IFilter.And(IFilter)
		/// </summary>
		public static IFilter operator &(AbstractFilter<T> filter1, IFilter filter2)
			=> filter1.And(filter2);

		/// <summary>
		///		Equivlant to IFilter.Or(IFilter)
		/// </summary>
		public static IFilter operator |(AbstractFilter<T> filter1, IFilter filter2)
			=> filter1.Or(filter2);

		public abstract Boolean IsFilterValid();

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
	}
}
