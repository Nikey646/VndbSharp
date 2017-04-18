using VndbSharp.Attributes;

namespace VndbSharp.Models.Character
{
	public enum Gender
	{
		[RealValue("m")]
		Male,
		[RealValue("f")]
		Female,
		[RealValue("b")]
		Both
	}
}