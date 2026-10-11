using SbankAPI.Application.Interface;
using SbankAPI.Domain.Entities;
using SbankAPI.Infrastructure.Data;

namespace SbankAPI.Infrastructur.Repositories
{
    public class UserRepositories : IUserRepository
    {
        private readonly APpDbContext _context;

        public UserRepositories(APpDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(Tbl_User user, CancellationToken cancellationToken)
        {
            await _context.Tbl_Users.AddAsync(user, cancellationToken);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
