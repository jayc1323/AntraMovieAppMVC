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

        public async Task<IActionResult> Index()
        {
            var users = await adminService.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieRequest request)
        {
            if (ModelState.IsValid)
            {
                await adminService.AddMovie(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public async Task<IActionResult> LockUser(int id)
        {
            await adminService.LockUser(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UnlockUser(int id)
        {
            await adminService.UnlockUser(id);
            return RedirectToAction("Index");
        }
    }
}
