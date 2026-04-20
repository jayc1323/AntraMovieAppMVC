using ApplicationCore.Contract.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            var users = adminService.GetAllUsers();
            return View(users);
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieRequest request)
        {
            if (ModelState.IsValid)
            {
                adminService.AddMovie(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult LockUser(int id)
        {
            adminService.LockUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult UnlockUser(int id)
        {
            adminService.UnlockUser(id);
            return RedirectToAction("Index");
        }
    }
}
