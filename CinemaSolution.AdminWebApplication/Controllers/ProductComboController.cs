using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Product;
using CinemaSolution.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("productcombos")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("product")]
    public class ProductComboController : Controller
    {
        private readonly IProductService _productService;
        public ProductComboController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5, string? keyword = null)
        {
            var request = new GetProductPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var products = await _productService.GetPagedResult(request);
            return View(products);
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetById(id);
            
            var productCombo = new ProductComboUpdateRequest
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Items = product.Items
            };

            return View(productCombo);
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!await _productService.Delete(id))
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
