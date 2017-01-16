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
        private static DateTime? _lastTime = null;

        public static async Task<IEnumerable<Tag>> GetTagDumpAsync()
            => await VndbUtils.GetDumpAsync<IEnumerable<Tag>>(Constants.TagsDump, null).ConfigureAwait(false);

        public static async Task<IEnumerable<Trait>> GetTraitDumpAsync()
            => await VndbUtils.GetDumpAsync<IEnumerable<Trait>>(Constants.TraitsDump, null).ConfigureAwait(false);

        private static async Task<T> GetDumpAsync<T>(String dumpUrl, String userAgent) where T : class
        {
            //sets a delay of 1 minute between fetching each dump
            if (VndbUtils._lastTime ==null && DateTime.Now - VndbUtils._lastTime < TimeSpan.FromSeconds(60))
                return null; //should we send a message of "too many requests" or similar here instead of null?
            var request = (HttpWebRequest)WebRequest.Create(dumpUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 5000;
            request.Proxy = null;
            request.UserAgent = userAgent ?? "VndbSharp (v0.1)";

            HttpWebResponse response = null;
            Stream responseStream = null;
            MemoryStream responseContent = null;

            try
            {
                response = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
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

                // Reset out position;
                responseContent.Position = 0;
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
                VndbUtils._lastTime= DateTime.Now;
            }
        }
    }
}
