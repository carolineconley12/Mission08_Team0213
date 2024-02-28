using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission08_Team0213.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Mission08_Team0213.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
           _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Tasks.FirstOrDefault(x => x.TaskId);
            return View(blah);
        }

        // need an update and delete controller

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.TaskId == id);

            return View(recordToDelete);

        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("List");
        }


        public IActionResult AddTask()
        {
            return View();
        }

    // need an add and edit task controller 

        [HttpGet]
        public IActionResult AddTask()
        {
            return View(new Task());
        }

        [HttpPost]

         public IActionResult AddTask(Task t)
         {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }

            return View(new Task());

         }






        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        [HttpGet]
        public IActionResult List()
        { // Go to table that shows the movie list
            var applications = _context.Movies
                .Include("Category")
                .ToList();

            return View(applications);

        }

    }
}
