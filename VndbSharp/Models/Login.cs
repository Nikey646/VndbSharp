using System;

using System.Security;

using Newtonsoft.Json;

namespace VndbSharp.Models
{
	internal class Login
	{
		public Login()
		{
			this.ClientName = VndbUtils.ClientName;
			this.ClientVersion = VndbUtils.ClientVersion;
		}

		public Login(String username, SecureString password) : this()
		{
			if (Vndb.AllowInsecure())
			{
				this.Username = username;
				this.Password = password;
			}
		}

		[JsonProperty("password")]
		public SecureString Password { get; set; }

		[JsonProperty("username")]
		public String Username { get; set; }


		[JsonProperty("protocol")]
		public UInt32 ProtocolVersion = 1;

		[JsonProperty("client")]
		public String ClientName;

		[JsonProperty("clientver")]
		public String ClientVersion;
	}
}
