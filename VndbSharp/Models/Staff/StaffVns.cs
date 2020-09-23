using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VndbSharp.Models.Staff
{
	/// <summary>
	/// Visual Novels that the Staff worked on
	/// </summary>
	public class StaffVns
    {
        /// <summary>
        /// Staff Id
        /// </summary>
        [JsonProperty("id")]
        public UInt32 StaffId { get; private set; }
        /// <summary>
        /// Alias Id
        /// </summary>
        [JsonProperty("aid")]
        public UInt32 AliasId { get; private set; }
        /// <summary>
        ///		The role they served as staff
        /// </summary>
        public String Role { get; private set; } // TODO: Convert to enum
        /// <summary>
        ///		Contains more info on their role as staff
        /// </summary>
        public String Note { get; private set; }
	}
}
