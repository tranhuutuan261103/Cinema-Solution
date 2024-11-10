using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Category;
using CinemaSolution.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

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
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetCategoryPagingRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var categoryPagedResult = await _categoryService.GetPagedResult(request);
            if (!string.IsNullOrEmpty(keyword))
            {
                ViewBag.Keyword = keyword;
            }
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
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input. Please check again.";
                return View(request);
            }
            try
            {
                await _categoryService.Create(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View(request);
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
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input. Please check again.";
                return View(request);
            }

            try
            {
                await _categoryService.Update(request);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(request);
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!await _categoryService.Delete(id))
                {
                    TempData["Error"] = "Delete category failed";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
