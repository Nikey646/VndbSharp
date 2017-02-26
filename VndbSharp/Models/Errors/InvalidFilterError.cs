using System;

namespace VndbSharp.Models.Errors
{
	/// <summary>
	///		Unknown filter field or invalid combination of field / operator / argument type
	/// </summary>
	public class InvalidFilterError : Error
	{
		/// <summary>
		///		The field given
		/// </summary>
		public String Field { get; private set; }
		/// <summary>
		///		The operator given
		/// </summary>
		public String Operator { get; private set; }
		/// <summary>
		///		The value given
		/// </summary>
		public String Value { get; private set; }
	}
}