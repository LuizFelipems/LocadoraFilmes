using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Infra.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity<T>
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> DbSet { get; init; }

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual async Task<T> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
