using Microsoft.AspNetCore.Mvc;

namespace StudentsMVC.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
