using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Infra.Data.Repositories
{
    public class LocacaoRepository : GenericRepository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(AppDbContext context) : base(context)
        { 
        }
        public override async Task<Locacao> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(x => x.Filmes)
                              .ThenInclude(x => x.Filme)
                              .ThenInclude(x => x.Genero)
                              .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<Locacao>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.Include(x => x.Filmes)
                              .ThenInclude(x => x.Filme)
                              .ThenInclude(x => x.Genero)
                              .ToListAsync(cancellationToken);
        }
    }
}
