using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Character
{
    /// <summary>
    /// Base information about a specific character
    /// </summary>
    public class Character
    {
	    /// <summary>
	    /// Character's ID on Vndb
	    /// </summary>
	    public UInt32 Id { get; private set; }
	    /// <summary>
	    /// Character's Name
	    /// </summary>
	    public String Name { get; private set; }
		/// <summary>
		/// Character's Japanese/Original Name
		/// </summary>
		[JsonProperty("original")]
		public String OriginalName { get; private set; }
		/// <summary>
		/// Character's Gender
		/// </summary>
		public Gender? Gender { get; private set; }
		/// <summary>
		/// Actual Sex, if the gender is a spoiler
		/// </summary>
		public Gender? SpoilGender { get; private set; }
		/// <summary>
		/// Character's Gender
		/// </summary>
		[JsonProperty("bloodt")]
		public BloodType? BloodType { get; private set; }
		/// <summary>
		/// Character's Birthday
		/// </summary>
		public SimpleDate Birthday { get; private set; }
		/// <summary>
		/// Character's Aliases/Nicknames
		/// </summary>
		[IsCsv]
		public ReadOnlyCollection<String> Aliases { get; private set; }
		/// <summary>
		/// Description of the character
		/// </summary>
		public String Description { get; private set; }
		/// <summary>
		/// Character's age in years
		/// </summary>
		public Int64? Age { get; private set; }
	    /// <summary>
	    /// Url Image of the character
	    /// </summary>
	    public String Image { get; private set; }
	    /// <summary>
	    /// Properties of the character's image. This determines how violent/sexual it is
	    /// </summary>
	    [JsonProperty("image_flagging")]
	    public ImageRating ImageRating { get; private set; }
		/// <summary>
		///		Size in Centimeters
		/// </summary>
		public Int64? Bust { get; private set; }
		/// <summary>
		///		Size in Centimeters
		/// </summary>
		public Int64? Waist { get; private set; }
		/// <summary>
		///		Size in Centimeters
		/// </summary>
	    public Int64? Hip { get; private set; }
		/// <summary>
		///		Height in Centimeters
		/// </summary>
		public Int64? Height { get; private set; }
		/// <summary>
		///		Weight in Kilograms
		/// </summary>
	    public Int64? Weight { get; private set; }
		/// <summary>
		/// CupSize of the character
		/// </summary>
		[JsonProperty("cup_size")]
		public String CupSize { get; private set; }
	    /// <summary>
	    /// List of traits the character has
	    /// </summary>
	    public ReadOnlyCollection<TraitMetadata> Traits { get; private set; }
	    /// <summary>
	    /// List of Visual Novels linked to this character
	    /// </summary>
	    [JsonProperty("vns")]
	    public ReadOnlyCollection<VisualNovelMetadata> VisualNovels { get; private set; }
		/// <summary>
		/// List of voice actresses (staff) that voiced this character, per VN
		/// </summary>
		[JsonProperty("voiced")]
	    public ReadOnlyCollection<VoiceActorMetadata> VoiceActorMetadata { get; private set; }
		/// <summary>
		/// List of instances of this character (excluding the character entry itself)
		/// </summary>
		[JsonProperty("instances")]
		public  ReadOnlyCollection<CharacterInstances> CharacterInstances { get; private set; }
	}
}
