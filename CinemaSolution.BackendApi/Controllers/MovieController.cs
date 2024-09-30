using CinemaSolution.Application.Movie;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int categoryId)
        {
            if (categoryId == 0)
            {
                var movies = await _movieService.GetMovies(MovieStatus.ValidNow);
                return Json(movies);
            }
            else
            {
                var movies = await _movieService.GetMovies(MovieStatus.ValidNow, categoryId);
                return Json(movies);
            }
        }

        [HttpGet("future")]
        public async Task<IActionResult> MovieFuture(int categoryId)
        {
            if (categoryId == 0)
            {
                var movies = await _movieService.GetMovies(MovieStatus.ComingSoon);
                return Json(movies);
            }
            else
            {
                var movies = await _movieService.GetMovies(MovieStatus.ComingSoon, categoryId);
                return Json(movies);
            }
        }
    }
}
