using DbTesterApp.Models.Database;
using DbTesterApp.Models.Sql;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public async Task<bool> UpdateAddressAsync(string id, string value)
        {
            var existingEntity = dbContext.Set<T>().Find(id);

            if (existingEntity != null)
            {
                var propertyInfo = existingEntity.GetType().GetProperty("Address");
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(existingEntity, value);
                    await dbContext.SaveChangesAsync();
                    return true;
                };
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

        public async Task<List<string>> GetAllIds()
        {
            List<T> list = await GetAllAsync();
            List<string> ids = list.Select(GetIdValue).ToList();
            return ids;
        }
        private string GetIdValue(T obj)
        {
            PropertyInfo idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                object idValue = idProperty.GetValue(obj);
                return idValue?.ToString();
            }
            return null;
        }

        public async Task DeleteSomeId()
        {
            var firstObject = await GetAllAsync();

            if (firstObject.Count > 0)
            {
                var objectId = GetIdValue(firstObject.First());
                await DeleteAsync(objectId);
            }
        }
    }
}
