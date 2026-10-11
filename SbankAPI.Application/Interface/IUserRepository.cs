using SbankAPI.Domain.Entities;

namespace SbankAPI.Application.Interface
{
    public interface IUserRepository
    {
        Task AddUserAsync(Tbl_User user, CancellationToken cancellationToken);
        Task SaveChangesAsync();
    }
}
