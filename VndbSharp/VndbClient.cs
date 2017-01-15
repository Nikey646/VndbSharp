using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VndbSharp.Enums;
using VndbSharp.Interfaces;
using VndbSharp.Structs.Models;
using VndbSharp.Structs.Models.Character;
using VndbSharp.Structs.Models.DatabaseStats;
using VndbSharp.Structs.Models.Dumps;
using VndbSharp.Structs.Models.Error;
using VndbSharp.Structs.Models.Producer;
using VndbSharp.Structs.Models.Release;
using VndbSharp.Structs.Models.User;
using VndbSharp.Structs.Models.VnList;
using VndbSharp.Structs.Models.Votelist;
using VndbSharp.Structs.Models.Wishlist;
using VisualNovel = VndbSharp.Structs.Models.VisualNovel.VisualNovel;

namespace VndbSharp
{
	public class VndbClient : IDisposable
	{
		private Boolean _useTls;

		private Int32 _receiveBufferSize = 1024 * 4;
		private Int32 _sendBufferSize = 1024 * 4;

		protected String LastErrorJson;
		protected IVndbError LastError;

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
		///		If using .Net Core or Mono, please read https://github.com/Nikey646/VndbSharp/wiki/Mono-and-.Net-Core#securestring--username--password-logins
		/// 
		/// 	This will also *force* a secure connection.
		/// </summary>
		public VndbClient(String username, SecureString password)
		{
			this.UseTls = true;
			this.Username = username;
			this.Password = password;
		}

		public async Task<DatabaseStats> GetDatabaseStatsAsync()
			=> await this.SendRequestInternalAsync<DatabaseStats>(Constants.DbStatsCommand).ConfigureAwait(false);

