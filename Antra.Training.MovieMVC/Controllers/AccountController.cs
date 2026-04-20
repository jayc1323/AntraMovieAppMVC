using ApplicationCore.Contract.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = accountService.Login(request);
                if (user != null)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View(request);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                accountService.Register(request);
                return RedirectToAction("Login");
            }
            return View(request);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
