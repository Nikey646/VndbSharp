using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VndbSharp.Structs.Models.Dumps;

namespace VndbSharp
{
    public static class VndbUtils
    {
		internal static String ClientName = "VndbSharp";
		internal static Version Version = new Version(0, 1);

		private static DateTime? _lastTime = null;

		public static Int32 BufferSize { get; set; } = 4096;

        public static async Task<IEnumerable<Tag>> GetTagDumpAsync()
            => await VndbUtils.GetDumpAsync<IEnumerable<Tag>>(Constants.TagsDump).ConfigureAwait(false);

        public static async Task<IEnumerable<Trait>> GetTraitDumpAsync()
            => await VndbUtils.GetDumpAsync<IEnumerable<Trait>>(Constants.TraitsDump).ConfigureAwait(false);

	    public static async Task<IEnumerable<Vote>> GetVotesDumpAsync()
		    => await VndbUtils.GetAndParseVotesAsync().ConfigureAwait(false);

        private static async Task<T> GetDumpAsync<T>(String dumpUrl) where T : class
        {
            //sets a delay of 1 minute between fetching each dump
            if (VndbUtils._lastTime ==null && DateTime.Now - VndbUtils._lastTime < TimeSpan.FromSeconds(60))
                return null; //should we send a message of "too many requests" or similar here instead of null?

	        var request = VndbUtils.GetRequest(dumpUrl);
	        var response = await VndbUtils.GetResponseAsync(request).ConfigureAwait(false);

	        if (response == null)
				return null;

			VndbUtils._lastTime = DateTime.Now;
			return JsonConvert.DeserializeObject<T>(response);
		}

	    private static async Task<IEnumerable<Vote>> GetAndParseVotesAsync()
	    {
		    var request = VndbUtils.GetRequest(Constants.VotesDump);
		    var response = await VndbUtils.GetResponseAsync(request).ConfigureAwait(false);

		    if (response == null)
			    return null;

		    var votes = new List<Vote>();

			// Why this isn't just a json array of arrays is beyond me >:(
		    var lines = response.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

		    foreach (var line in lines)
		    {
			    var values = line.Split(new[] {' '}, 3, StringSplitOptions.RemoveEmptyEntries);
			    if (values.Length != 3)
				    continue; // Invalid
			    UInt32 vnId = 0;
			    UInt32 uid = 0;
			    Byte vote = 0;

				if (!UInt32.TryParse(values[0], out vnId) && 
					!UInt32.TryParse(values[1], out uid) && 
					!Byte.TryParse(values[2], out vote))
					continue; // One of our numbers was... not numbers?
			    
				votes.Add(new Vote
				{
					VisualNovelId = vnId,
					UserId = uid,
					VoteValue = vote,
				});
		    }

		    return votes;
	    }

	    private static WebRequest GetRequest(String url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = WebRequestMethods.Http.Get;
			request.Timeout = 20000;
			request.Proxy = null;
			request.UserAgent = $"{VndbUtils.ClientName} (v{VndbUtils.Version})";

			return request;
		}

		private static async Task<String> GetResponseAsync(WebRequest request)
		{
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
				var buffer = new Byte[VndbUtils.BufferSize];
				var encoding = String.IsNullOrWhiteSpace(response.CharacterSet)
					? Encoding.UTF8
					: Encoding.GetEncoding(response.CharacterSet);


				Int32 bytesRead;
				while ((bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
					await responseContent.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);

				// Reset our position;
				responseContent.Position = 0;
				// Reset the buffer as well
				buffer = new Byte[VndbUtils.BufferSize];
				using (var gzipStream = new GZipStream(responseContent, CompressionMode.Decompress))
				using (var finalStream = new MemoryStream())
				{
					while ((bytesRead = await gzipStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
						await finalStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
					return encoding.GetString(finalStream.ToArray());
				}
			}
			catch (WebException)
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
	}
}
