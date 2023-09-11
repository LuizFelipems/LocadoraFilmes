using LocadoraFilmes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFilmes.Infra.Data.DataContexts
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.Parse("8eb11624-86a4-4c5c-9490-960e846c6d24"), Nome = "Usuário Master", Login = "root", Password = "123", Role = "admin" }
            );
            
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = Guid.Parse("d9b1e988-7366-41e5-a845-3fef66acf0b2"), Nome = "Ação" },
                new Genero { Id = Guid.Parse("4e378b57-3f46-4552-8442-4dc4ff06bfb2"), Nome = "Aventura" },
                new Genero { Id = Guid.Parse("fcb9988e-a87f-42e2-a7ea-f8b37dc4e65a"), Nome = "Drama" },
                new Genero { Id = Guid.Parse("8514a6c6-c958-4dd7-950b-ce058b921225"), Nome = "Comédia" },
                new Genero { Id = Guid.Parse("64437865-abc3-4566-a7c0-a6d8a38fdf1d"), Nome = "Terror" }
            );
        }
    }
}