		public async Task<RootObject<VisualNovel>> GetVisualNovelAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<VisualNovel>>(Constants.GetVisualNovelCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<Release>> GetReleaseAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<Release>>(Constants.GetReleaseCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<Producer>> GetProducerAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<Producer>>(Constants.GetProducerCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<Character>> GetCharacterAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<Character>>(Constants.GetCharacterCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<User>> GetUserAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<User>>(Constants.GetUserCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<Votelist>> GetVotelistAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<Votelist>>(Constants.GetVotelistCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<VnList>> GetVnListAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<VnList>>(Constants.GetVisualNovelListCommand, flags, filters, options)
				.ConfigureAwait(false);

		public async Task<RootObject<Wishlist>> GetWishlistAsync(VndbFlags flags, IFilter filters,
			IRequestOptions options = null)
			=> await this.SendRequestInternalAsync<RootObject<Wishlist>>(Constants.GetWishlistCommand, flags, filters, options)
				.ConfigureAwait(false);
		
		// Should we internally rate limit the usage of this method?
		// Hell, should this be moved to a separate, static class called VndbUtils?
		public async Task<IEnumerable<Tag>> GetTagDumpAsync()
			=> await this.GetDumpAsync<IEnumerable<Tag>>(Constants.TagsDump).ConfigureAwait(false);

		public async Task<IEnumerable<Trait>> GetTraitDumpAsync()
			=> await this.GetDumpAsync<IEnumerable<Trait>>(Constants.TraitsDump).ConfigureAwait(false);

        public async Task<Boolean> SetVotelistAsync(UInt32 id, Byte? vote)
            => await this.SendRequestInternalAsync(Constants.SetVotelistCommand, id, vote.HasValue ? new { vote } : null)
                .ConfigureAwait(false);

        public async Task<Boolean> SetVisualNovelListAsync(UInt32 id, Byte? status, String notes)
        {
            //TODO: Fix these ugly if statements. Hopefully into a single line if you can.
            if (status != null && notes != null)
            {
                await this.SendRequestInternalAsync(Constants.SetVisualNovelListCommand, id, new { status, notes })
                    .ConfigureAwait(false);
            }
            if (notes == null)
            {
                await this.SendRequestInternalAsync(Constants.SetVisualNovelListCommand, id, new { status })
                    .ConfigureAwait(false);
            }
            if (status == null)
            {
                await this.SendRequestInternalAsync(Constants.SetVisualNovelListCommand, id, new { notes })
                    .ConfigureAwait(false);
            }
            return false;
        }

        public async Task<Boolean> SetWishlistAsync(UInt32 id, Byte? priority)
            => await this.SendRequestInternalAsync(Constants.SetWishlistCommand, id, priority.HasValue ? new { priority } : null)
                .ConfigureAwait(false);

        public async Task<String> DoRawAsync(String command)
		{
			try
			{
				if (!await this.LoginAsync().ConfigureAwait(false))
					return this.GetLastErrorJson();

				await this.SendDataAsync(this.FormatRequest(command)).ConfigureAwait(false);
				return await this.GetResponseAsync().ConfigureAwait(true);
			}
			catch (Exception crap)
			{
				return crap.ToString();
			}
		}

		public IVndbError GetLastError()
			=> this.LastError;

		public String GetLastErrorJson()
			=> this.LastErrorJson;
		
		protected async Task<Boolean> LoginAsync()
		{
			if (this.Client?.Connected == true && this.LoggedIn)
				return true;

			this.InitializeClient();

			await this.Client.ConnectAsync(Constants.ApiDomain, this.UseTls ? Constants.ApiPortTls : Constants.ApiPort)
				.ConfigureAwait(false);

			if (this.UseTls)
			{
				var stream = new SslStream(this.Client.GetStream());
				await stream.AuthenticateAsClientAsync(Constants.ApiDomain).ConfigureAwait(false);
				this.Stream = stream;
			}
			else
			{
				this.Stream = this.Client.GetStream();
			}

			// Create a login class that can have an optional Username / Password
			var login = new Login(this.Username, this.Password);
			await this.SendDataAsync(this.FormatRequest(Constants.LoginCommand, login, false)).ConfigureAwait(false);
			// Dispose of the login class *asap*, to ensure the password remains in unmanaged memory for as little as possible
			login.Dispose();

			var response = await this.GetResponseAsync().ConfigureAwait(false);

			if (response == Constants.Ok)
			{
				this.LoggedIn = true;
				return true;
			}

			if (String.IsNullOrWhiteSpace(response)) // Do not provide the full request data here. Contains the password in plain text.
				throw new UnexpectedResponseException("login", response);

			var results = response.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
			if (results.Length != 2 || results[0] != Constants.Error) // Do not provide the full request data here. Contains the password in plain text.
				throw new UnexpectedResponseException("login", response);

			this.SetLastError(results[1]);
			return false;
		}

		protected void InitializeClient()
		{
			this.Dispose(true); // Clean up after ourselves!

			this.Client = new TcpClient
			{
				SendBufferSize = this.SendBufferSize,
				ReceiveBufferSize = this.ReceiveBufferSize,
			};
			this.LoggedIn = false;
		}

		#region .  Helper Methods  .
		
		// for DbStats and other similar / new commands
		protected async Task<T> SendRequestInternalAsync<T>(String method)
			where T : class
			=> await this.SendRequestInternalAsync<T>(this.FormatRequest(method)).ConfigureAwait(false);

		// for get comands
		protected async Task<T> SendRequestInternalAsync<T>(String method, VndbFlags flags, IFilter filters,
			IRequestOptions options) where T : class
		{
			// Construct the request EG: "get vn basic,details (id=17) {"page":1}"
			var requestData = this.FormatRequest($"{method} {String.Join(",", this.FlagsToString(flags))} ({filters})", options, false);
			return await this.SendRequestInternalAsync<T>(requestData).ConfigureAwait(false);
		}

		// generic get code
		protected async Task<T> SendRequestInternalAsync<T>(Byte[] requestData)
			where T : class
		{
			// Ensure we are logged in
			if (!await this.LoginAsync().ConfigureAwait(false))
				return null;

			await this.SendDataAsync(requestData).ConfigureAwait(false);
			var response = await this.GetResponseAsync().ConfigureAwait(false);

			// Ensure we only split on the first space
			var result = response.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
			// TODO: Make a JsonContractResolver for the models, to remove [JsonProperty(...)] spam
			if (result.Length == 2 && result[0] == Constants.Results || result[0] == Constants.DbStats) // wai you do this, dbstats?
				return JsonConvert.DeserializeObject<T>(result[1]);

			// This is a response we don't know how to handle, since we only expect error {json} and results {json} / dbstats {json}
			if (result.Length != 2 || result[0] != Constants.Error)
				throw new UnexpectedResponseException(this.GetString(requestData), response);

			this.SetLastError(result[1]);
			return null; // A null return indicates an error.
		}

		// for set commands
		protected async Task<Boolean> SendRequestInternalAsync(String method, UInt32 id, Object data)
		{
			// Ensure we are logged in
			if (!await this.LoginAsync().ConfigureAwait(false))
				return false;

			// Construct the request EG: "set votelist 1 {"vote": 100}" or "set votelist 1" when data is null
			var requestData = this.FormatRequest($"{method} {id}", data, false);

			await this.SendDataAsync(requestData).ConfigureAwait(false);
			var response = await this.GetResponseAsync().ConfigureAwait(false);

			if (response == Constants.Ok)
				return true;

			// Ensure we only split on the first space
			var result = response.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

			// This is a response we don't know how to handle, since we only expect error {json} and ok
			if (result.Length != 2 || result[0] != Constants.Error)
				throw new UnexpectedResponseException(this.GetString(requestData), response);

			this.SetLastError(result[1]);
			return false;
		}

		protected async Task<T> GetDumpAsync<T>(String dumpUrl) where T : class
		{
			var request = (HttpWebRequest) WebRequest.Create(dumpUrl);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.Method = WebRequestMethods.Http.Get;
			request.Timeout = 5000;
			request.Proxy = null;
			request.UserAgent = "VndbSharp (v0.1)"; // TODO: Make this non-static

			HttpWebResponse response = null;
			Stream responseStream = null;
			MemoryStream responseContent = null;

			try
			{
				response = (HttpWebResponse) await request.GetResponseAsync().ConfigureAwait(false);
				responseStream = response.GetResponseStream();
				responseContent = new MemoryStream();

				if (responseStream == null)
					return null;

//				var headers = response.Headers; // Not used
				var buffer = new Byte[4096]; // Use the receive buffer size here maybe?
				var encoding = String.IsNullOrWhiteSpace(response.CharacterSet) 
					? Encoding.UTF8 
					: Encoding.GetEncoding(response.CharacterSet);


				Int32 bytesRead;
				while ((bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
					await responseContent.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);

				// Reset out position and bytesRead
				responseContent.Position = bytesRead = 0;
				// Reset the buffer as well
				buffer = new Byte[4096];
				using (var gzipStream = new GZipStream(responseContent, CompressionMode.Decompress))
				using (var finalStream = new MemoryStream())
				{
					while ((bytesRead = await gzipStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
						await finalStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
					
					return JsonConvert.DeserializeObject<T>(encoding.GetString(finalStream.ToArray()));
				}
			}
			catch (WebException) // Catch bad requests from vndb
			{
				return null;
			}
			finally
			{
				response?.Dispose();
				responseStream?.Dispose();
				responseContent?.Dispose();
			}
		}

		protected async Task<String> GetResponseAsync()
		{
			this.LastError = null;
			this.LastErrorJson = String.Empty;
			var memory = new MemoryStream();
			var buffer = new Byte[this.ReceiveBufferSize];
			Int32 bytesRead;

			while ((bytesRead = await this.Stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
			{
				await memory.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
				if (buffer[bytesRead - 1] == Constants.EotChar)
					break;
			}

			var result = this.GetString(memory.ToArray()).TrimEnd(Constants.EotChar);
			memory.Dispose();
			return result;
		}

		protected async Task SendDataAsync(Byte[] data)
			=> await this.Stream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);

		protected void SetLastError(String json)
		{
			this.LastError = null;
			this.LastErrorJson = json;

			var response = JObject.Parse(json);
			JToken typeToken;
			if (!response.TryGetValue("id", StringComparison.OrdinalIgnoreCase, out typeToken))
				return;
			
			switch (typeToken.Value<String>())
			{
				case "parse":
					this.LastError = BasicError.Build<ParseError>(response);
					break;
				case "settype":
					this.LastError = BasicError.Build<SetTypeError>(response);
					break;
				case "needlogin":
					this.LastError = BasicError.Build<LoginRequiredError>(response);
					break;
				case "auth":
					this.LastError = BasicError.Build<BadAuthenticiationError>(response);
					break;
				case "loggedind":
					this.LastError = BasicError.Build<LoggedInError>(response);
					break;
				case "gettype":
					this.LastError = BasicError.Build<GetTypeError>(response);
					break;
				case "missing":
					this.LastError = BasicError.Build<MissingError>(response);
					break;
				case "badarg":
					this.LastError = BasicError.Build<BadArgumentError>(response);
					break;
				case "throttled":
					this.LastError = BasicError.Build<ThrottledError>(response);
					break;
				case "getinfo":
					this.LastError = BasicError.Build<GetInfoError>(response);
					break;
				case "filter":
					this.LastError = BasicError.Build<InvalidFilterError>(response);
					break;
				default:
					this.LastError = null;
					break;
			}
		}

		protected Byte[] FormatRequest(String data)
			=> this.GetBytes($"{data}{Constants.EotChar}");

		protected Byte[] FormatRequest<T>(String prefix, T data, Boolean includeNull = true)
		{
			// If null was passed for data, and we don't want to include nulls, just return the prefix
			if (data == null && !includeNull)
				return this.FormatRequest(prefix);

			var json = JsonConvert.SerializeObject(data,
				new JsonSerializerSettings
				{
					NullValueHandling = includeNull 
						? NullValueHandling.Include 
						: NullValueHandling.Ignore
				});

			return this.FormatRequest($"{prefix} {json}");
		}

		protected Byte[] GetBytes(String data)
			=> Encoding.UTF8.GetBytes(data);

		protected String GetString(Byte[] data)
			=> Encoding.UTF8.GetString(data);

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

		public void Dispose()
			=> ((IDisposable)this).Dispose();

		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(Boolean disposing)
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
