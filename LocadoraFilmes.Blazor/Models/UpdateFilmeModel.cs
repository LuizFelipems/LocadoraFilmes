namespace LocadoraFilmes.Blazor.Models
{
    public class UpdateFilmeModel
    {
        public string Nome { get; set; }
        public Guid GeneroId { get; set; }
        public bool Ativo { get; set; }
    }
}
