using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentsMVC.Models;

namespace StudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Instructors()

        {
            List<Instructor> instructors = new List<Instructor>
            {
                new Instructor
                {
                    Id = 1,
                    FirstName = "Rick",
                    LastName = "Ramen"
                },
                new Instructor
                {
                    Id = 2,
                    FirstName = "Brett",
                    LastName = "Calendar"
                },
                new Instructor
                {
                    Id = 3,
                    FirstName = "Adam",
                    LastName = "Smithsonian"
                },
            };

            return View(instructors);
        }

        public IActionResult Instructor(int id)
        {
            ViewBag.Id = id;

            Instructor dayTimeInstructor = new Instructor
            {
                Id = 1,
                FirstName = "Jakub",
                LastName = "Sobieraj"
            };

            return View(dayTimeInstructor);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
