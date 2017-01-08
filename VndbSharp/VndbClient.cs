using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Enums;
using VndbSharp.Interfaces;
using VndbSharp.Structs.Models;
using VndbSharp.Structs.Models.Character;
using VndbSharp.Structs.Models.DatabaseStats;
using VndbSharp.Structs.Models.Producer;
using VndbSharp.Structs.Models.Release;
using VndbSharp.Structs.Models.User;
using VisualNovel = VndbSharp.Structs.Models.VisualNovel.VisualNovel;

namespace VndbSharp
{
	public class VndbClient : IDisposable
	{
		private Boolean _useTls;

		private Int32 _receiveBufferSize = 1024 * 4;
		private Int32 _sendBufferSize = 1024 * 4;

		private const Char EOTChar = (Char)0x04;

		private const String ApiDomain = "api.vndb.org";

		private const UInt16 ApiPort = 19534;
		private const UInt16 ApiTlsPort = 19535;

		protected String LastErrorJson;
		protected OmniError LastError;

		protected TcpClient Client;

		protected Stream Stream;

		protected Boolean LoggedIn;

		protected String Username;
		protected SecureString Password;

		public Int32 ReceiveBufferSize
		{
			get { return this.Client?.ReceiveBufferSize ?? this._receiveBufferSize; }
			set
			{
				if (this.Client != null)
					this.Client.ReceiveBufferSize = value;
				this._receiveBufferSize = value;
			}
		}

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

		public Boolean UseTls
		{
			get { return this._useTls; }
			set
			{
				if (!String.IsNullOrWhiteSpace(this.Username) || this.Password != null)
					throw new InvalidOperationException($"Cannot change {nameof(this.UseTls)} state while using a username / password.");

				this._useTls = value;
				this.LoggedIn = false;
			}
		}

        // TODO: Use HasMono property on TLS to warn about lack of encryption support
	    internal static Boolean HasMono { get; } = Type.GetType("Mono.Runtime") != null;

		public VndbClient()
		{ }

		public VndbClient(Boolean useTls)
		{
			this.UseTls = useTls;
		}

		/// <summary>
		///		This method is *not* secure on mono implementations. SecureString does *not* encrypt / decrypt as 01/2017
		/// 	https://github.com/mono/mono/blob/master/mcs/class/corlib/System.Security/SecureString.cs#L249-L264
		/// 
		/// 	This will also *force* a secure connection.
		/// </summary>
		public VndbClient(String username, SecureString password)
		{
			this.UseTls = true;
			this.Username = username;
			this.Password = password;
		}

		public async Task<RootObject<VisualNovel>> GetVisualNovelAsync(VndbFlags flags, IFilter filter, IRequestOptions options = null)
		{
			if (!await this.LoginAsync().ConfigureAwait(false))
				return null;

			var data = $"get vn {String.Join(",", this.FlagsToString(flags))} ({filter})";
			if (options != null)
				data = this.FormatOptions(data, options);

			Debug.WriteLine(data);

			await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
			var response = await this.GetResponseAsync().ConfigureAwait(false);

			var results = response.Split(new[] {' '}, 2);
			Debug.WriteLine(results[1]);

			if (results.Length == 2 && results[0] == "results")
				return JsonConvert.DeserializeObject<RootObject<VisualNovel>>(results[1]);

			this.SetLastError(results[1]);
			return null;
		}

        public async Task<DatabaseStats> GetDatabaseStats()
        {
            if (!await this.LoginAsync().ConfigureAwait(false))
                return null;

            var data = "dbstats";

            Debug.WriteLine(data);

            await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
            var response = await this.GetResponseAsync().ConfigureAwait(false);

            var results = response.Split(new[] { ' ' }, 2);
            Debug.WriteLine(results[1]);

            if (results.Length == 2 && results[0] == "dbstats")
                return JsonConvert.DeserializeObject<DatabaseStats>(results[1]);

            this.SetLastError(results[1]);
            return null;
        }

