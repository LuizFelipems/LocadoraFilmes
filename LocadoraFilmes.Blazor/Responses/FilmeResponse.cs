using LocadoraFilmes.Blazor.Models;

namespace LocadoraFilmes.Blazor.Responses
{
    public class FilmeResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string GeneroNome { get; set; }
        public Guid GeneroId { get; set; }

        public UpdateFilmeModel GetUpdateFilmeModel()
            => new UpdateFilmeModel() { Nome = Nome, GeneroId = GeneroId, Ativo = true };
    }
}
