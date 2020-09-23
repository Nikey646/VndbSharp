using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VndbSharp.Models.VisualNovel
{
	/// <summary>
	/// Staff Metadata
	/// </summary>
	public class StaffMetadata
	{
		private StaffMetadata() { }

		/// <summary>
		/// Staff ID
		/// </summary>
		[JsonProperty("sid")]
		public UInt32 StaffId { get; private set; }
		/// <summary>
		/// Alias ID
		/// </summary>
		[JsonProperty("aid")]
		public UInt32 AliasId { get; private set; }
		/// <summary>
		/// English Name
		/// </summary>
		public String Name { get; private set; }
		/// <summary>
		/// Japanese Name
		/// </summary>
		public String Kanji { get; private set; }
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
