using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Data.Base;
using Project.Data.ViewModel;
using Project.Models;

namespace Project.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMovicesService
    {
        public readonly AppDbContext _Context;
        public MoviesService(AppDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task AddMovieAsync(NewMovieVm data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                MovieCategory = data.MovieCategory

            };

            // أضف الفيلم بس، متعملش SaveChanges دلوقتي
            await _Context.Movies.AddAsync(newMovie);
            await _Context.SaveChangesAsync();

            // أضف روابط الـ Actors فوراً (من غير SaveChanges وسط)
            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,  // Entity Framework هيعرف إنه مرتبط بالفيلم الجديد
                    ActorId = actorId
                };
                _Context.Actors_Movies.Add(actorMovie);
            }

            // احفظ كل حاجة مرة واحدة فقط
            await _Context.SaveChangesAsync();
        }

        public async Task<Movie> GetNewMovieByIdAsync(int data)
        {
            var movieDetails =await _Context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(A => A.Actor_Movie).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == data);
            return movieDetails;
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var allMovies = await _Context.Movies
                .Include(m => m.Cinema)     // جلب بيانات السينما المرتبطة بالفيلم
                .Include(m => m.Producer)   // جلب بيانات المنتج المرتبط بالفيلم
                .ToListAsync();

            return allMovies;
        }

        public async Task<NewMovieDropDownVm> GetNewMovieDropDownValues()
        {
            var response = new NewMovieDropDownVm()
            {
                Cinemas = await _Context.Cinemas.OrderBy(n => n.Name).ToListAsync() ,
                Producers = await _Context.Producers.OrderBy(n => n.FullName).ToListAsync() ,
                Actors = await _Context.Actors.OrderBy(n => n.FullName).ToListAsync() 
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVm data)
        {
            var dbMovie =await _Context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.MovieCategory = data.MovieCategory;
                await _Context.SaveChangesAsync();
            }
            var existingActors = _Context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _Context.Actors_Movies.RemoveRange(existingActors);
            await _Context.SaveChangesAsync();
            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _Context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _Context.SaveChangesAsync();
        }
  

         async Task<Movie> IMovicesService.GetTopMoviesAsync(int id)
        {
            var topMovies = await _Context.Movies
               .Include(m => m.Cinema)
               .Include(m => m.Producer) // Assuming there's a Rating property
              .FirstOrDefaultAsync( m => m.Id == id);
            return topMovies;
        }
    }
}
