namespace VndbSharp.Models.Common
{
	/// <summary>
	/// Priority levels, usually used for Wishlist
	/// </summary>
	public enum Priority
	{
		/// <summary>
		/// High Priority
		/// </summary>
		High = 0,
		/// <summary>
		/// Medium Priority
		/// </summary>
		Medium = 1,
		/// <summary>
		/// Low Priority
		/// </summary>
		Low = 2,
		/// <summary>
		/// Blacklisted Priority
		/// </summary>
		Blacklist = 3,
	}
}