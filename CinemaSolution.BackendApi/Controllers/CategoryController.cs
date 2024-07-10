using Microsoft.AspNetCore.Mvc;
using CinemaSolution.Application.Category;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return Json(categories);
        }
    }
}
