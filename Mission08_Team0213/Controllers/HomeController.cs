using Microsoft.AspNetCore.Mvc;
using Mission08_Team0213.Models;
using System.Diagnostics;

namespace Mission08_Team0213.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
