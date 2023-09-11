using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> LoginAsync(string login, string password, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Login == login && x.Password == password, cancellationToken);
        }
    }
}
