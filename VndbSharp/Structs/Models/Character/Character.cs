using System;
using Newtonsoft.Json;
using VndbSharp.Converters;
using VndbSharp.Converters.Character;
using VndbSharp.Enums.Character;

namespace VndbSharp.Structs.Models.Character
{
	public class Character
	{
		[JsonProperty("id")]
		public Int64 Id;

		[JsonProperty("name")]
		public String Name;

		[JsonProperty("original")]
		public String Original;

		[JsonProperty("gender")]
		public Gender Gender;

		[JsonProperty("bloodt")]
		public BloodType BloodType;

		[JsonProperty("birthday"), JsonConverter(typeof(BirthdayConverter))]
		public DateTime Birthday;

		[JsonProperty("aliases"), JsonConverter(typeof(AliasesConverter))]
		public String[] Aliases;

		[JsonProperty("description")]
		public String Description;

		[JsonProperty("image")]
		public String Image;

		/// <summary>
		///		Size in Centimeters
		/// </summary>
		[JsonProperty("bust")]
		public Int64? Bust;

		/// <summary>
		///		Size in Centimeters
		/// </summary>
		[JsonProperty("waist")]
		public Int64? Waist;

		/// <summary>
		///		Size in Centimeters
		/// </summary>
		[JsonProperty("hip")]
		public Int64? Hip;

		/// <summary>
		///		Height in Centimeters
		/// </summary>
		[JsonProperty("height")]
		public Int64? Height;

		/// <summary>
		///		Weight in Kilograms
		/// </summary>
		[JsonProperty("weight")]
		public Int64? Weight;

		[JsonProperty("traits")]
		public Traits[] Traits;

		[JsonProperty("vns")]
		public VisualNovel[] VisualNovels;
	}
}
