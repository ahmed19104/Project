using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Data.ViewModel;
using Project.Models;

namespace Project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
       



        public DbSet<Project.Models.Movie> Movies { get; set; }
        public DbSet<Project.Models.Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Project.Models.Cinema> Cinemas { get; set; }
        public DbSet<Project.Models.Producert> Producers { get; set; }
        public DbSet<Project.Models.Actor> Actors { get; set; }
        public DbSet<Project.Models.Order> Orders { get; set; }
        public DbSet<Project.Models.OrderItem> OrderItems { get; set; }
        public DbSet<Project.Models.ShoppingCartItem> ShoppingCardItems { get; set; }
       

        }
}
