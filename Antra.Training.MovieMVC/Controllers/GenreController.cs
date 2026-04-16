using ApplicationCore.Contract.Services;
using ApplicationCore.Helper;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }
        public IActionResult Index(int id=1)
        {
           Page<GenreResponse> result = genreService.GetPage(id);
            return View(result);
        }
        public IActionResult Create() {
            return View();
        }


        [HttpPost]
        public IActionResult Create(GenreRequest genreRequest) {

            if (ModelState.IsValid) {

                genreService.AddGenre(genreRequest);
                return RedirectToAction("Index");
            }
            return View(genreRequest);
        }
    }
}
