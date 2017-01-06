using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Enums;
using VndbSharp.Filters.Conditionals;
using VndbSharp.Interfaces;
using VndbSharp.Structs.Models;
using VndbSharp.Structs.Models.Character;
using VndbSharp.Structs.Models.DatabaseStats;
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
				this._useTls = value;
				this.LoggedIn = false;
			}
		}

		public VndbClient()
		{ }

		public VndbClient(Boolean useTls)
		{
			this.UseTls = useTls;
		}

	    public async Task<DatabaseStats> GetDatabaseStats()
	    {
            //doesn't use root object because it doesn't contain items, more,.....
            await this.Login();

            var data = "dbstats";
            //Debug.WriteLine(data);

            await this.SendData(this.FormatRequest(data));
            var response = await this.GetResponse();

            var results = response.Split(new[] { ' ' }, 2);
            //Debug.WriteLine(results[1]);

            if (results.Length == 2 && results[0] == "dbstats")
                return JsonConvert.DeserializeObject<DatabaseStats>(results[1]);

            this.SetLastError(results[1]);
            return null;
        }

		public async Task<RootObject<VisualNovel>> GetVisualNovel(VndbFlags flags, IFilter filter, IRequestOptions options = null)
		{
			await this.Login();

			var data = $"get vn {String.Join(",", this.FlagsToString(flags))} ({filter})";
			if (options != null)
				data += $" {JsonConvert.SerializeObject(options, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore})}";

			Debug.WriteLine(data);

			await this.SendData(this.FormatRequest(data));
			var response = await this.GetResponse();

			var results = response.Split(new[] {' '}, 2);
			Debug.WriteLine(results[1]);

			if (results.Length == 2 && results[0] == "results")
				return JsonConvert.DeserializeObject<RootObject<VisualNovel>>(results[1]);

			this.SetLastError(results[1]);
			return null;
		}

		public async Task<RootObject<Character>> GetCharacter(VndbFlags flags, IFilter filter, IRequestOptions options = null)
		{
			await this.Login();

			var data = $"get character {String.Join(",", this.FlagsToString(flags))} ({filter})";
			if (options != null)
				data += $" {JsonConvert.SerializeObject(options, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })}";

			Debug.WriteLine(data);

			await this.SendData(this.FormatRequest(data));
			var response = await this.GetResponse();

			var results = response.Split(new[] {' '}, 2);
			Debug.WriteLine(results[1]);

			if (results.Length == 2 && results[0] == "results")
				return JsonConvert.DeserializeObject<RootObject<Character>>(results[1]);
			
			this.SetLastError(results[1]);
			return null;
		}

		public OmniError GetLastError() => this.LastError;

		public String GetLastErrorJson() => this.LastErrorJson;

		protected async Task Login()
		{
			if (this.Client?.Connected == true && this.LoggedIn)
				return;

			this.InitializeClient();

			// Use a dynamic object to reduce model clutter
			var loginRequest = new
			{
				protocol = 1,
				clientver = 0.1,
				client = "VndbClient",
			};

			await this.Client.ConnectAsync(VndbClient.ApiDomain, this.UseTls ? VndbClient.ApiTlsPort : VndbClient.ApiPort);

			if (this.UseTls)
			{
				var stream = new SslStream(this.Client.GetStream());
				await stream.AuthenticateAsClientAsync(VndbClient.ApiDomain);
				this.Stream = stream;
			}
			else
			{
				this.Stream = this.Client.GetStream();
			}

			await this.SendData(this.FormatRequest("login", loginRequest));
			var response = await this.GetResponse();

			if (response != "ok")
				throw new InvalidOperationException("Unable to login");
			this.LoggedIn = true;

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

		protected async Task<String> GetResponse()
		{
			this.LastError = null;
			var memory = new MemoryStream();
			var buffer = new Byte[this.ReceiveBufferSize];
			Int32 bytesRead;

			while ((bytesRead = await this.Client.GetStream().ReadAsync(buffer, 0, buffer.Length)) > 0)
			{
				await memory.WriteAsync(buffer, 0, bytesRead);
				if (buffer[bytesRead - 1] == VndbClient.EOTChar)
					break;
			}

			var result = this.GetString(memory.ToArray()).TrimEnd(VndbClient.EOTChar);
			memory.Dispose();
			return result;
		}

		protected async Task SendData(Byte[] data)
		{
			await this.Client.GetStream().WriteAsync(data, 0, data.Length);
		}

		protected void SetLastError(String json)
		{
			this.LastError = JsonConvert.DeserializeObject<OmniError>(json);
			this.LastErrorJson = json;
		}

		protected Byte[] FormatRequest(String data)
		{
			return this.GetBytes($"{data}{VndbClient.EOTChar}");
		}

		protected Byte[] FormatRequest<T>(String method, T data)
		{
			return this.FormatRequest($"{method} {JsonConvert.SerializeObject(data)}");
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

#if DEBUG

		public void Test()
		{
			var f1 = new FilterAnd(null, null);
		}

#endif
	}
}
