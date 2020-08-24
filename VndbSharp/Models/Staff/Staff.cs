using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using VndbSharp.Attributes;
using VndbSharp.Json.Converters;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Staff
{
    /// <summary>
    /// Staff Information
    /// </summary>
    public class Staff
    {
		/// <summary>
		/// Staff Id
		/// </summary>
		public UInt32 Id { get; private set; }
        /// <summary>
        /// Staff Name
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// Staff Original Name
        /// </summary>
        [JsonProperty("original")]
        public String OriginalName { get; private set; }
        /// <summary>
        /// Staff Gender
        /// </summary>
        public Gender? Gender { get; private set; }
		/// <summary>
		/// Primary Language
		/// </summary>
		public String Language { get; private set; }
        /// <summary>
        /// Related Staff links
        /// </summary>
        [JsonProperty("links")]
		public StaffLinks StaffLinks { get; private set; }
        /// <summary>
        /// Staff Description
        /// </summary>
        public String Description { get; private set; }
        /// <summary>
        /// List of names and aliases
        /// </summary>
        public ReadOnlyCollection<StaffAliases> Aliases { get; private set; }
		/// <summary>
		/// Main alias
		/// </summary>
		[JsonProperty("main_alias")]
        public String MainAlias { get; private set; }
		/// <summary>
		/// Vns that the staff member has worked on
		/// </summary>
		public StaffVns[] Vns { get; private set; }
		/// <summary>
		/// List of Characters this staff has voiced
		/// </summary>
		public StaffVoiced[] Voiced { get; private set; }
	}
}
