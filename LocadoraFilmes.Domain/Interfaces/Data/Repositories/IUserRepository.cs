using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Domain.Interfaces.Data.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(string login, string password, CancellationToken cancellationToken = default);
    }
}
