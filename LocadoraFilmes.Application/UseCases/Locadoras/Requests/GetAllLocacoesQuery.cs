using LocadoraFilmes.Application.Commons.Queries;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;

namespace LocadoraFilmes.Application.UseCases.Locadoras.Requests
{
    public record GetAllLocacoesQuery : Query<Response<List<LocacaoResponse>>>
    {
    }
}
