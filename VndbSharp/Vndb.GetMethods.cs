using System;
using System.Threading.Tasks;
using VndbSharp.Extensions;
using VndbSharp.Interfaces;
using VndbSharp.Models;
using VndbSharp.Models.Character;
using VndbSharp.Models.Errors;
using VndbSharp.Models.Producer;
using VndbSharp.Models.Release;
using VndbSharp.Models.Staff;
using VndbSharp.Models.User;
using VndbSharp.Models.VisualNovel;

namespace VndbSharp
{
	public partial class Vndb
	{
		/// <summary>
		/// Returns the Database Stats as a C# Object
		/// </summary>
		/// <returns></returns>
		public async Task<DatabaseStats> GetDatabaseStatsAsync()
			=> await this.SendGetRequestInternalAsync<DatabaseStats>(this.FormatRequest(Constants.DbStatsCommand))
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Visual Novel(s) Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<VisualNovel>> GetVisualNovelAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<VisualNovel>>(Constants.GetVisualNovelCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Release(s) Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<Release>> GetReleaseAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<Release>>(Constants.GetReleaseCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Producer(s) Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<Producer>> GetProducerAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<Producer>>(Constants.GetProducerCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Character(s) Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<Character>> GetCharacterAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<Character>>(Constants.GetCharacterCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Staff Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<Staff>> GetStaffAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
	        IRequestOptions options = null)
	        => await this.GetInternalAsync<VndbResponse<Staff>>(Constants.GetStaffCommand, filters, flags, options)
	            .ConfigureAwait(false);

		/// <summary>
		/// Returns the User Information as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<User>> GetUserAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<User>>(Constants.GetUserCommand, filters, flags, options)
				.ConfigureAwait(false);
		//
		/// <summary>
		/// Returns the User's Votelist as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		[Obsolete("Use GetUserListAsync instead")]
		public async Task<VndbResponse<VoteList>> GetVoteListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<VoteList>>(Constants.GetVotelistCommand, filters, flags, options)
				.ConfigureAwait(false);
		//
		/// <summary>
		/// Returns the User's Visual Novel List as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		[Obsolete("Use GetUserListAsync instead")]
		public async Task<VndbResponse<VisualNovelList>> GetVisualNovelListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<VisualNovelList>>(Constants.GetVisualNovelListCommand, filters, flags, options)
				.ConfigureAwait(false);
		//
		/// <summary>
		/// Returns the User's Wishlist as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		[Obsolete("Use GetUserListAsync instead")]
		public async Task<VndbResponse<Wishlist>> GetWishlistAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<Wishlist>>(Constants.GetWishlistCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the UserList as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<UserList>> GetUserListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<UserList>>(Constants.GetUserListCommand, filters, flags, options)
				.ConfigureAwait(false);

		/// <summary>
		/// Returns the Userlist Labels as a C# Object
		/// </summary>
		/// <param name="filters">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <returns>The results from Vndb</returns>
		public async Task<VndbResponse<UserLabels>> GetUserListLabelsAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
			IRequestOptions options = null)
			=> await this.GetInternalAsync<VndbResponse<UserLabels>>(Constants.GetUserListLabelsCommand, filters, flags, options)
				.ConfigureAwait(false);

		// todo: Move this to Vndb.Helper.cs
		/// <summary>
		/// Method for processing the Get Methods
		/// </summary>
		/// <param name="method">Which API method to use</param>
		/// <param name="filter">The IFilter for the request</param>
		/// <param name="flags">The flags for the request</param>
		/// <param name="options">The IRequestOptions for the request</param>
		/// <typeparam name="T">The type of response expected</typeparam>
		/// <returns>The results from Vndb</returns>
		protected async Task<T> GetInternalAsync<T>(String method, IFilter filter, VndbFlags flags, IRequestOptions options = null)
			where T : class
		{
			// Need a way to communicate to the end user that these null values are not from the API?
			if (this.CheckFlags && !VndbUtils.ValidateFlagsByMethod(method, flags, out var invalidFlags))
			{
				this._invalidFlags?.Invoke(method, flags, invalidFlags);
				this.LastError = new LibraryError("CheckFlags is enabled and VndbSharp detected invalid flags");
				return null;
			}

			if (!filter.IsFilterValid())
			{
				this.LastError = new LibraryError($"A filter was not considered valid. The filter is of the type {filter.GetType().Name}");
				return null;
			}

			var requestData =
				this.FormatRequest($"{method} {flags.AsString(method)} ({filter})",
					options, false);
			return await this.SendGetRequestInternalAsync<T>(requestData).ConfigureAwait(false);
		}
	}
}
