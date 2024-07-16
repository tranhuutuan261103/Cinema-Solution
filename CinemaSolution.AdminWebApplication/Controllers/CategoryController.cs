using CinemaSolution.Application.Category;
using CinemaSolution.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("categories")]
    [Authorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        { 
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            await _categoryService.Create(request);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(new CategoryUpdateRequest { Id = id, Name = category.Name});
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            await _categoryService.Update(request);
            return RedirectToAction("Index");
        }
    }
}
