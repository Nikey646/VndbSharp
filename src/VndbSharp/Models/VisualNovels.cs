using System;
using System.Collections.Generic;
using VndbSharp.Models.Enums;

namespace VndbSharp.Models
{
    public record VisualNovel(UInt32 Id, String EnglishTitle, String OriginalTitle, SimpleDate Released,
        IReadOnlyCollection<String> Languages, IReadOnlyCollection<String> InitialReleaseLanguages,
        IReadOnlyCollection<String> Platforms, IReadOnlyCollection<String> Aliases, VisualNovelLength? Length,
        String Description, VisualNovelLinks VisualNovelLinks, String Image, ImageRating CoverImageRating,
        IReadOnlyCollection<AnimeMetadata> Anime, IReadOnlyCollection<VisualNovelRelation> Relations,
        IReadOnlyCollection<TagMetadata> Tags, Single Popularity, Single Rating,
        IReadOnlyCollection<ScreenshotMetadata> Screenshots, IReadOnlyCollection<StaffMetadata> Staff);

    public record VisualNovelRelation(Int32 Id, RelationType Type, String EnglishTitle, String OriginalTitle,
        Boolean IsOfficial);

    public record VisualNovelLinks(String Encubed, String Renai);

    public record AnimeMetadata(Int32 AniDbId, Int32 AnimeNewsNetworkId, String RomajiTitle, String KanjiTitle,
        SimpleDate AiringYear, String Type);

    public record TagMetadata(Int32 Id, Single Score, SpoilerLevel SpoilerLevel);

    // TODO: ReleaseId? Why is it a String?
    public record ScreenshotMetadata(String Url, String ReleaseId, ImageRating ImageRating, Int32 Height, Int32 Width);

    public record StaffMetadata(Int32 StaffId, Int32 AliasId, String EnglishName, String OriginalName, String Role,
        String Note);
}
