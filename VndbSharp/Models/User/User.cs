using System;

namespace VndbSharp.Models.User
{
	/// <summary>
	/// User Information
	/// </summary>
	public class User
	{
		/// <summary>
		/// User Id
		/// </summary>
		public UInt32 Id { get; private set; }
		/// <summary>
		/// Username
		/// </summary>
		public String Username { get; private set; }
	}
}
