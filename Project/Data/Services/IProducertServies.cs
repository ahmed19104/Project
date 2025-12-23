using Project.Data.Base;
using Project.Models;

namespace Project.Data.Services
{
    public interface IProducertServies
    {
        Task<IEnumerable<Producert>> GetAll();
        Task<Producert> GetById(int id);
        Task Add(Producert producer);
        Task Update(int id, Producert producer);
        Task Delete(int id);
    }
}
