using CinemaSolution.Application.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly ILogger<CinemaController> _logger;
        public CinemaController(ICinemaService cinemaService, ILogger<CinemaController> logger)
        {
            _cinemaService = cinemaService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int provinceId)
        {
            var cinemas = await _cinemaService.GetByProvinceId(provinceId);
            return Json(cinemas);
        }
    }
}
