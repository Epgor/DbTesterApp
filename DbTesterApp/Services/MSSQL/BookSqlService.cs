using DbTesterApp.Models.Database;
using DbTesterApp.Models.Sql;
using Microsoft.EntityFrameworkCore;

namespace DbTesterApp.Services.MSSQL
{
    public class GenericSqlService<T> where T : class
    {
        private readonly BookStoreDbContext dbContext;
        public GenericSqlService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task AddMultipleAsync(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync() 
        {
            return await dbContext.Set<T>().ToListAsync();
        }
        public async Task<T?> GetAsync(string id)
        {
            return await dbContext.Set<T>()
                .FirstOrDefaultAsync(e => EF.Property<string>(e, "Id") == id);
        }

        public async Task<bool> UpdateAsync(string id, T entity)
        {
             var existingEntity = dbContext.Set<T>().Find(id);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var entity = dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task DeleteAllAsync()
        {
            var entities = await dbContext.Set<T>().ToListAsync();
            foreach (var entity in entities)
            {
                dbContext.Set<T>().Remove(entity);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
