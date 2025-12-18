
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _Context;

        public EntityBaseRepository(AppDbContext Context)
        {
            _Context = Context;

        }
        public async Task Add(T entity)
        {
           await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var actors = await _Context.Set<T>().ToListAsync();
            return actors; 
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _Context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return entity;
        }

        public Task Update(int id, T entity)
        {
           var entityToUpdate = _Context.Set<T>().FirstOrDefault(n => n.Id == id);
            if (entityToUpdate != null)
            {
                _Context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _Context.SaveChanges();
            }
           
            return Task.CompletedTask;
        }
    }
}
