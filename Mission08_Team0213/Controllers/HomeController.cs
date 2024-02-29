using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0213.Models;
using SQLitePCL;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

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
            var all = _repo.Tasks
                .Where(x => x.Completed == false)
                .Include(x => x.Category);    

            return View("Index", all);
		}


		// [HttpPost]
		//public IActionResult CompleteTask(int id)
		//{
		//	_repo.MarkTaskAsCompleted(id);

		//	return RedirectToAction("Index");
		//}

		[HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repo.Tasks
                .Single(x => x.TaskId == id);
                ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName);


            return View("AddTask", record);
        }

        [HttpPost]
        public IActionResult Edit(TaskTemplate task)
        {
            if (ModelState.IsValid)
            {
                _repo.EditTask(task);
                ViewBag.Categories = _repo.Categories;


            }
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var recordToDelete = _repo.Tasks
        //        .Single(x => x.TaskId == id);

        //    return View("Index", recordToDelete);
        //}

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
            _repo.DeleteTask(task);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName);
            return View(new TaskTemplate());
        }

        [HttpPost]
         public IActionResult AddTask(TaskTemplate t)
         {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
            }

			return RedirectToAction("Index", new TaskTemplate());

         }
    }
}
