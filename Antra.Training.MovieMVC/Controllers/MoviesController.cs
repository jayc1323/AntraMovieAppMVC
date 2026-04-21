using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
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

        public async Task<IActionResult> Index(int id = 1)
        {
            var movies = await movieService.GetMoviesByPagination(id);
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await movieService.GetMovieDetails(id);
            return View(movie);
        }

        public async Task<IActionResult> MoviesByGenre(int id, int pageSize = 30, int pageNumber = 1)
        {
            ViewBag.GenreId = id;
            var movies = await movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View(movies);
        }
    }
}
