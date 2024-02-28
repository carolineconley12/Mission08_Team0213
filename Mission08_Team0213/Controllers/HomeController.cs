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
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repo.Tasks
                 .Single(x => x.TaskId == id);


            return View("AddTask", record);
        }

        [HttpPost]
        public IActionResult Edit(TaskTemplate task)
        {
            if (ModelState.IsValid)
            {
                _repo.EditTask(task);
              
            }
            return View(task);
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
            _repo.DeleteTask(task);
          

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


    }
}
