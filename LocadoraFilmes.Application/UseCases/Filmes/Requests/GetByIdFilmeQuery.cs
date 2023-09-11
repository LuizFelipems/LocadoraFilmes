using LocadoraFilmes.Application.Commons.Queries;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record GetByIdFilmeQuery : Query<Response<FilmeResponse>>
    {
        public Guid Id { get; set; }

        public GetByIdFilmeQuery(Guid id)
        {
            Id = id;
        }
    }
}
