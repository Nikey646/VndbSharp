using System.Threading.Tasks;

namespace VndbSharp.Interfaces
{
    public interface IVndbClient
    {

        // Get methods.
        Task<DatabaseStats> GetDatabaseStatsAsync();

        Task<(IResponse<VisualNovel> response, IVndbError error)> GetVisualNovelAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<Release> response, IVndbError error)> GetReleaseAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<Producer> response, IVndbError error)> GetProducerAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<Character> response, IVndbError error)> GetCharacterAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<Staff> response, IVndbError error)> GetStaffAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<User> response, IVndbError error)> GetUserAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<VoteList> response, IVndbError error)> GetVoteListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<VisualNovelList> response, IVndbError error)> GetVisualNovelListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<UserList> response, IVndbError error)> GetUserListAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        Task<(IResponse<UserLabel> response, IVndbError error)> GetUserLabelsAsync(IFilter filters, VndbFlags flags = VndbFlags.Basic,
            IRequestOptions options = null);

        // Set methods.

    }
}
