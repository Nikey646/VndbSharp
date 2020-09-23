using VndbSharp.Attributes;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Visual Novel Length
	/// </summary>
	public enum VisualNovelLength
	{
		/// <summary>
		/// Unknown Length
		/// </summary>
		Unknown = 0,
		/// <summary>
		/// Very Short (Less than 2 hours)
		/// </summary>
		[Description("< 2 hours")]
		VeryShort = 1,
		/// <summary>
		/// Short (2 - 10 hours)
		/// </summary>
		[Description("2 - 10 hours")]
		Short = 2,
		/// <summary>
		/// Medium (10 - 30 hours)
		/// </summary>
		[Description("10 - 20 hours")]
		Medium = 3,
		/// <summary>
		/// Long (30 - 50 hours)
		/// </summary>
		[Description("30 - 50 hours")]
		Long = 4,
		/// <summary>
		/// Very Long (50 hours or more)
		/// </summary>
		[Description("> 50 hours")]
		VeryLong = 5,
	}
}