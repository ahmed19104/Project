using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using Project.Data.Services;
using Project.Data.Static;
using Project.Data.ViewModel;
using Project.Models;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index(int pg=1)
        {
            var movies = await _Context.GetAllAsync();
            if (pg < 1)
                pg = 1;
            int pageSize = 3;
            int recsCount = movies.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = movies.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _Context.GetTopMoviesAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _Context.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "ProducerId", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVm movie)
        {
            if (!ModelState.IsValid)
            {
               
                return View(movie);
            }
            
            await _Context.AddMovieAsync(movie);
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _Context.GetNewMovieByIdAsync(id);
            var movieDropDownsData = await _Context.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "ProducerId", "FullName");
            ViewBag.Actors = new MultiSelectList(
                movieDropDownsData.Actors,
                "Id",
                "FullName",
                movieDetails.Actor_Movie.Select(a => a.ActorId));

            return View(movieDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( NewMovieVm movie)
        {
            await _Context.UpdateMovieAsync( movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _Context.GetById(id);
            if (movieDetails == null) return NotFound(); // لو الفيلم غير موجود
            return View(movieDetails);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _Context.GetById(id);
            if (movie != null)
            {
                await _Context.Delete(id);
            }
            return RedirectToAction("Index");
        }


        public async Task< IActionResult> Filter(string searchString)
        {
            var movies =await _Context.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Name.ToLower().Contains(searchString.ToLower()) || m.Description.ToLower().Contains(searchString.ToLower())|| m.Cinema.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View("Index", movies.ToList());
        }
      

    }
}