        public async Task<RootObject<Character>> GetCharacterAsync(VndbFlags flags, IFilter filter, IRequestOptions options = null)
		{
			if (!await this.LoginAsync().ConfigureAwait(false))
				return null;

			var data = $"get character {String.Join(",", this.FlagsToString(flags))} ({filter})";
			if (options != null)
				data = this.FormatOptions(data, options);

			Debug.WriteLine(data);

			await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
			var response = await this.GetResponseAsync().ConfigureAwait(false);

			var results = response.Split(new[] {' '}, 2);
			Debug.WriteLine(results[1]);

			if (results.Length == 2 && results[0] == "results")
				return JsonConvert.DeserializeObject<RootObject<Character>>(results[1]);
			
			this.SetLastError(results[1]);
			return null;
		}

	    public async Task<RootObject<Release>> GetReleaseAsync(VndbFlags flags, IFilter filter, IRequestOptions options = null)
	    {
            if (!await this.LoginAsync().ConfigureAwait(false))
                return null;

            var data = $"get release {String.Join(",", this.FlagsToString(flags))} ({filter})";
            if (options != null)
                data = this.FormatOptions(data, options);

            Debug.WriteLine(data);

            await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
            var response = await this.GetResponseAsync().ConfigureAwait(false);

            var results = response.Split(new[] { ' ' }, 2);
            Debug.WriteLine(results[1]);

            if (results.Length == 2 && results[0] == "results")
                return JsonConvert.DeserializeObject<RootObject<Release>>(results[1]);

            this.SetLastError(results[1]);
            return null;
        }

	    public async Task<RootObject<Producer>> GetProducerAsync(VndbFlags flags, IFilter filter, IRequestOptions options = null)
	    {
            if (!await this.LoginAsync().ConfigureAwait(false))
                return null;

            var data = $"get producer {String.Join(",", this.FlagsToString(flags))} ({filter})";
            if (options != null)
                data = this.FormatOptions(data, options);

            Debug.WriteLine(data);

            await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
            var response = await this.GetResponseAsync().ConfigureAwait(false);

            var results = response.Split(new[] { ' ' }, 2);
            Debug.WriteLine(results[1]);

            if (results.Length == 2 && results[0] == "results")
                return JsonConvert.DeserializeObject<RootObject<Producer>>(results[1]);

            this.SetLastError(results[1]);
            return null;
        }

	    public async Task<RootObject<User>> GetUserAsync(VndbFlags flags, IFilter filter, IRequestOptions options = null)
	    {
            if (!await this.LoginAsync().ConfigureAwait(false))
                return null;

            var data = $"get user {String.Join(",", this.FlagsToString(flags))} ({filter})";
            if (options != null)
                data = this.FormatOptions(data, options);

            Debug.WriteLine(data);

            await this.SendDataAsync(this.FormatRequest(data)).ConfigureAwait(false);
            var response = await this.GetResponseAsync().ConfigureAwait(false);

            var results = response.Split(new[] { ' ' }, 2);
            Debug.WriteLine(results[1]);

            if (results.Length == 2 && results[0] == "results")
                return JsonConvert.DeserializeObject<RootObject<User>>(results[1]);

            this.SetLastError(results[1]);
            return null;
        }

		public async Task<String> DoRawAsync(String command)
		{
			try
			{
				if (!await this.LoginAsync().ConfigureAwait(false))
					return this.GetLastErrorJson();

				await this.SendDataAsync(this.FormatRequest(command)).ConfigureAwait(false);
				var result = await this.GetResponseAsync().ConfigureAwait(true);
				return result;
			}
			catch (Exception crap)
			{
				return crap.ToString();
			}
		}

		public OmniError GetLastError() => this.LastError;

		public String GetLastErrorJson() => this.LastErrorJson;

