using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Movie;
using CinemaSolution.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("movies")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int PageIndex = 1, int PageSize = 5, string Keyword = "", string Category = "")
        {
            GetMoviePagingRequest request = new GetMoviePagingRequest()
            {
                Category = Category,
                Keyword = Keyword,
                PageIndex = PageIndex,
                PageSize = PageSize
            };
            var result = await _movieService.GetPagedResult(request);
            if (!string.IsNullOrEmpty(Category))
            {
                ViewBag.Category = Category;
            }
            if (!string.IsNullOrEmpty(Keyword))
            {
                ViewBag.Keyword = Keyword;
            }
            return View(result);
        }
    }
}
