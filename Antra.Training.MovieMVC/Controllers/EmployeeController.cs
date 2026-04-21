using Antra.Training.MovieMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee) {
            if (ModelState.IsValid)
            {
                //save the data
                return RedirectToAction("Index");
            }
           return View(employee);
        }
    }
}
