using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VndbSharp.Models
{
	/// <summary>
	/// Class for defining the version of the API
	/// </summary>
	public class Version
	{
		/// <summary>
		/// Date of the API Version
		/// </summary>
		public DateTime ApiDate { get; set; }
		/// <summary>
		/// Completion status of VndbSharp's implementation of the Vndb API
		/// </summary>
		public VersionStatus ApiStatus { get; set; }
	}

	/// <summary>
	/// Enum defining completion status levels
	/// </summary>
	public enum VersionStatus
	{
		Incomplete,
		Complete
	}
}
