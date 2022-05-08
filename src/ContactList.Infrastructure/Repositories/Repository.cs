using ContactList.Core;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ContactListDbContext dbContext;

        public Repository(ContactListDbContext dbContext) => this.dbContext = dbContext;

        public async Task<T> Create(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _ = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            entity.InclusionDate = DateTime.Now;
            var result = dbContext.Add(entity);

            _ = await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return result.Entity;
        }

        public async Task<T> Delete(T entity)
        {
            _ = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            _ = dbContext.Remove(entity);
            _ = await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public IQueryable<T> Get()
        {
            return dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);
        }

        public async Task<T> Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _ = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            entity.LastUpdateDate = DateTime.Now;
            var result = dbContext.Update(entity);

            _ = await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return result.Entity;
        }
    }
}
