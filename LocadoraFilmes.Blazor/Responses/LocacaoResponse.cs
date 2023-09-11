namespace LocadoraFilmes.Blazor.Responses
{
    public class LocacaoResponse
    {
        public Guid Id { get; set; }
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public List<FilmeResponse> Filmes { get; set; }
    }
}
