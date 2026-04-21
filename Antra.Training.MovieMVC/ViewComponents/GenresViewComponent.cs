using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Antra.Training.MovieMVC.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetPage(1, 100);
            return View(genres.Data);
        }
    }
}
