using SbankAPI.Application.Interface;
using SbankAPI.Infrastructur.Repositories;
using SbankAPI.Infrastructure.Data;

namespace SbankAPI.Infrastructur.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APpDbContext _context;
        private IUserRepository? _userRepository;

        public UnitOfWork(APpDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepositories(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}