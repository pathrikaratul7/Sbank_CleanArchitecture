using SbankAPI.Domain.Entities;

namespace SbankAPI.Application.Interface
{
    public interface IUserRepository
    {
        Task AddUserAsync(Tbl_User user, CancellationToken cancellationToken = default);
        Task<Tbl_User?> GetUserByIdAsync(long userId, CancellationToken cancellationToken = default);
        Task SaveChangesAsync();
    }
}
