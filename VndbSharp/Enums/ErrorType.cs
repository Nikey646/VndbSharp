namespace VndbSharp.Enums
{
	public enum ErrorType
	{
		Unknown = 0,
		Parse = 1,
		Missing = 2,
		BadArgument = 3,
		LoginRequired = 4,
		Throttled = 5,
		BadAuthentication = 6,
		LoggedIn = 7,
		GetType = 8,
		GetInfo = 9,
		InvalidFilter = 10,
		SetType = 11,
	}
}