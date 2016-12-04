using System.ComponentModel;

namespace VndbSharp.Enums.VisualNovel 
{
	public enum Relation
	{
		Sequel,
		Prequel,
		[Description("Same Setting")]
		SameSetting,
		[Description("Alternative Version")]
		AlternativeVersion,
		[Description("Shares Characters")]
		SharesCharacters,
		[Description("Side Story")]
		SideStory,
		[Description("Parent Story")]
		ParentStory,
		[Description("SAme Series")]
		SameSeries,
		Fandisc,
		[Description("Original Game")]
		OriginalGame,
	}
}
