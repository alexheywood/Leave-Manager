using LeaveManager.web.Data;
using LeaveManager.web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeaveManager.web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity); 
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteASync(int id)
        {
            var entity = await GetAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await GetAllAsync();
            return entities.ToList();
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await GetAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
