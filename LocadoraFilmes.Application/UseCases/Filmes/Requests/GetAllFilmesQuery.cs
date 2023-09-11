using LocadoraFilmes.Application.Commons.Queries;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record GetAllFilmesQuery : Query<Response<List<FilmeResponse>>>
    {
    }
}
