using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VndbSharp.Models.Staff
{
    /// <summary>
    /// Staff Aliases
    /// </summary>
    public class StaffAliases
    {
		internal StaffAliases(JArray array)
		{
			this.Id = array[0].Value<UInt32>();
			this.Name = array[1].Value<String>();
			this.OriginalName = array[2].Value<string>();
		}
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
	}
}
