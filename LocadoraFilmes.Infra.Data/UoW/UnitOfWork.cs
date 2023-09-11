using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Infra.Data.DataContexts;

namespace LocadoraFilmes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public bool HasChanges() => _context.ChangeTracker.HasChanges();

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        #endregion IDisposable
    }
}
