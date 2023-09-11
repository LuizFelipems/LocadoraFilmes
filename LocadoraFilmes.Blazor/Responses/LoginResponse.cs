namespace LocadoraFilmes.Blazor.Responses
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
