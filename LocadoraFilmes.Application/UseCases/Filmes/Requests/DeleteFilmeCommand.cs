using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record DeleteFilmeCommand : CommandRequest<Response<DeleteFilmeResponse>>
    {
        public Guid Id { get; set; }

        public Filme GenerateFilme() => new() { Id = Id };
    }
}
