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
    }
}
