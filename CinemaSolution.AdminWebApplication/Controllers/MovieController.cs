using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Category;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Storage;
using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Common.ItemSelection;
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
        private readonly ICategoryService _categoryService;
        private readonly IStorageService _storageService;
        public MovieController(IMovieService movieService, ICategoryService categoryService, IStorageService storageService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
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
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategories();
            MovieCreateRequest request = new MovieCreateRequest()
            {
                Categories = categories.Select(x => new ItemSelection<CategoryViewModel>()
                {
                    Item = x,
                    IsSelected = false
                }).ToList()
            };
            return View(request);
        }

        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] MovieCreateRequest request)
        {
            var result = await _movieService.Create(request);
            Console.WriteLine(result);
            return RedirectToAction("Index");
        }
    }
}
