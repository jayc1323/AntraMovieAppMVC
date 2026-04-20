using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public IActionResult Index(int id = 1)
        {
            var movies = movieService.GetMoviesByPagination(id);
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = movieService.GetMovieDetails(id);
            return View(movie);
        }
    }
}
