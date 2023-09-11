namespace LocadoraFilmes.Domain.Models
{
    public class LocacaoFilme
    {
        public Guid LocacaoId { get; set; }
        public Locacao Locacao { get; set; }

        public Guid FilmeId { get; set; }
        public Filme Filme { get; set; }

        public LocacaoFilme() { }
    }
}
