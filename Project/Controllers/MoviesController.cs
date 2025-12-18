using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Services;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovicesService _Context;
        public MoviesController(IMovicesService Context)
        {
            _Context = Context;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _Context.GetAll();
            return View(movies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _Context.GetById(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project.Models.Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _Context.Add(movie);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Project.Models.Movie actor)
        {
            await _Context.Update(id, actor);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Context.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
