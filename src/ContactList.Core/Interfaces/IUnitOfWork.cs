namespace ContactList.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
    }
}
