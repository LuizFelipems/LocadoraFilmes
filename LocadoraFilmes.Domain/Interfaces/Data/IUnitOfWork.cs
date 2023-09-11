namespace LocadoraFilmes.Domain.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        bool HasChanges();
    }
}
