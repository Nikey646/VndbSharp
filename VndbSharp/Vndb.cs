﻿using System;
using System.IO;
using System.Net.Sockets;

using System.Security;

using System.Threading;
using System.Threading.Tasks;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;
using VndbSharp.Models;

namespace VndbSharp
{
	/// <summary>
	///		The main class to issue get and set commands to the Vndb API with
	/// </summary>
	public partial class Vndb
	{
		//Version in Year.Month.Day
		private static readonly Version ApiVer = new Version(2020,07,09);
		private static VersionStatus ApiStatus = VersionStatus.Incomplete;
		/// <summary>
		///		Creates a new instance of the Vndb class, to issue commands to the API
		/// </summary>
		/// <param name="useTls">Should the connection to the API be secure</param>
		public Vndb(Boolean useTls = false)
		{
			this.UseTls = useTls;
		}



		public Vndb(String username, SecureString password)
		{
			if (AllowInsecure())
			{
				this.UseTls = true;
				this.Username = username;
				this.Password = password;
				this.Password.MakeReadOnly();
			}
			
		}


		/// <summary>
		///		Issues the provided command to the Vndb API
		/// </summary>
		/// <param name="command">The command you want to issue</param>
		/// <returns>The raw result of the command unparsed, or the String representation of the exception that occured</returns>
		public async Task<String> DoRawAsync(String command)
		{
			try
			{
				if (!await this.LoginAsync().ConfigureAwait(false))
					return this.GetLastErrorJson();

				this.RenewCts();
				await this.SendDataAsync(this.FormatRequest(command), this.CancellationTokenSource.Token)
					.TimeoutAfter(this.SendTimeout)
					.ConfigureAwait(false);
				return await this.GetResponseAsync(this.CancellationTokenSource.Token)
					.TimeoutAfter(this.ReceiveTimeout)
					.ConfigureAwait(false);
			}
			catch (Exception crap)
			{
				return crap.ToString();
			}
		}
		/// <summary>
		/// Returns the latest version of the Vndb API that VndbSharp supports.
		/// This returns a Version object with fields for the API Date, and the completion status of VndbSharp toward that API version
		/// If the completion status is incomplete, there may be features from the Vndb API that have not been implemented yet.
		/// </summary>
		/// <returns></returns>
		public static Models.ApiVersionInfo GetApiVersion()
		{
			var version = new ApiVersionInfo(){ApiVersion = ApiVer, ApiStatus = ApiStatus};
			return version;
		}

		/// <summary>
		/// Checks if VndbSharp supports a specified version
		/// </summary>
		/// <param name="ver"></param>
		/// <returns></returns>
		public static Boolean IsVndbVersionSupported(Version ver)
		{
			return ver > ApiVer || ver == ApiVer && ApiStatus == VersionStatus.Complete;
		}

		/// <summary>
		/// Checks for the environment variable 'ALLOW_UNSECURE_SECURESTRING'
		/// If it is found, allows using the insecure SecureString
		/// </summary>
		/// <returns></returns>
		public static bool AllowInsecure()
		{
			var value = Environment.GetEnvironmentVariable("ALLOW_UNSECURE_SECURESTRING");
			if (!String.IsNullOrEmpty(value))
			{
#warning VndbSharp Unsecure SecureStrings are allowed. Make sure that you are aware of the risks of setting this ENV. https://git.io/JU5mt
				return true;
			}
			else
			{
				string notice =
					"SecureString is not secure on non-Windows OSes when using .Net Core, or at all in Mono." +
					"By setting the 'ALLOW_UNSECURE_SECURESTRING' environment variable, and/or this warning, you acknowledge the risks and will not make PRs or Issues regarding this unless the situation in .Net Core / Mono changes. \n" +
					"To read more above the above messages, check out https://github.com/Nikey646/VndbSharp/wiki/Mono-and-.Net-Core#securestring--username--password-logins \n" +
					"If that link is down, do some research on SecureString implementations in .Net Core, to see if they encrypt the data in memory on Unix.";
				throw new NotSupportedException(notice);
			}
		}

