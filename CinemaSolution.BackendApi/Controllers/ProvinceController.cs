using CinemaSolution.Application.Province;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("provinces")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;
        private readonly ILogger<ProvinceController> _logger;
        public ProvinceController(IProvinceService provinceService, ILogger<ProvinceController> logger)
        {
            _provinceService = provinceService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var provinces = await _provinceService.GetAll();
            return Json(provinces);
        }
    }
}
