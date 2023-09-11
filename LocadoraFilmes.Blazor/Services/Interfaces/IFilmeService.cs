using LocadoraFilmes.Blazor.Models;
using LocadoraFilmes.Blazor.Responses;

namespace LocadoraFilmes.Blazor.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<ResponseBase<FilmeResponse>> CreateFilme(CreateFilmeModel createFilme);
        Task<ResponseBase<FilmeResponse>> UpdateFilme(Guid id, UpdateFilmeModel updateFilme);
        Task<ResponseBase<List<FilmeResponse>>> GetAllFilmes();
        Task<ResponseBase<FilmeResponse>> GetByIdFilme(Guid id);
        Task<ResponseBase<DeleteFilmeResponse>> DeleteFilme(Guid id);
        Task<ResponseBase<DeleteFilmeResponse>> DeleteFilmes(Guid id);
        List<GeneroModel> GetAllGeneros();
    }
}
