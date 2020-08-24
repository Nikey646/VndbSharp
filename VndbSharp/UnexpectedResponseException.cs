using System;

namespace VndbSharp
{
	/// <summary>
	/// Class for dealing with an unexpected response from the API
	/// </summary>
	public class UnexpectedResponseException : Exception
	{
		/// <summary>
		/// Gets/Sets the command/response objects from an unexpected response
		/// </summary>
		/// <param name="command"></param>
		/// <param name="response"></param>
		public UnexpectedResponseException(String command, String response)
		{
			this.Command = command;
			this.Response = response;
		}

		/// <summary>
		/// Command that was sent
		/// </summary>
		public String Command { get; private set; }
		/// <summary>
		/// Response received from the API
		/// </summary>
		public String Response { get; private set; }
	}
}