		#region .  Public Properties  .

		/// <inheritdoc cref="TcpClient.SendBufferSize"/>
		public Int32 SendBufferSize
		{
			get { return this.Client?.SendBufferSize ?? this._sendBufferSize; }
			set
			{
				if (this.Client != null)
					this.Client.SendBufferSize = value;
				this._sendBufferSize = value;
			}
		}

		/// <inheritdoc cref="TcpClient.ReceiveBufferSize"/>
		public Int32 ReceiveBufferSize
		{
			get { return this.Client?.ReceiveBufferSize ?? this._receiveBufferSize; }
			set
			{
				if (this.Client != null)
					this.Client.ReceiveBufferSize = value;
				this._sendBufferSize = value;
			}
		}

		/// <inheritdoc cref="TcpClient.SendTimeout"/>
		public TimeSpan SendTimeout
		{
			get { return this._sendTimeout; }
			set
			{
				if (this.Client != null)
					this.Client.SendTimeout = (Int32) value.TotalMilliseconds;
				this._sendTimeout = value;
			}
		}

		/// <inheritdoc cref="TcpClient.ReceiveTimeout"/>
		public TimeSpan ReceiveTimeout
		{
			get { return this._receiveTimeout; }
			set
			{
				if (this.Client != null)
					this.Client.ReceiveTimeout = (Int32) value.TotalMilliseconds;
				this._receiveTimeout = value;
			}
		}

		/// <summary>
		///		Should the Connection to the Vndb API be done over a secure stream
		/// </summary>
		/// <exception cref="InvalidOperationException">When trying to change UseTls while logged in.</exception>
		public Boolean UseTls
		{
			get { return this._useTls; }
			set
			{
				//				if (!this.Username.IsEmpty() || this.Password != null)
				//					throw new InvalidOperationException($"Cannont change {nameof(this.UseTls)} state while using a username / password.");

				this._useTls = value;
				this.LoggedIn = false;
			}
		}

		/// <summary>
		///		Sets whether <see cref="VndbFlags"/> should be checked before being sent
		/// </summary>
		public Boolean CheckFlags { get; set; } = true;


		/// <summary>
		///		Indicates if a User is Logged in or not
		/// </summary>
		public Boolean IsUserAuthenticated
		{
			get
			{
				if (AllowInsecure())
				{
					return this.Password != null && this.Stream != null;
				}
				else
				{
					return false;
				}
			}
		}


		#endregion

		#region .  Protected Fields  .

		/// <summary>
		///		Indicates if the instance has logged in yet or not
		/// </summary>
		protected Boolean LoggedIn;

		/// <summary>
		///		The <see cref="CancellationToken"/> Source for all Async Tasks.
		/// </summary>
		protected CancellationTokenSource CancellationTokenSource;

		/// <summary>
		///		The last error that occured will be stored here until another command is sent
		/// </summary>
		protected IVndbError LastError;

		//		/// <summary>
		//		///		The users password, if provided
		//		/// </summary>
		//		protected SecureString Password;

		/// <summary>
		///		The Connections Stream, for Reading and Writing
		/// </summary>
		protected Stream Stream;

		/// <summary>
		///		The raw json of the last error.
		/// </summary>
		protected String LastErrorJson;

		/// <summary>
		///		The users username, if provided
		/// </summary>
		protected String Username;

		/// <summary>
		///		The users password, as a secure string
		/// </summary>
		protected SecureString Password;

		/// <summary>
		///		The Connections Client
		/// </summary>
		protected TcpClient Client;

		#endregion

		#region .  Backing Fields  .

		private Boolean _useTls = false;

		private Int32 _sendBufferSize = 4096;
		private Int32 _receiveBufferSize = 4096;

		private TimeSpan _sendTimeout = TimeSpan.FromSeconds(30);
		private TimeSpan _receiveTimeout = TimeSpan.FromSeconds(30);

		private Action<String, VndbFlags, VndbFlags> _invalidFlags;

		#endregion
	}
}
