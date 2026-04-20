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

        public IActionResult Index(int page = 1)
        {
            var movies = movieService.GetMoviesByPagination(page, 10);
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
