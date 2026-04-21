using Antra.Training.MovieMVC.Models;
using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Antra.Training.MovieMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = await movieService.GetMoviesByPagination(page, 10);
            return View(movies);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
