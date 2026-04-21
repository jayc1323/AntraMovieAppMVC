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
        public async Task<IActionResult> Index(int id=1)
        {
           Page<GenreResponse> result = await genreService.GetPage(id);
            return View(result);
        }
        public async Task<IActionResult> Create() {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GenreRequest genreRequest) {

            if (ModelState.IsValid) {

                await genreService.AddGenre(genreRequest);
                return RedirectToAction("Index");
            }
            return View(genreRequest);
        }
    }
}
