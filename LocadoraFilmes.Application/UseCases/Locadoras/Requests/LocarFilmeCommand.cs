using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Application.UseCases.Locadoras.Requests
{
    public record LocarFilmeCommand : CommandRequest<Response<LocacaoResponse>>
    {
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public List<Guid> FilmeIds { get; set; }

        public List<LocacaoFilme> GenerateLocacaoFilmes()
        {
            var ids = new List<LocacaoFilme>();

            foreach (var id in FilmeIds)
            {
                ids.Add(new LocacaoFilme() { FilmeId = id });
            }

            return ids;
        }
    }
}
