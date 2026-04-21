using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService castService;

        public CastController(ICastService castService)
        {
            this.castService = castService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var cast = await castService.GetCastDetails(id);
            if (cast == null) return NotFound();
            return View(cast);
        }

        public async Task<IActionResult> ByMovie(int movieId)
        {
            var cast = await castService.GetCastByMovie(movieId);
            return View(cast);
        }
    }
}
