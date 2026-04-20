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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var cast = castService.GetCastDetails(id);
            if (cast == null) return NotFound();
            return View(cast);
        }

        public IActionResult ByMovie(int movieId)
        {
            var cast = castService.GetCastByMovie(movieId);
            return View(cast);
        }
    }
}
