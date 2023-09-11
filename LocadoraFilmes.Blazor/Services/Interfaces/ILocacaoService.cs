using LocadoraFilmes.Blazor.Models;
using LocadoraFilmes.Blazor.Responses;

namespace LocadoraFilmes.Blazor.Services.Interfaces
{
    public interface ILocacaoService
    {
        Task<ResponseBase<LocacaoResponse>> LocarFilmes(LocarFilmeModel updateFilme);
        Task<ResponseBase<List<LocacaoResponse>>> GetAllLocacoes();
    }
}
