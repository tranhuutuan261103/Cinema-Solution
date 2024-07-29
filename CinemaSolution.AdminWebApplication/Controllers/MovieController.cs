using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Storage;
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
        private readonly IStorageService _storageService;
        public MovieController(IMovieService movieService, IStorageService storageService)
        {
            _movieService = movieService;
            _storageService = storageService;
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
            ViewBag.PageIndex = PageIndex;
            ViewBag.PageSize = PageSize;
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

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] MovieCreateRequest request)
        {
            if (request.ThumbnailImage != null)
            {
                string result = await _storageService.SaveFileAsync(request.ThumbnailImage.OpenReadStream(), "D:\\.WebCsharp\\CinemaSolution\\CinemaSolution.AdminWebApplication\\wwwroot\\user-content\\" + request.ThumbnailImage.FileName);
                Console.WriteLine(result);
            }
            return View();
        }
    }
}
