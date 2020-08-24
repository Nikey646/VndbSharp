using System;
using VndbSharp.Models.Common;

namespace VndbSharp.Models.Producer
{
	/// <summary>
	/// Links related to a Producer
	/// </summary>
	public class ProducerLinks : CommonLinks
	{
		/// <summary>
		/// Producer's homepage
		/// </summary>
		public String Homepage { get; private set; }
	}
}
