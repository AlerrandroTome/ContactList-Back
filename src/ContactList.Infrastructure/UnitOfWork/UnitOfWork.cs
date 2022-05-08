using ContactList.Core;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Context;
using ContactList.Infrastructure.Repositories;

namespace ContactList.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactListDbContext dbContext;

        public UnitOfWork(ContactListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new Repository<T>(dbContext);
        }
    }
}