		protected async Task<Boolean> LoginAsync()
		{
			if (this.Client?.Connected == true && this.LoggedIn)
				return true;

			this.InitializeClient();

			await this.Client.ConnectAsync(VndbClient.ApiDomain, this.UseTls ? VndbClient.ApiTlsPort : VndbClient.ApiPort)
				.ConfigureAwait(false);

			if (this.UseTls)
			{
				var stream = new SslStream(this.Client.GetStream());
				await stream.AuthenticateAsClientAsync(VndbClient.ApiDomain).ConfigureAwait(false);
				this.Stream = stream;
			}
			else
			{
				this.Stream = this.Client.GetStream();
			}

			// Create a login class that can have an optional Username / Password
			var login = new Login(this.Username, this.Password);
			await this.SendDataAsync(this.FormatRequest("login", login, false)).ConfigureAwait(false);
			// Dispose of the login class *asap*, to ensure the password remains in unmanaged memory for as little as possible
			login.Dispose();

			var response = await this.GetResponseAsync().ConfigureAwait(false);

			if (response == "ok")
			{
				this.LoggedIn = true;
				return true;
			}

			if (String.IsNullOrWhiteSpace(response))
				throw new InvalidOperationException("Response from Vndb was empty.");
			
			var results = response.Split(new[] { ' ' }, 2);

			if (results.Length != 2 || results[0] != "error")
				throw new InvalidOperationException($"Unexpected response. {response}");
			
			this.SetLastError(results[1]);
			return false;
		}

		protected void InitializeClient()
		{
			this.Dispose(true); // Clean up after ourselves!

			this.Client = new TcpClient
			{
				SendBufferSize = this._sendBufferSize,
				ReceiveBufferSize = this._receiveBufferSize,
			};
			this.LoggedIn = false;
		}

		#region .  Helper Methods  .

		protected async Task<String> GetResponseAsync()
		{
			this.LastError = null;
			var memory = new MemoryStream();
			var buffer = new Byte[this.ReceiveBufferSize];
			Int32 bytesRead;

			while ((bytesRead = await this.Stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
			{
				await memory.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
				if (buffer[bytesRead - 1] == VndbClient.EOTChar)
					break;
			}

			var result = this.GetString(memory.ToArray()).TrimEnd(VndbClient.EOTChar);
			memory.Dispose();
			return result;
		}

		protected async Task SendDataAsync(Byte[] data)
		{
			await this.Stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
		}

		protected void SetLastError(String json)
		{
			this.LastError = JsonConvert.DeserializeObject<OmniError>(json);
			this.LastErrorJson = json;
		}

		protected String FormatOptions(String request, IRequestOptions options)
			=> request + $" {JsonConvert.SerializeObject(options, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })}";

		protected Byte[] FormatRequest(String data)
		{
			return this.GetBytes($"{data}{VndbClient.EOTChar}");
		}

		protected Byte[] FormatRequest<T>(String method, T data, Boolean includeNull = true)
		{
			var json = JsonConvert.SerializeObject(data,
				new JsonSerializerSettings
				{
					NullValueHandling = includeNull 
						? NullValueHandling.Include 
						: NullValueHandling.Ignore
				});
			return this.FormatRequest($"{method} {json}");
		}

		protected Byte[] GetBytes(String data)
		{
			return Encoding.UTF8.GetBytes(data);
		}

		protected String GetString(Byte[] data)
		{
			return Encoding.UTF8.GetString(data);
		}

		protected IEnumerable<String> FlagsToString(Enum inputFlags)
		{
			var type = inputFlags.GetType();
			foreach (Enum value in Enum.GetValues(type))
			{
				var valueStr = value.ToString();
				if (!inputFlags.HasFlag(value) || valueStr == "None")
					continue;

				var fi = type.GetField(valueStr);
				var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
				if (attributes?.Length > 0)
					yield return attributes[0].Description;
				else yield return valueStr;
			}
		}

		#endregion

		#region .  IDisposable  .

		~VndbClient()
		{
			this.Dispose(false);
		}

		public void Dispose() => ((IDisposable)this).Dispose();

		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(Boolean disposing)
		{
			if (disposing)
			{
				this.Client?.Close();
				this.Client?.Dispose();
				this.Client = null;

				this.Stream?.Close();
				this.Stream?.Dispose();
				this.Stream = null;
			}
		}

		#endregion
	}
}
