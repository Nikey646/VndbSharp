using System;
using System.Threading.Tasks;
using VndbSharp.Models.Common;

namespace VndbSharp
{
	public partial class Vndb
	{
		/// <summary>
		/// Command to Set the VoteList
		/// </summary>
		/// <param name="id">The id of the object to modify</param>
		/// <param name="vote">The new value</param>
		/// <returns></returns>
		public async Task<Boolean> SetVoteListAsync(UInt32 id, Byte? vote)
			=> await this.SendSetRequestInternalAsync(Constants.SetVotelistCommand, id, vote.HasValue ? new { vote } : null)
				.ConfigureAwait(false);

		/// <summary>
		/// Command to Set the Visual Novel List
		/// </summary>
		/// <param name="id">The id of the object to modify</param>
		/// <param name="status">The new status</param>
		/// <returns></returns>
		public async Task<Boolean> SetVisualNovelListAsync(UInt32 id, Status? status)
			=> await this.SendSetRequestInternalAsync(Constants.SetVisualNovelListCommand, id, status.HasValue ? new { status } : null)
				.ConfigureAwait(false);

		/// <summary>
		/// Command to Set the Visual Novel List
		/// </summary>
		/// <param name="id">The id of the object to modify</param>
		/// <param name="notes">The new notes</param>
		/// <returns></returns>
		public async Task<Boolean> SetVisualNovelListAsync(UInt32 id, String notes)
			=> await this.SendSetRequestInternalAsync(Constants.SetVisualNovelListCommand, id, new { notes }, true)
				.ConfigureAwait(false);

		/// <summary>
		/// Command to Set the Visual Novel List
		/// </summary>
		/// <param name="id">The id of the object to modify</param>
		/// <param name="status">The new status</param>
		/// <param name="notes">The new notes</param>
		/// <returns></returns>
		public async Task<Boolean> SetVisualNovelListAsync(UInt32 id, Status? status, String notes)
			=> await this.SendSetRequestInternalAsync(Constants.SetVisualNovelListCommand, id, status.HasValue ? new { status, notes } : null, true)
				.ConfigureAwait(false);

		/// <summary>
		/// Command to Set the Wishlist
		/// </summary>
		/// <param name="id">The id of the object to modify</param>
		/// <param name="priority">The new priority</param>
		/// <returns></returns>
		public async Task<Boolean> SetWishlistAsync(UInt32 id, Priority? priority)
			=> await this.SendSetRequestInternalAsync(Constants.SetWishlistCommand, id, priority.HasValue ? new { priority } : null)
				.ConfigureAwait(false);
	}
}
