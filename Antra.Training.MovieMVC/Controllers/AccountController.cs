using ApplicationCore.Contract.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public  AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>     Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await accountService.Login(request);
                if (user != null)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View(request);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                await accountService.Register(request);
                return RedirectToAction("Login");
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
