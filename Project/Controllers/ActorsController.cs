using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Project.Data;
using Project.Data.Services;

namespace Project.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly IActorsServices _Context;

        public ActorsController(IActorsServices Context, IToastNotification toast)
        {
            _Context = Context;
            _toast = toast;

        }



        public async Task<IActionResult> Index()
        {
            var actors = await _Context.GetAll();
            return View(actors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _Context.GetById(id);
            return View(actor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project.Models.Actor actor)
        {

            await _Context.Add(actor);
            _toast.AddSuccessToastMessage("Actor created successfully");
            return RedirectToAction("Index");
        }
        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _Context.GetById(id); // جلب Actor من قاعدة البيانات
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor); // إرسال البيانات للـ View
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Project.Models.Actor actor)
        {
            await _Context.Update(id, actor);
            

            _toast.AddSuccessToastMessage("Actor updated successfully");
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
            _toast.AddSuccessToastMessage("Actor deleted successfully");
            return RedirectToAction("Index");
        }
    }
}
