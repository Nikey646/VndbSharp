using System;

namespace VndbSharp
{
	public class UnexpectedResponseException : Exception
	{
		public String Response { get; }
		public String Request { get; }

		public UnexpectedResponseException(String request, String response)
			: base("An unexpected response was returned from Vndb.org")
		{
			this.Request = request;
			this.Response = response;
		}
	}
}
