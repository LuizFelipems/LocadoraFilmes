namespace LocadoraFilmes.Domain.Models
{
    public abstract class Entity<T> 
        where T : Entity<T>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Entity() { }
    }
}
