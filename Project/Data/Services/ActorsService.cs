using Microsoft.EntityFrameworkCore;
using Project.Data.Base;
using Project.Models;

namespace Project.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsServices
    {

        public ActorsService(AppDbContext Context) : base(Context)
        {
        }
    } }
    
