using AirLiquide_Test.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AirLiquide_Test.Database.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext DatabaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            return await DatabaseContext.FindAsync<T>(id);
        }

        public virtual async Task AddOneAsync(T entity)
        {
            await DatabaseContext.AddAsync(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public virtual async Task UpdateOneAsync(T entity)
        {
            DatabaseContext.Update(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public virtual async Task RemoveOneAsync(T entity)
        {
            DatabaseContext.Remove(entity);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}