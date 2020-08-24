using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Staff
{
    /// <summary>
    /// List of Staff Links
    /// </summary>
    public class StaffLinks: CommonLinks
    {
		/// <summary>
		/// Official Homepage
		/// </summary>
		public String Homepage { get; private set; }
        /// <summary>
        /// Twitter page
        /// </summary>
        public String Twitter { get; private set; }
        /// <summary>
        /// AniDb page
        /// </summary>
        public String AniDb { get; private set; }
		/// <summary>
		/// Pixiv page
		/// </summary>
		public Int32? Pixiv { get; private set; }
    }
}
