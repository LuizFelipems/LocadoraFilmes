namespace LocadoraFilmes.Domain.Interfaces.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task Add(T entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void Remove(T entity, CancellationToken cancellationToken = default);
        void RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}
