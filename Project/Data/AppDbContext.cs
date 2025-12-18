using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Project.Models.Movie> Movies { get; set; }
        public DbSet<Project.Models.Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Project.Models.Cinema> Cinemas { get; set; }
        public DbSet<Project.Models.Producert> Producers { get; set; }
        public DbSet<Project.Models.Actor> Actors { get; set; }

        }
}
