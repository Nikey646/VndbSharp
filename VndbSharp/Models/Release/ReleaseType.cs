namespace VndbSharp.Models.Release
{
	/// <summary>
	/// Type of Release
	/// </summary>
	public enum ReleaseType
	{
		/// <summary>
		/// Trial Version
		/// </summary>
		Trial = 0,
		/// <summary>
		/// Partial Version, normally used by patches
		/// </summary>
		Partial = 1,
		/// <summary>
		/// Completed Release
		/// </summary>
		Complete = 2,
	}
}