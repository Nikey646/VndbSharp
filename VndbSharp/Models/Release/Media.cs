using System;

namespace VndbSharp.Models.Release
{
	/// <summary>
	/// Release media type (DVD, internet,...)
	/// </summary>
	public class Media
	{
		/// <summary>
		/// Medium Type
		/// </summary>
		public String Medium { get; private set; }
		/// <summary>
		/// Quantity of the medium
		/// </summary>
		public UInt32? Quantity { get; private set; }
	}
}
