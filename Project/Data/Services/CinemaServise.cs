using Project.Data.Base;

namespace Project.Data.Services
{
    public class CinemaServise: EntityBaseRepository<Project.Models.Cinema>, ICinemaServise
    {
        public CinemaServise(AppDbContext Context) : base(Context)
        {
        }
    }
    
}
