using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record CreateFilmeCommand : CommandRequest<Response<FilmeResponse>>
    {
        public string Nome { get; set; }
        public Guid GeneroId { get; set; }
    }
}
