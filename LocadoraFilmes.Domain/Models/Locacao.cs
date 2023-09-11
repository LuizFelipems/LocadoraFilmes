namespace LocadoraFilmes.Domain.Models
{
    public class Locacao : Entity<Locacao>
    {
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }

        public virtual List<LocacaoFilme> Filmes { get; set; } = new();

        public void LocarFilme(Guid filmeId)
            => Filmes.Add(new LocacaoFilme() { FilmeId = filmeId});

        public void LocarFilmes(List<LocacaoFilme> locacaoFilmes)
            => Filmes.AddRange(locacaoFilmes);
    }
}
