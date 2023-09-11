namespace LocadoraFilmes.Domain.Models
{
    public class Genero : Entity<Genero>
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public virtual List<Filme> Filmes { get; set; } = new();
    }
}
