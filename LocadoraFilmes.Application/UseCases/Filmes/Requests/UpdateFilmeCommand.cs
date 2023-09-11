using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using System.Text.Json.Serialization;

namespace LocadoraFilmes.Application.UseCases.Filmes.Requests
{
    public record UpdateFilmeCommand : CommandRequest<Response<FilmeResponse>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid GeneroId { get; set; }
        public bool Ativo { get; set; }

        public UpdateFilmeCommand AssignId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
