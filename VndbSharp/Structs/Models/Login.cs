using System;
using System.Runtime.InteropServices;
using System.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VndbSharp.Structs.Models
{
	internal class Login : IDisposable
	{
		[JsonProperty("client")]
		public String ClientName = "VndbSharp";
		[JsonProperty("protocol")]
		public UInt32 ProtocolVersion = 1;
		[JsonProperty("clientver"), JsonConverter(typeof(VersionConverter))]
		public Version ClientVersion = new Version(0, 1);
		[JsonProperty("username")]
		public String Username = null;
		[JsonProperty("password")]
		public String Password = null;

		public Login(String username, SecureString password)
		{
			if (String.IsNullOrWhiteSpace(username) || password == null)
				return;

			this.Username = username;
			this.Password = this.MakeUnsecureString(password);
		}

		private String MakeUnsecureString(SecureString secureString)
		{
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}

		public void Dispose()
		{
			this.Password = String.Empty;
		}
	}
}
