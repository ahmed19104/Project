namespace Project.Data
{
    public class AppDbInitialzier
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                // Seed data
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(
                        new Models.Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",

                        },
                        new Models.Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",

                        }
                    );
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(
                            new Models.Actor()
                            {
                                FullName = "AbdElhalim",
                                ProfilePictureURL = "https://i.postimg.cc/xC8L7bGd/43358-bd-alhlym-hafz.webp"
                            },
                            new Models.Actor()
                            {
                                FullName = "Om Kalsom",
                                ProfilePictureURL = "https://i.postimg.cc/Kz5vn93L/artworks-000145735139-kke59p-t500x500.jpg"
                            }
                        );


                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
