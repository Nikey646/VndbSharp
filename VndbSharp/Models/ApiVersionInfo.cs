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
	public class ApiVersionInfo
	{
		/// <summary>
		/// Date of the API Version
		/// </summary>
		public Version ApiVersion { get; set; }
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
		/// <summary>
		/// API implementation is currently incomplete, or missing some parts
		/// </summary>
		Incomplete,
		/// <summary>
		/// API implementation has been completed
		/// </summary>
		Complete
	}
}
