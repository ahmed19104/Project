using Project.Data.Base;
using Project.Data.ViewModel;
using Project.Models;

namespace Project.Data.Services
{
    public interface IMovicesService:IEntityBaseRepository<Movie>
    {
        Task<NewMovieDropDownVm> GetNewMovieDropDownValues();
        Task <Movie>  GetNewMovieByIdAsync(int data);
        Task UpdateMovieAsync(NewMovieVm data);
        Task AddMovieAsync(NewMovieVm data);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetTopMoviesAsync(int id);




    }
}
