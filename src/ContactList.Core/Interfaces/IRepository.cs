namespace ContactList.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);

        IQueryable<T> Get();

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
