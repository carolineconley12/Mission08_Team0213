using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mission08_Team0213.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Mission08_Team0213.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(

        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
           _repo = temp;
        }


        [HttpGet]
        public IActionResult Update(int id)

        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(TaskTemplate updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);

        }
        [HttpPost]
        public IActionResult Delete(TaskTemplate task)
        {
            _repo.Movies.Remove(task);
            _repo.SaveChanges();

            return RedirectToAction("List");
        }

        //ADD VIEW


        [HttpGet]
        public IActionResult AddTask()
        {
            return View(new TaskTemplate());
        }

        [HttpPost]
         public IActionResult AddTask(TaskTemplate t)
         {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }

            return View(new TaskTemplate());

         }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories.ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskTemplate updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("List");
        }


    }
}
