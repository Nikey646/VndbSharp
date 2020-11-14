using VndbSharp.Attributes;

namespace VndbSharp.Models.Common
{
	/// <summary>
	/// Valid Gender Types
	/// </summary>
	public enum Gender
	{
		/// <summary>
		/// Male gender
		/// </summary>
		[RealValue("m")]
		Male,
		/// <summary>
		/// Female gender
		/// </summary>
		[RealValue("f")]
		Female,
		/// <summary>
		/// Mixed/Both Gender
		/// </summary>
		[RealValue("b")]
		Both,
		/// <summary>
		/// Unknown gender for use with SpoilGender
		/// </summary>
		[RealValue("unknown")]
		Unknown
	}
}