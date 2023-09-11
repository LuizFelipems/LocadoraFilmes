namespace LocadoraFilmes.Application.UseCases.Filmes.Responses
{
    public record FilmeResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string GeneroNome { get; set; }
        public string GeneroId { get; set; }
    }
    
    public record DeleteFilmeResponse
    {
        public Guid Id { get; set; }
    }
}
