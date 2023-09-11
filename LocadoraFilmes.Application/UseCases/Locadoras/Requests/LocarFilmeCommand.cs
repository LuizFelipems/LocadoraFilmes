using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using System.Text.Json.Serialization;

namespace LocadoraFilmes.Application.UseCases.Locadoras.Requests
{
    public record LocarFilmeCommand : CommandRequest<Response<LocacaoResponse>>
    {
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }

        [JsonIgnore]
        public Guid FilmeId { get; set; }

        public LocarFilmeCommand AssignFilmeId(Guid filmeId)
        {
            FilmeId = filmeId;
            return this;
        }
    }
}
