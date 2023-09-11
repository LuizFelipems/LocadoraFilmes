using LocadoraFilmes.Blazor.Models;

namespace LocadoraFilmes.Blazor.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<string?> LoginUser(LoginModel loginModel);
        Task<string> GetTokenUserAsync();
    }
}
