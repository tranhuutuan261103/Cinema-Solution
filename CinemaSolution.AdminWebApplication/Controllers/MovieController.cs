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
            if (request.ThumbnailImage3x2 != null)
            {
                var thumbnailImage3x2Url = await _storageService.UploadFileAsync(
                    request.ThumbnailImage3x2.OpenReadStream(), 
                    "movie_thumbnail",
                    request.ThumbnailImage3x2.FileName);
                request.ThumbnailImage3x2Url = thumbnailImage3x2Url;
            }

            if (request.ThumbnailImage2x3 != null)
            {
                var thumbnailImage2x3Url = await _storageService.UploadFileAsync(
                                       request.ThumbnailImage2x3.OpenReadStream(),
                                       "movie_thumbnail",
                                       request.ThumbnailImage2x3.FileName);
                request.ThumbnailImage2x3Url = thumbnailImage2x3Url;
            }

            var result = await _movieService.Create(request);
            Console.WriteLine(result);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var movie = await _movieService.GetById(id);
            var categories = await _categoryService.GetAllCategories();

            var thumbnailImage3x2 = movie.MovieImages.Where(x => x.ImageType == "Poster").FirstOrDefault();
            var thumbnailImage2x3 = movie.MovieImages.Where(x => x.ImageType == "Backdrop").FirstOrDefault();
            MovieUpdateRequest request = new MovieUpdateRequest()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                EndDate = movie.EndDate,
                Actors = movie.Actors,
                Director = movie.Director,
                Language = movie.Language,
                TrailerUrl = movie.TrailerUrl,
                Categories = categories.Select(x => new ItemSelection<CategoryViewModel>()
                {
                    Item = x,
                    IsSelected = movie.Categories.Any(c => c.Id == x.Id)
                }).ToList(),
                ThumbnailImage3x2Url = thumbnailImage3x2 != null ? thumbnailImage3x2.ImageUrl : null,
                ThumbnailImage2x3Url = thumbnailImage2x3 != null ? thumbnailImage2x3.ImageUrl : null
            };
            Console.WriteLine(request);
            return View(request);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(MovieUpdateRequest request)
        {
            await _movieService.Update(request);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
