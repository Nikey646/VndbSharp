using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VndbSharp.Models.User
{
	/// <summary>
	/// User Labels
	/// </summary>
	public class UserLabels
	{
		/// <summary>
		/// User ID
		/// </summary>
		[JsonProperty("uid")]
		public UInt32 UserId { get; private set; }
		/// <summary>
		/// Label ID
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Label Name
		/// </summary>
		public String Label { get; private set; }
		/// <summary>
		/// Is Label private
		/// </summary>
		[JsonProperty("private")]
		public Boolean IsPrivate { get; private set; }
	}
}
