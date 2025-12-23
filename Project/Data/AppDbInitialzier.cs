using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using Project.Data.Static;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public static class AppDbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // استخدم Migrate بدل EnsureCreated لو حاب
            //context.Database.EnsureCreated();

            // -------------------- Cinemas --------------------
            if (!context.Cinemas.Any())
            {
                var cinemas = new List<Cinema>
        {
            new Cinema { Name = "Grand Cinema", Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Generic_movie_cinema_icon.svg/1200px-Generic_movie_cinema_icon.svg.png" },
            new Cinema { Name = "Starplex", Logo = "https://cdn-icons-png.flaticon.com/512/220/220980.png" },
            new Cinema { Name = "Galaxy Cinemas", Logo = "https://cdn-icons-png.flaticon.com/512/616/616408.png" },
            new Cinema { Name = "Cineworld", Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Cineworld_logo.svg/512px-Cineworld_logo.svg.png" },
            new Cinema { Name = "AMC Theatres", Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/AMC_Theatres_Logo_2012.svg/512px-AMC_Theatres_Logo_2012.svg.png" },
            new Cinema { Name = "Regal Cinemas", Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/Regal_Cinemas_logo.svg/512px-Regal_Cinemas_logo.svg.png" },
            new Cinema { Name = "Odeon", Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Odeon_Logo.svg/512px-Odeon_Logo.svg.png" },
            new Cinema { Name = "Vue Cinemas", Logo = "https://upload.wikimedia.org/wikipedia/en/thumb/0/0d/Vue_cinemas_logo.svg/512px-Vue_cinemas_logo.svg.png" },
            new Cinema { Name = "Landmark Cinemas", Logo = "https://upload.wikimedia.org/wikipedia/en/thumb/1/1e/Landmark_Cinemas_Logo.svg/512px-Landmark_Cinemas_Logo.svg.png" },
            new Cinema { Name = "Cinemark", Logo = "https://upload.wikimedia.org/wikipedia/en/thumb/f/f0/Cinemark_logo.svg/512px-Cinemark_logo.svg.png" }
        };

                context.Cinemas.AddRange(cinemas);
                context.SaveChanges();
            }

            // -------------------- Actors --------------------
            if (!context.Actors.Any())
            {
                var actors = new List<Actor>
        {
            new Actor { FullName = "Leonardo DiCaprio", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/23/Leonardo_DiCaprio_66ème_Festival_de_Venise.jpg/440px-Leonardo_DiCaprio_66ème_Festival_de_Venise.jpg" },
            new Actor { FullName = "Scarlett Johansson", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/14/Scarlett_Johansson_in_Kuwait_01b-tweaked.jpg/440px-Scarlett_Johansson_in_Kuwait_01b-tweaked.jpg" },
            new Actor { FullName = "Tom Hanks", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Tom_Hanks_TIFF_2019.jpg/440px-Tom_Hanks_TIFF_2019.jpg" },
            new Actor { FullName = "Robert Downey Jr.", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f0/Robert_Downey_Jr_2014.jpg/440px-Robert_Downey_Jr_2014.jpg" },
            new Actor { FullName = "Jennifer Lawrence", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Jennifer_Lawrence_at_2018.jpg/440px-Jennifer_Lawrence_at_2018.jpg" },
            new Actor { FullName = "Morgan Freeman", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/Morgan_Freeman_Cannes_2018.jpg/440px-Morgan_Freeman_Cannes_2018.jpg" },
            new Actor { FullName = "Emma Watson", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Emma_Watson_2013.jpg/440px-Emma_Watson_2013.jpg" },
            new Actor { FullName = "Chris Hemsworth", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Chris_Hemsworth_by_Gage_Skidmore_2.jpg/440px-Chris_Hemsworth_by_Gage_Skidmore_2.jpg" },
            new Actor { FullName = "Natalie Portman", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Natalie_Portman_Cannes_2015.jpg/440px-Natalie_Portman_Cannes_2015.jpg" },
            new Actor { FullName = "Will Smith", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fd/Will_Smith_by_Gage_Skidmore_2.jpg/440px-Will_Smith_by_Gage_Skidmore_2.jpg" }
        };

                context.Actors.AddRange(actors);
                context.SaveChanges();
            }

            // -------------------- Producers --------------------
            if (!context.Producers.Any())
            {
                var producers = new List<Producert>
        {
            new Producert { FullName = "Steven Spielberg", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Steven_Spielberg_by_Gage_Skidmore_2.jpg/440px-Steven_Spielberg_by_Gage_Skidmore_2.jpg" },
            new Producert { FullName = "Christopher Nolan", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Christopher_Nolan_Cannes_2018.jpg/440px-Christopher_Nolan_Cannes_2018.jpg" },
            new Producert { FullName = "Quentin Tarantino", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0f/Quentin_Tarantino_by_Gage_Skidmore.jpg/440px-Quentin_Tarantino_by_Gage_Skidmore.jpg" },
            new Producert { FullName = "Martin Scorsese", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Martin_Scorsese_Cannes_2010.jpg/440px-Martin_Scorsese_Cannes_2010.jpg" },
            new Producert { FullName = "James Cameron", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/James_Cameron_by_Gage_Skidmore_2.jpg/440px-James_Cameron_by_Gage_Skidmore_2.jpg" },
            new Producert { FullName = "Peter Jackson", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Peter_Jackson_by_Gage_Skidmore.jpg/440px-Peter_Jackson_by_Gage_Skidmore.jpg" },
            new Producert { FullName = "Ridley Scott", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/71/Ridley_Scott_by_Gage_Skidmore_2.jpg/440px-Ridley_Scott_by_Gage_Skidmore_2.jpg" },
            new Producert { FullName = "Guy Ritchie", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Guy_Ritchie_2010.jpg/440px-Guy_Ritchie_2010.jpg" },
            new Producert { FullName = "David Fincher", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/David_Fincher_by_Gage_Skidmore_2.jpg/440px-David_Fincher_by_Gage_Skidmore_2.jpg" },
            new Producert { FullName = "J.J. Abrams", ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/J.J._Abrams_by_Gage_Skidmore_2.jpg/440px-J.J._Abrams_by_Gage_Skidmore_2.jpg" }
        };

                context.Producers.AddRange(producers);
                context.SaveChanges();
            }

            // -------------------- Movies --------------------
            if (!context.Movies.Any())
            {
                var cinemasList = context.Cinemas.ToList();
                var producersList = context.Producers.ToList();

                var movies = new List<Movie>
        {
            new Movie { Name="Inception", Description="A thief steals corporate secrets through dream-sharing technology.", Price=50, ImageURL="https://upload.wikimedia.org/wikipedia/en/7/7f/Inception_ver3.jpg", StartDate=DateTime.Now.AddDays(-10), EndDate=DateTime.Now.AddDays(20), CinemaId=cinemasList[0].Id, ProducerId=producersList[1].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="Avengers: Endgame", Description="After the devastating events of Infinity War...", Price=45, ImageURL="https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(30), CinemaId=cinemasList[1].Id, ProducerId=producersList[0].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="Forrest Gump", Description="The presidencies of Kennedy and Johnson...", Price=40, ImageURL="https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg", StartDate=DateTime.Now.AddDays(-5), EndDate=DateTime.Now.AddDays(25), CinemaId=cinemasList[2].Id, ProducerId=producersList[0].ProducerId, MovieCategory=MovieCategory.Drama },
            new Movie { Name="The Dark Knight", Description="Batman faces the Joker...", Price=55, ImageURL="https://upload.wikimedia.org/wikipedia/en/8/8a/Dark_Knight.jpg", StartDate=DateTime.Now.AddDays(-15), EndDate=DateTime.Now.AddDays(15), CinemaId=cinemasList[3].Id, ProducerId=producersList[1].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="Titanic", Description="A love story aboard the ill-fated ship.", Price=50, ImageURL="https://upload.wikimedia.org/wikipedia/en/2/2e/Titanic_poster.jpg", StartDate=DateTime.Now.AddDays(-20), EndDate=DateTime.Now.AddDays(10), CinemaId=cinemasList[4].Id, ProducerId=producersList[4].ProducerId, MovieCategory=MovieCategory.Comedy },
            new Movie { Name="Interstellar", Description="Explorers travel through a wormhole in space.", Price=60, ImageURL="https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", StartDate=DateTime.Now.AddDays(-8), EndDate=DateTime.Now.AddDays(22), CinemaId=cinemasList[5].Id, ProducerId=producersList[1].ProducerId, MovieCategory=MovieCategory.Horror },
            new Movie { Name="Gladiator", Description="A former Roman General seeks revenge.", Price=45, ImageURL="https://upload.wikimedia.org/wikipedia/en/8/8d/Gladiator_ver1.jpg", StartDate=DateTime.Now.AddDays(-12), EndDate=DateTime.Now.AddDays(18), CinemaId=cinemasList[6].Id, ProducerId=producersList[3].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="Jurassic Park", Description="Dinosaurs are brought back to life.", Price=50, ImageURL="https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg", StartDate=DateTime.Now.AddDays(-25), EndDate=DateTime.Now.AddDays(5), CinemaId=cinemasList[7].Id, ProducerId=producersList[0].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="The Matrix", Description="A computer hacker learns reality is a simulation.", Price=55, ImageURL="https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", StartDate=DateTime.Now.AddDays(-18), EndDate=DateTime.Now.AddDays(12), CinemaId=cinemasList[8].Id, ProducerId=producersList[2].ProducerId, MovieCategory=MovieCategory.Action },
            new Movie { Name="Avatar", Description="A marine on Pandora planet.", Price=65, ImageURL="https://upload.wikimedia.org/wikipedia/en/b/b0/Avatar-Teaser-Poster.jpg", StartDate=DateTime.Now.AddDays(-30), EndDate=DateTime.Now.AddDays(10), CinemaId=cinemasList[9].Id, ProducerId=producersList[4].ProducerId, MovieCategory=MovieCategory.Horror }
        };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            // Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            // Admin User
            string adminEmail = "Admin@etickets.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new AppUser
                {
                    FullName = "Admin User",
                    UserName = "admin-user",
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdmin, "Aa1234567890@");
                await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
            }

            // App User
            string userEmail = "user@etickets.com";
            var appUser = await userManager.FindByEmailAsync(userEmail);
            if (appUser == null)
            {
                var newUser = new AppUser
                {
                    FullName = "App User",
                    UserName = "app-user",
                    Email = userEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newUser, "Aa123456789@");
                await userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
        }
    }
}
