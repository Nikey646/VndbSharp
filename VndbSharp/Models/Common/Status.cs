namespace VndbSharp.Models.Common
{
	/// <summary>
	/// Current Playing Status
	/// </summary>
	public enum Status
	{
		/// <summary>
		/// Unknown Status
		/// </summary>
		Unknown = 0,
		/// <summary>
		/// Currently Playing
		/// </summary>
		Playing = 1,
		/// <summary>
		/// Finished Playing
		/// </summary>
		Finished = 2,
		/// <summary>
		/// Currently Stalled
		/// </summary>
		Stalled = 3,
		/// <summary>
		/// Dropped Title
		/// </summary>
		Dropped = 4,
	}
}