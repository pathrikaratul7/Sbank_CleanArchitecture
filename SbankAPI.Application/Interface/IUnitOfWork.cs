namespace SbankAPI.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}