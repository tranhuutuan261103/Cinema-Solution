using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Category;
using CinemaSolution.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("categories")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        { 
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetCategoryPagingRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var categoryPagedResult = await _categoryService.GetPagedResult(request);
            return View(categoryPagedResult);
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

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int effected = await _categoryService.Delete(id);
                if (effected == 0)
                {
                    return BadRequest("Delete failed");
                }
                return RedirectToAction("Index");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
