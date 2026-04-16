using Antra.Training.MovieMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee) {
            if (ModelState.IsValid)
            {
                //save the data
                return RedirectToAction("Index");
            }
           return View(employee);
        }
    }
}
