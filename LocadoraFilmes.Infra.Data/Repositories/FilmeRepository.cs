using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Infra.Data.Repositories
{
    public class FilmeRepository : GenericRepository<Filme>, IFilmeRepository
    {
        public FilmeRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<Filme> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(x => x.Genero)
                              .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<Filme>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(x => x.Genero)
                              .ToListAsync(cancellationToken);
        }
    }
}
