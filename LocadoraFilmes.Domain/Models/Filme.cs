namespace LocadoraFilmes.Domain.Models
{
    public class Filme : Entity<Filme>
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Guid GeneroId { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual List<LocacaoFilme> Locacoes { get; set; } = new();
    }
}
