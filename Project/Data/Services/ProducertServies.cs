using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data.Services
{
    public class ProducertServies : IProducertServies
    {
        private readonly AppDbContext _context;
        public ProducertServies(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Producert producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            if (entityToDelete != null)
            {
                _context.Producers.Remove(entityToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Producert>> GetAll()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producert> GetById(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
        }

        public async Task Update(int id, Producert producer)
        {
            var entityToUpdate = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            if (entityToUpdate != null)
            {
                entityToUpdate.FullName = producer.FullName;
                entityToUpdate.ProfilePictureURL = producer.ProfilePictureURL;
                await _context.SaveChangesAsync();
            }
        }
    }
}
