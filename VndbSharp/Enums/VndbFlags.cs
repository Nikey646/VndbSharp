using System;
using System.ComponentModel;

namespace VndbSharp.Enums
{
	[Flags]
	public enum VndbFlags
	{
		None = 0,
		[Description("basic")]
		Basic = 1 << 0,
		[Description("details")]
		Details = 1 << 1,
		[Description("anime")]
		Anime = 1 << 2,
		[Description("relations")]
		Relations = 1 << 3,
		[Description("tags")]
		Tags = 1 << 4,
		[Description("stats")]
		Stats = 1 << 5,
		[Description("screens")]
		Screens = 1 << 6,
		[Description("vns")]
		VisualNovels = 1 << 7,
		[Description("producers")]
		Producers = 1 << 8,
		[Description("meas")]
		Measurements = 1 << 9,
		[Description("traits")]
		Traits = 1 << 10,
        [Description("vn")]
        VisualNovel = 1 << 11,
    }
}

