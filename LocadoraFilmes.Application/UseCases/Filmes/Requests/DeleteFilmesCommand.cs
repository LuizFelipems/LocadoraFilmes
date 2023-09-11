using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record DeleteFilmesCommand : CommandRequest<Response<List<DeleteFilmeResponse>>>
    {
        public List<Guid> Ids { get; set; }

        public List<Filme> GenerateFilmes()
        {
            var ids = new List<Filme>();

            foreach (var id in Ids)
            {
                ids.Add(new Filme() { Id = id});
            }

            return ids;
        }
    }
}
