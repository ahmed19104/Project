using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Data.Base;
using Project.Models;

namespace Project.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMovicesService
    {
        public MoviesService(AppDbContext Context) : base(Context)
        {
        }

    }
}
