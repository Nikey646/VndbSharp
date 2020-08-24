using VndbSharp.Attributes;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Visual Novel Relations
	/// </summary>
	public enum RelationType
	{
		/// <summary>
		/// Sequel
		/// </summary>
		[RealValue("seq")]
		Sequel,
		/// <summary>
		/// Prequel
		/// </summary>
		[RealValue("preq")]
		Prequel,
		/// <summary>
		/// In the same setting
		/// </summary>
		[RealValue("set"), Description("Same Setting")]
		SameSetting,
		/// <summary>
		/// Is an alternative version
		/// </summary>
		[RealValue("alt"), Description("Alternative Version")]
		AlternativeVersion,
		/// <summary>
		/// Shares characters
		/// </summary>
		[RealValue("char"), Description("Shares Characters")]
		SharesCharacters,
		/// <summary>
		/// Is a side story
		/// </summary>
		[RealValue("side"), Description("Side Story")]
		SideStory,
		/// <summary>
		/// Is a parent story
		/// </summary>
		[RealValue("par"), Description("Parent Story")]
		ParentStory,
		/// <summary>
		/// Part of the same series
		/// </summary>
		[RealValue("ser"), Description("Same Series")]
		SameSeries,
		/// <summary>
		/// Fandisc
		/// </summary>
		[RealValue("fan")]
		Fandisc,
		/// <summary>
		/// Original Game
		/// </summary>
		[RealValue("orig"), Description("Original Game")]
		OriginalGame,
	}
}