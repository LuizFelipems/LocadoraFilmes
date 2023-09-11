namespace LocadoraFilmes.Domain.Models
{
    public class User : Entity<User>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
