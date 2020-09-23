using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VndbSharp.Models.Staff
{
    /// <summary>
    /// Characters the staff has voiced
    /// </summary>
    public class StaffVoiced
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
        /// Character Id
        /// </summary>
        [JsonProperty("cid")]
        public UInt32 CharacterId { get; private set; }
		/// <summary>
		/// Notes
		/// </summary>
		public string Note { get; private set; }
	}
}
